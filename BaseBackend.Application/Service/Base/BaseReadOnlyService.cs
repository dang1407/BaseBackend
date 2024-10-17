using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BaseBackend.Application
{
    public abstract class BaseReadOnlyService<TEntity, TDTO, TFilter> : IBaseReadOnlyService<TDTO, TFilter> where TFilter : BaseFilter where TEntity : BaseEntity, IEntity
    {
        protected readonly IBaseRepository<TEntity, TFilter> BaseRepository;
        protected readonly IMapper Mapper;
        protected BaseReadOnlyService(IBaseRepository<TEntity, TFilter> baseRepository, IMapper mapper)
        {
            BaseRepository = baseRepository;
            Mapper = mapper;
        }


        /// <summary>
        /// Hàm tìm kiếm Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<TDTO> FindByIdAsync(Guid id)
        {
            var entity = await BaseRepository.FindByIdAsync(id);
            var result = MapEntityToDTO(entity);
            return result;
        }

        /// <summary>
        /// Hàm lấy thông tin Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<TDTO> GetByIdAsync(Guid id)
        {
            var entity = await BaseRepository.GetByIdAsync(id); 
            var result = MapEntityToDTO(entity);    
            return result;  
        }

        public async Task<List<TDTO>> GetPaging(PagingInfo pagingInfo, TFilter filter)
        {
            if(pagingInfo.PageIndex < 1)
            {
                pagingInfo.PageIndex = 0;
            }
            else
            {
                pagingInfo.PageIndex = pagingInfo.PageIndex - 1;
            }
            List<TEntity> entities = await BaseRepository.GetPaging(pagingInfo, filter);
            List<TDTO> result = entities.Select(e => Mapper.Map<TDTO>(e)).ToList();
            return result;
        }


        /// <summary>
        /// Hàm chuyển đổi từ Entity sang DTO
        /// </summary>
        /// <param name="entity">Instance của TEntity</param>
        /// <returns>DTO</returns>
        /// Created by: nkmdang (19/09/2023)
        public virtual TDTO MapEntityToDTO(TEntity entity)
        {
            var dto = Mapper.Map<TDTO>(entity);
            return dto; 
        }

       
    }
}
