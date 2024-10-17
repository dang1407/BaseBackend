using Dapper;
using System.Data;
using System.Reflection;
using BaseBackend.Application;
using BaseBackend.Domain;
using System.Data.Common;
using BaseBackend.Domain.Constant;


namespace BaseBackend.Infrastructure
{
    public abstract class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter> where TEntity : BaseEntity, IEntity where TFilter : BaseFilter
    {
        private readonly Type _type = typeof(TEntity);
        protected readonly IUnitOfWork Uow;
        public BaseRepository(IUnitOfWork uow)
        {
            Uow = uow;
        }


        /// <summary>
        /// Hàm tìm kiếm Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (19/09/2023)
        public async Task<TEntity?> FindByIdAsync(Guid id)
        {
            // Kiểm tra xem TEntity có kế thừa từ BaseEntity không
            if (Activator.CreateInstance(_type) is BaseEntity baseEntity)
            {
                // Lấy ra TableName và IdColumnName từ BaseEntity
                var tableName = baseEntity.TableName;
                var idColumnName = baseEntity.IdColumnName;

                // Tạo câu truy vấn
                var sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = @ID";

                // Tạo param
                var param = new DynamicParameters();
                param.Add("ID", id);

                // Thực hiện truy vấn
                var result = await Uow.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param);
                return result;
            }

            // Nếu TEntity không kế thừa từ BaseEntity thì trả về null
            return null;
        }

        /// <summary>
        /// Hàm lấy ra các bản ghi theo lọc, phân trang
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// Created by: nkmdang (19/09/2023)
        public async Task<List<TEntity>> GetFilterAsync(int page, int pageSize, string? property)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Page", page, DbType.Int32);
            parameters.Add("p_PageSize", pageSize, DbType.Int32);
            parameters.Add("p_SearchProperty", property, DbType.String);
            // Thực hiện truy vấn
            var result = await Uow.Connection.QueryAsync<TEntity>($"SELECT * FROM WHERE  = @ID", parameters, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
            return result.ToList();
        }

        /// <summary>
        /// Hàm lấy thông tin Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (19/09/2023)
        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await FindByIdAsync(id);
            if (entity != null)
            {
                return entity;
            }
            throw new NotFoundException("Không tìm thấy tài nguyên", "Không tìm thấy tài nguyên", 404);
        }


        /// <summary>
        /// Hàm lấy thông tin nhiều Entity theo Id
        /// </summary>
        /// <param name="ids">Định danh của các Entity (Guid)</param>
        /// <returns>Thông tin các Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<List<TEntity>> GetByListIdAsync(List<Guid> ids)
        {
            // Lấy ra kiểu của TEntity
            var type = typeof(TEntity);

            // Kiểm tra xem TEntity có kế thừa từ BaseEntity không
            if (Activator.CreateInstance(type) is BaseEntity baseEntity)
            {
                // Lấy ra TableName và IdColumnName từ BaseEntity
                var tableName = baseEntity.TableName;
                var idColumnName = baseEntity.IdColumnName;

                // Tạo câu truy vấn
                var sql = $"SELECT * FROM {tableName} WHERE {idColumnName} IN @ID";

                // Tạo param
                var param = new DynamicParameters();
                param.Add("ID", ids);

                // Thực hiện truy vấn
                var result = await Uow.Connection.QueryAsync<TEntity>(sql, param);
                return result.ToList();
            }

            // Nếu TEntity không kế thừa từ BaseEntity thì trả về null
            return [];
        }

        /// <summary>
        /// Hàm thêm mới một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            Type type = typeof(TEntity);
            var tableName = (entity as BaseEntity)?.TableName;

            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn));

            var columns = properties.Select(p => p.GetCustomAttribute<PropertyEntity>()?.ColumnName).ToList();
            var values = properties.Select(p => $"@{p.Name}").ToList();

            string columnString = string.Join(", ", columns);
            string valueString = string.Join(", ", values);

            string sql = $"INSERT INTO {tableName} ({columnString}) VALUES ({valueString});";
            var param = new DynamicParameters();
            foreach (var property in properties)
            {
                param.Add($"@{property.Name}", property.GetValue(entity));
            }
            // Thực thi truy vấn
            var result = await Uow.Connection.QuerySingleOrDefaultAsync<TEntity>(sql, param, transaction: Uow.Transaction);

            return entity;
        }

        /// <summary>
        /// Hàm thêm mới nhiều Entity
        /// </summary>
        /// <param name="entities">Instances của Entity</param>
        /// <returns>Thông tin các Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<List<TEntity>> InsertManyAsync(List<TEntity> entities)
        {
            var listResult = new List<TEntity>();
            for (int i = 0; i < entities.Count; i++)
            {
                var result = await InsertAsync(entities[i]);
                listResult.Add(result);
            }
            return listResult;
        }


        /// <summary>
        /// Hàm sửa thông tin một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin của Entity sau khi đã thay đổi</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var param = new DynamicParameters();
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                param.Add("p_" + property.Name, property.GetValue(entity));
            }
            //// Thực thi truy vấn
            var result = await Uow.Connection.QuerySingleOrDefaultAsync<TEntity>($"Proc_Update_", param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
            return result;
        }

        /// <summary>
        /// Hàm xóa thông tin một Entity
        /// </summary>
        /// <param name="id">Định danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> DeleteAsync(Guid id)
        {
            // Tạo câu lệnh SQL
            string sql = $"SELECT * FROM WHERE  = @ID";
            var param = new DynamicParameters();
            param.Add("Id", id);
            var result = await Uow.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
            return result;
        }

        /// <summary>
        /// Hàm xóa thông tin nhiều Entity
        /// </summary>
        /// <param name="ids">Danh sách các dịnh danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            // Tạo câu lệnh SQL
            string sql = $"Proc_Delete_sByListId";

            var param = new DynamicParameters();
            var ids = entities.Select(entity => entity.GetId()).ToList();
            param.Add("ids", ids);
            var result = await Uow.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
            return result;
        }

        /// <summary>
        /// Hàm lấy ra số bản ghi thỏa mãn tiêu chí đang xem
        /// </summary>
        /// <param name="property"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> GetNumberRecordsAsync(string? property)
        {
            string sql = $"SELECT * FROM WHERE  = @ID";
            var param = new DynamicParameters();
            param.Add("p_SearchProperty", property);
            var result = await Uow.Connection.QuerySingleAsync<int>(sql, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
            return result;
        }

        public async Task<int> SoftDeleteAsync(Guid id)
        {
            if (Activator.CreateInstance(_type) is BaseEntity baseEntity)
            {
                string sql = $@"UPDATE {baseEntity.TableName} SET DELETED = {SharedResource.IsDeleted}";
                await Uow.Connection.ExecuteAsync(sql);
                return 1;
            }
            return 0;
        }
        public Task<int> SoftDeleteManyAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public abstract Task<List<TEntity>> GetPaging(PagingInfo pagingInfo, TFilter filter);
    }
}
