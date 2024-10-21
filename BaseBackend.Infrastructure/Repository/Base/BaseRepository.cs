using Dapper;
using System.Data;
using System.Reflection;
using BaseBackend.Application;
using BaseBackend.Domain;
using System.Data.Common;
using BaseBackend.Domain.Constant;


namespace BaseBackend.Infrastructure
{
    public abstract class BaseRepository<TEntity, TFilter, TIdKey> : IBaseRepository<TEntity, TFilter, TIdKey> where TEntity : BaseEntity, IEntity<TIdKey> where TFilter : BaseFilter
    {
        private readonly Type _type = typeof(TEntity);
        private BaseEntity _entity;
        private List<PropertyInfo> _propertyInfo = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn)).ToList();
        protected readonly IUnitOfWork Uow;
        public BaseRepository(IUnitOfWork uow)
        {
            Uow = uow;
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
        /// Hàm tìm kiếm Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (19/09/2023)
        public async Task<TEntity?> FindByIdAsync(TIdKey id)
        {
            // Lấy ra TableName và IdColumnName từ BaseEntity
            var tableName = _entity.TableName;
            var idColumnName = _entity.IdColumnName;

            // Tạo câu truy vấn
            var sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = @ID";

            // Tạo param
            var param = new DynamicParameters();
            param.Add("ID", id);

            // Thực hiện truy vấn
            var result = await Uow.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param);
            return result;
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
        public virtual async Task<TEntity> GetByIdAsync(TIdKey id)
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
        public async Task<List<TEntity>> GetByListIdAsync(List<TIdKey> ids) 
        {

            // Lấy ra TableName và IdColumnName từ BaseEntity
            var tableName = _entity.TableName;
            var idColumnName = _entity.IdColumnName;

            // Tạo câu truy vấn
            var sql = $"SELECT * FROM {tableName} WHERE {idColumnName} IN @ID";

            // Tạo param
            var param = new DynamicParameters();
            param.Add("ID", ids);

            // Thực hiện truy vấn
            var result = await Uow.Connection.QueryAsync<TEntity>(sql, param);
            return result.ToList();
        }

        /// <summary>
        /// Hàm thêm mới một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var tableName = (entity as BaseEntity)?.TableName;

            var columns = _propertyInfo.Select(p => p.GetCustomAttribute<PropertyEntity>()?.ColumnName).ToList();
            var values = _propertyInfo.Select(p => $"@{p.Name}").ToList();

            string columnString = string.Join(", ", columns);
            string valueString = string.Join(", ", values);

            string sql = $"INSERT INTO {_entity.TableName} ({columnString}) VALUES ({valueString});";
            var param = new DynamicParameters();
            foreach (var property in _propertyInfo)
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
            var tableName = (entities.FirstOrDefault() as BaseEntity)?.TableName;

            // Prepare columns and values
            var columns = _propertyInfo.Select(p => p.GetCustomAttribute<PropertyEntity>()?.ColumnName).ToList();
            var columnString = string.Join(", ", columns);

            var valuesList = new List<string>();
            var param = new DynamicParameters();

            // Iterate through entities
            int index = 0;
            foreach (var entity in entities)
            {
                // Prepare value placeholders for each entity
                var valuePlaceholders = _propertyInfo.Select(p => $"@{p.Name}{index}").ToList();
                valuesList.Add($"({string.Join(", ", valuePlaceholders)})");

                // Add parameters for the current entity
                foreach (var property in _propertyInfo)
                {
                    param.Add($"@{property.Name}{index}", property.GetValue(entity));
                }
                index++;
            }

            string valueString = string.Join(", ", valuesList);
            string sql = $"INSERT INTO {tableName} ({columnString}) VALUES {valueString};";

            // Execute the query
            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return entities;
        }


        /// <summary>
        /// Hàm sửa thông tin một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin của Entity sau khi đã thay đổi</returns>
        /// Created by: nkmdang (20/09/2023)
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            // Lấy tên bảng
            var tableName = (entity as BaseEntity)?.TableName;

            var idValue = entity.GetId();
            

            // Lấy danh sách các cột cần update, trừ Id và Version
            var columns = _propertyInfo
                .Where(p => p.Name != "Id" && p.Name != "Version")
                .Select(p => $"{p.GetCustomAttribute<PropertyEntity>()?.ColumnName} = @{p.Name}")
                .ToList();

            string setClause = string.Join(", ", columns);

            // Tạo câu lệnh SQL Update có kiểm tra version
            string query = $@"
        UPDATE {tableName}
        SET {setClause}, Version = Version + 1
        WHERE Id = @Id ";
            if (entity.HasVersion)
            {
                query += " \n AND Version = @Version";
            }

            var param = new DynamicParameters();
            foreach (var property in _propertyInfo)
            {
                param.Add($"@{property.Name}", property.GetValue(entity));
            }
            var versionProperty = _propertyInfo.FirstOrDefault(p => p.Name == "Version");
            var versionValue = versionProperty.GetValue(entity);
            // Thêm Id và Version vào param
            param.Add("@Id", idValue);
            param.Add("@Version", versionValue);

            // Thực thi truy vấn và kiểm tra xem có hàng nào bị ảnh hưởng (update thành công)
            var affectedRows = await Uow.Connection.ExecuteAsync(query, param, transaction: Uow.Transaction);

            // Nếu không có hàng nào bị update (có thể do version không khớp)
            if (affectedRows == 0)
            {
                throw new InvalidException(SharedResource.ItemHasBeenChanged);
            }
            // Trả về entity
            return entity;
        }

        /// <summary>
        /// Hàm xóa thông tin một Entity
        /// </summary>
        /// <param name="id">Định danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> DeleteAsync(TIdKey id)
        {
            // Tạo câu lệnh SQL
            if (Activator.CreateInstance(_type) is BaseEntity _entity)
            {
                string sql = $"DELETE FROM {_entity.TableName} WHERE {_entity.IdColumnName} = @ID";
                var param = new DynamicParameters();
                param.Add("Id", id);
                var result = await Uow.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
                return result;
            }
            throw new InvalidException("Entity không phải BaseEntity");
        }

        /// <summary>
        /// Hàm xóa thông tin nhiều Entity
        /// </summary>
        /// <param name="ids">Danh sách các dịnh danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        public async Task<int> DeleteManyAsync(List<TIdKey> ids)
        {
            // Tạo câu lệnh SQL
            string sql = $"DELETE FROM {_entity.TableName} WHERE {_entity.IdColumnName} IN @IDS";

            var param = new DynamicParameters();
            param.Add("@IDS", ids);
            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);
            return result;
        }

        public async Task<int> SoftDeleteAsync(TIdKey id)
        {
            string sql = $@"UPDATE {_entity.TableName} SET DELETED = {SharedResource.IsDeleted} WHERE {_entity.IdColumnName} = @Id";
            var param = new DynamicParameters();
            param.Add("@Id", id);
            int affectRow = await Uow.Connection.ExecuteAsync(sql, transaction: Uow.Transaction);
            return affectRow;
        }
        public async Task<int> SoftDeleteManyAsync(List<TIdKey> ids)
        {
            string sql = $@"UPDATE {_entity.TableName} SET DELETED = {SharedResource.IsDeleted} WHERE {_entity.IdColumnName} IN @Id";
            var param = new DynamicParameters();
            param.Add("@Id", ids);
            int affectRow = await Uow.Connection.ExecuteAsync(sql, transaction: Uow.Transaction);
            return affectRow;
        }

        public abstract Task<List<TEntity>> GetPaging(PagingInfo pagingInfo, TFilter filter);

        public virtual async Task<int> UpdateManyAsync(List<TEntity> entities)
        {
            var tableName = (entities.FirstOrDefault() as BaseEntity)?.TableName;

            // Prepare columns for update
            var columns = _propertyInfo.Select(p => p.GetCustomAttribute<PropertyEntity>()?.ColumnName).ToList();

            var param = new DynamicParameters();
            var updateQueries = new List<string>();

            // Iterate through entities
            int index = 0;
            foreach (var entity in entities)
            {
                var setClauses = new List<string>();

                // Prepare SET clause for each property
                foreach (var property in _propertyInfo)
                {
                    var columnName = property.GetCustomAttribute<PropertyEntity>()?.ColumnName;
                    if (!string.IsNullOrEmpty(columnName))
                    {
                        setClauses.Add($"{columnName} = @{property.Name}{index}");
                        param.Add($"@{property.Name}{index}", property.GetValue(entity));
                    }
                }

                // Assuming there's a primary key for where clause, e.g., "Id" column
                var primaryKey = _entity.IdColumnName;
                var primaryKeyValue = _propertyInfo.FirstOrDefault(p => p.Name == primaryKey)?.GetValue(entity);
                param.Add($"@{primaryKey}{index}", primaryKeyValue);

                // Construct the update query for the current entity
                var setClauseString = string.Join(", ", setClauses);
                updateQueries.Add($"UPDATE {tableName} SET {setClauseString} WHERE {primaryKey} = @{primaryKey}{index};");

                index++;
            }

            // Join all update queries
            var sql = string.Join(" \n", updateQueries);

            // Execute the query
            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return result;
        }
    }
}
