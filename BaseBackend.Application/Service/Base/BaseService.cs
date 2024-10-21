using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaseBackend.Domain.Constant;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;

namespace BaseBackend.Application
{
    public class BaseService<TEntity, TDTO, TFilter, TIdKey> : BaseReadOnlyService<TEntity, TDTO, TFilter, TIdKey>, IBaseService<TDTO, TFilter, TIdKey> where TEntity : BaseEntity, IEntity<TIdKey> where TFilter : BaseFilter where TIdKey : struct
    {
        private readonly Type _type = typeof(TEntity);
        private BaseEntity _entity;
        private readonly IMemoryCache _memoryCache;
        protected BaseService(IBaseRepository<TEntity, TFilter, TIdKey> baseRepository, IMapper mapper, IMemoryCache memoryCache) : base(baseRepository, mapper)
        {
            _memoryCache = memoryCache;
            if (Activator.CreateInstance(_type) is BaseEntity entity)
            {
                _entity = entity;
            }
            else
            {
                throw new InvalidException("Entity không phải BaseEntity");
            }
        }


        /// <summary>
        /// Hàm thêm mới một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<TDTO> InsertAsync(TDTO createDTO, CachedUserInfo cachedUserInfo)
        {
            var entity = MapCreateDTOToEntity(createDTO);
            //if(entity.GetId() == Guid.Empty)
            //{
            //    entity.SetId(Guid.NewGuid());   
            //}

            // Map các trường của Base Enity
            if(entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedDate ??= DateTime.Now;
                baseEntity.CreatedBy ??= cachedUserInfo.AccountId;
                baseEntity.ModifiedDate ??= DateTime.Now;
                baseEntity.ModifiedBy ??= cachedUserInfo.AccountId;
            }

            await ValidateCreateBusinessAsync(entity);

            // Entity có đủ các trường rồi, gán Id ở Backend luôn
            var result = await BaseRepository.InsertAsync(entity);
            var resultEmployee = MapEntityToDTO(result);
            return resultEmployee;
        }

        /// <summary>
        /// Hàm thêm mới nhiều Entity
        /// </summary>
        /// <param name="entities">Instances của Entity</param>
        /// <returns>Thông tin các Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> InsertManyAsync(List<TDTO> createDTOs, CachedUserInfo cachedUserInfo)
        {
            // Chuyển đổi CreateDTOs thành các Entity
            var listEntities = createDTOs.Select(createDTO => MapCreateDTOToEntity(createDTO)).ToList();
            listEntities.ForEach(e => {
                //e.SetId(Guid.NewGuid());
                e.CreatedDate = DateTime.Now;
                
                }); 
            // Lọc ra các Id
            var listIds = listEntities.Select(entity => entity.GetId()).ToList();

            //Tìm các Entity đã tồn tại
            var existEntities = await BaseRepository.GetByListIdAsync(listIds);
            // Lọc ra Id của các Entity đã tồn tại
            var existEntitiesId = existEntities.Select( entity => entity.GetId()).ToList();
            // Lọc ra các Entity mới để gọi hàm Create
            var newEntitiesToCreate = listEntities.Where(entity => !existEntitiesId.Contains(entity.GetId())).ToList();
            var listResultEntities = await BaseRepository.InsertManyAsync(newEntitiesToCreate);
            var results = listResultEntities.Select(entity =>  MapEntityToDTO(entity)).ToList(); 
            return results.Count;
        }

        /// <summary>
        /// Hàm sửa thông tin một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin của Entity sau khi đã thay đổi</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> UpdateAsync(TIdKey id, TDTO updateDTO, CachedUserInfo cachedUserInfo)
        {
            var entity = await BaseRepository.GetByIdAsync(id);

            
            // Map các trường của Base Enity
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.ModifiedDate ??= DateTime.Now;
                baseEntity.ModifiedBy ??= cachedUserInfo.AccountId;
            }
            var newEntity = MapUpdateDTOToEntity(updateDTO, entity);
            //if (newEntity.GetId<Guid>() == Guid.Empty)
            //{
            //    newEntity.SetId(id);
            //}
            await ValidateUpdateBusinessAsync(newEntity);

            await BaseRepository.UpdateAsync(newEntity);
            var result = MapEntityToDTO(newEntity);
            
            return 1;
        }

        public Task<int> UpdateManyAsync(List<TDTO> entities, CachedUserInfo cachedUserInfo)
        {
            var result = BaseRepository.UpdateManyAsync(entities.Select(e => Mapper.Map<TEntity>(e)).ToList());
            return result;
        }

        /// <summary>
        /// Hàm xóa thông tin một Entity
        /// </summary>
        /// <param name="id">Định danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> DeleteAsync(TIdKey id, CachedUserInfo cachedUserInfo)
        {
            TEntity? existItem = await BaseRepository.FindByIdAsync(id);
            if (existItem == null) 
            {
                throw new NotFoundException(SharedResource.ItemNotFoundMessage);
            }
            int result;
            if (_entity.HasDeleted)
            {
                result = await BaseRepository.SoftDeleteAsync(id);
                return result;
            }
            result = await BaseRepository.DeleteAsync(id);  
            return result;
        }

        /// <summary>
        /// Hàm xóa thông tin nhiều Entity
        /// </summary>
        /// <param name="ids">Danh sách các dịnh danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> DeleteManyAsync(List<TIdKey> ids, CachedUserInfo cachedUserInfo)
        {
            var entities = await BaseRepository.GetByListIdAsync(ids);
            int result;
            if (_entity.HasDeleted)
            {
                result = await BaseRepository.SoftDeleteManyAsync(ids);
                return result;
            }
            result = await BaseRepository.DeleteManyAsync(ids);
            return result;
        }

        


        /// <summary>
        /// Hàm Validate nghiệp vụ cho thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Thông tin Entity thêm mới</param>
        /// <returns>Ném ra lỗi nếu đầu vào không thỏa mãn nghiệp vụ</returns>
        /// Created by: nkmdang (19/09/2023)
        public virtual async Task ValidateCreateBusinessAsync(TEntity entity) 
        {
            var existEntity = await BaseRepository.FindByIdAsync(entity.GetId());
            if (existEntity != null)
            {
                throw new ConflictException("Tài nguyên đã tồn tại");
            }
        }

        /// <summary>
        /// Hàm Validate nghiệp vụ cho sửa đổi 1 bản ghi
        /// </summary>
        /// <param name="entity">Thông tin Entity thêm mới</param>
        /// <returns>Ném ra lỗi nếu đầu vào không thỏa mãn nghiệp vụ</returns>
        /// Created by: nkmdang (19/09/2023)
        public virtual async Task ValidateUpdateBusinessAsync(TEntity entity)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Hàm chuyển đổi từ CreateDTO sang Entity
        /// </summary>
        /// <param name="createDTO">Instance của TCreateDTO</param>
        /// <returns>Entity</returns>
        /// Created by: nkmdang (19/09/2023)
        protected TEntity MapCreateDTOToEntity(TDTO createDTO)
        {
            var entity = Mapper.Map<TEntity>(createDTO);
            //if(entity.GetId() == Guid.Empty)
            //{
            //    entity.SetId(Guid.NewGuid());   
            //}
            return entity;
        }

        /// Hàm chuyển đổi từ UpdateDTO sa
        /// <summary>ng Entity
        /// </summary>
        /// <param name="updateDTO">Instance của TUpdateDTO</param>
        /// <returns>Entity</returns>
        /// Created by: nkmdang (19/09/2023)
        protected TEntity MapUpdateDTOToEntity(TDTO updateDTO, TEntity entity)
        {
            var resultEntity = Mapper.Map(updateDTO, entity);
            return resultEntity;
        }

        protected TEntity MapDTOToEntity(TDTO dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            return entity;
        }

        
    }
}
