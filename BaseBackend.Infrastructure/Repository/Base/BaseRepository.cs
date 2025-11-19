using BaseBackend.CacheManager;
using BaseBackend.Domain;
using Dapper;
using System.Reflection;

namespace BaseBackend.Infrastructure
{
    public class BaseRepository
    {
        #region Truy vấn phân trang 
        public async Task<List<TEntity>> GetPagingAsync<TEntity>(string query, DynamicParameters param, PagingInfo pagingInfo)
        {
            query += $" \n LIMIT {pagingInfo.PageSize} OFFSET {pagingInfo.PageIndex * pagingInfo.PageSize}";
            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<TEntity>(query, param);
            return [.. result];
        }
        #endregion
        public (string query, DynamicParameters param, PropertyInfo? idProperty) GetDataForInsert<TEntity>(BaseEntity entity) where TEntity : BaseEntity
        {
            var tableName = entity.GetTableName();
            List<PropertyInfo> _propertyInfo = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn)).ToList();
            List<string> columns = _propertyInfo.Where(p =>
            {
                PropertyEntity? pe = p.GetCustomAttribute<PropertyEntity>();
                if (pe == null) return false;
                if (pe.IsColumn && !pe.IsIdentity) return true;
                else return false;
            }
            ).Select(p => p.Name).ToList();
            var values = _propertyInfo.Where(p =>
            {
                PropertyEntity? pe = p.GetCustomAttribute<PropertyEntity>();
                if (pe == null) return false;
                if (pe.IsColumn && !pe.IsIdentity) return true;
                else return false;
            }).Select(p => $"@{p.Name}").ToList();
            string columnString = string.Join(", ", columns);
            string valueString = string.Join(", ", values);

            PropertyInfo? idProperty = _propertyInfo.Where(p => p.GetCustomAttribute<PropertyEntity>()?.IsIdentity == true).FirstOrDefault();
            if (idProperty == null)
            {
                throw new Exception("Entity must have an identity column.");
            }
            string query = $"insert into {tableName} ({columnString}) values ({valueString}) returning {idProperty?.Name};";
            var param = new DynamicParameters();
            foreach (var property in _propertyInfo)
            {
                param.Add($"@{property.Name}", property.GetValue(entity));
            }
            return (query, param, idProperty);
        }
        public async Task<BaseEntity> InsertItemAsync<TEntity>(BaseEntity entity, IUnitOfWork? unitOfWork) where TEntity : BaseEntity
        {
            var data = GetDataForInsert<TEntity>(entity);
            int id;
            // Thực thi truy vấn
            if (unitOfWork != null)
            {
                id = await unitOfWork.Connection.ExecuteScalarAsync<int>(data.query, data.param, transaction: unitOfWork.Transaction);
            }
            else
            {
                using UnitOfWork unitOfWorkLocal = new UnitOfWork();
                id = await unitOfWorkLocal.Connection.ExecuteScalarAsync<int>(data.query, data.param, transaction: unitOfWorkLocal.Transaction);
            }
            data.idProperty?.SetValue(entity, id);
            return entity;
        }

        public BaseEntity InsertItem<TEntity>(TEntity entity, IUnitOfWork unitOfWork) where TEntity : BaseEntity
        {
            var data = GetDataForInsert<TEntity>(entity);
            int id;
            // Thực thi truy vấn
            if (unitOfWork != null)
            {
                id = unitOfWork.Connection.ExecuteScalar<int>(data.query, data.param, transaction: unitOfWork.Transaction);
            }
            else
            {
                using UnitOfWork unitOfWorkLocal = new UnitOfWork();
                id = unitOfWorkLocal.Connection.ExecuteScalar<int>(data.query, data.param, transaction: unitOfWorkLocal.Transaction);
            }
            data.idProperty?.SetValue(entity, id);
            return entity;
        }

        public async Task<int> UpdateItemAsync<TEntity>(TEntity entity, IUnitOfWork? unitOfWork = null) where TEntity : BaseEntity
        {
            var tableName = entity.GetTableName();
            List<PropertyInfo> _propertyInfo = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn && !a.IsIdentity)).ToList();
            List<string> listUpdateState = [];
            entity.GetListChangeColumn().ForEach(changeColName =>
            {
                if (string.Compare(changeColName, "version", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return;
                }
                listUpdateState.Add($"{changeColName} = @{changeColName}");
            });
            if (listUpdateState.Count > 0 && entity.GetHasVersion())
            {
                listUpdateState.Add("version = version + 1");
            }
            string updateState = string.Join(", ", listUpdateState);
            string query = $"update {tableName} set {updateState} where {entity.GetPrimaryKeyColumnName()} = @{entity.GetPrimaryKeyColumnName()}";

            if (entity.GetHasVersion() == true)
            {
                query += " and version = @version returning version";
            }

            var param = new DynamicParameters();
            foreach (var property in _propertyInfo)
            {
                param.Add($"@{property.Name}", property.GetValue(entity));
            }
            int affectedRows = 0;
            int version = -1;
            if (unitOfWork != null)
            {
                version = await unitOfWork.Connection.ExecuteScalarAsync<int>(query, param, transaction: unitOfWork.Transaction);
            }
            else
            {
                using UnitOfWork localUnitOfWork = new UnitOfWork();
                version = await localUnitOfWork.Connection.ExecuteScalarAsync<int>(query, param, transaction: localUnitOfWork.Transaction);
            }
            affectedRows = version > 0 ? 1 : 0;

            if (entity.GetHasVersion() == true)
            {
                var propertyVersion = _propertyInfo.Where(props => string.Compare(props.Name, "version", StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
                if (propertyVersion != null)
                {
                    propertyVersion.SetValue(entity, version);
                }
            }
            return affectedRows;
        }

        public int UpdateItem<TEntity>(TEntity entity, IUnitOfWork unitOf) where TEntity : BaseEntity
        {
            var tableName = entity.GetTableName();
            List<PropertyInfo> _propertyInfo = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn)).ToList();
            List<string> listUpdateState = [];
            entity.GetListChangeColumn().ForEach(changeColName =>
            {
                if (string.Compare(changeColName, "version", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return;
                }
                listUpdateState.Add($"{changeColName} = @{changeColName}");
            });
            if (listUpdateState.Count > 0 && entity.GetHasVersion())
            {
                listUpdateState.Add("version = version + 1");
            }
            string updateState = string.Join(", ", listUpdateState);
            string query = $"update {tableName} set {updateState} where {entity.GetPrimaryKeyColumnName()} = @{entity.GetPrimaryKeyColumnName()}";

            var param = new DynamicParameters();
            foreach (var property in _propertyInfo)
            {
                param.Add($"@{property.Name}", property.GetValue(entity));
            }

            //using UnitOfWork unitOf = new();
            int affectedRows = unitOf.Connection.Execute(query, param, transaction: unitOf.Transaction);
            return affectedRows;
        }
        public async Task<int> UpdateItemByColumnName<TEntity>(BaseEntity entity, string colName, string colValue) where TEntity : BaseEntity
        {
            var tableName = entity.GetTableName();
            List<string> listUpdateColumnName = entity.GetListChangeColumn();
            List<PropertyInfo> _propertyInfo = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn && listUpdateColumnName.Contains(a.ColumnName))).ToList();
            List<string> listUpdateState = [];
            listUpdateColumnName.ForEach(changeColName =>
            {
                listUpdateState.Add($"{changeColName} = @{changeColName}");
            });
            if (listUpdateState.Count > 0 && entity.GetHasVersion())
            {
                listUpdateState.Add("version = version + 1");
            }
            string updateState = string.Join(", ", listUpdateState);
            string query = $"update {tableName} set {updateState} where {colName} = @where_value";

            var param = new DynamicParameters();
            foreach (var property in _propertyInfo)
            {
                param.Add($"@{property.Name}", property.GetValue(entity));
            }
            param.Add("@where_value", colValue);
            using UnitOfWork unitOf = new();
            int affectedRows = await unitOf.Connection.ExecuteAsync(query, param, transaction: unitOf.Transaction);
            if (affectedRows == 0) throw new ExecuteErrorException("Update entity failed!");
            return affectedRows;
        }

        public async Task<int> DeleteItemByColumnName<TEntity>(BaseEntity entity, string colName, string colValue, IUnitOfWork? unitOfWork = null) where TEntity : BaseEntity
        {
            var tableName = entity.GetTableName();
            string query = "";
            if (entity.GetHasDeleted())
            {
                query = $"update {tableName} set deleted = 1 where {colName} = @where_value";
            }
            else
            {
                query = $"delete from {tableName} where {colName} = @where_value";

            }
            var param = new DynamicParameters();
            var profile = UserContext.CurrentUser;
            param.Add("@where_value", colValue);
            param.Add("@updated_by", profile.UserId);
            param.Add("@updated_time");
            using UnitOfWork unitOf = new();
            int affectedRows = 0;
            if (unitOfWork != null)
            {
                affectedRows = await unitOfWork.Connection.ExecuteAsync(query, param, transaction: unitOfWork.Transaction);
            }
            else
            {
                using UnitOfWork localUnitOfWork = new UnitOfWork();
                affectedRows = await localUnitOfWork.Connection.ExecuteAsync(query, param, transaction: localUnitOfWork.Transaction);
            }
            if (affectedRows == 0) throw new ExecuteErrorException("Delete entity failed!");
            return affectedRows;
        }

        public async Task<int> DeleteItemByIdAsync<TEntity>(object id, IUnitOfWork? unitOfWork = null) where TEntity : BaseEntity
        {
            BaseEntity _entity = CreateBaseEntityNewInstance<TEntity>();
            var tableName = _entity.GetTableName();
            string query = "";
            if (_entity.GetHasDeleted())
            {
                query = $"update {tableName} set deleted = @is_deleted where {_entity.GetPrimaryKeyColumnName()} = @id";
            }
            else
            {
                query = $"delete from {tableName} where {_entity.GetPrimaryKeyColumnName()} = @id";
            }
            var param = new DynamicParameters();
            var profile = UserContext.CurrentUser;
            param.Add("@id", id);
            param.Add("@updated_by", profile.UserId);
            param.Add("@updated_time");
            param.Add("@is_deleted", SharedResource.IsDeletedInt);
            int affectedRows = 0;
            if (unitOfWork != null)
            {
                affectedRows = await unitOfWork.Connection.ExecuteAsync(query, param, transaction: unitOfWork.Transaction);
            }
            else
            {
                using UnitOfWork localUnitOfWork = new UnitOfWork();
                affectedRows = await localUnitOfWork.Connection.ExecuteAsync(query, param, transaction: localUnitOfWork.Transaction);
            }
            // Tạm thời xóa ko được thì ko throw lỗi với trường hợp xóa hẳn
            if (affectedRows == 0 && _entity.GetHasDeleted() == false) throw new ExecuteErrorException("Delete entity failed!");
            return affectedRows;
        }

        /// <summary>
        /// Hàm tìm kiếm Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (19/09/2023)
        public async Task<TEntity?> FindByIdAsync<TEntity>(object id) where TEntity : BaseEntity
        {
            BaseEntity _entity = CreateBaseEntityNewInstance<TEntity>();
            // Lấy ra TableName và IdColumnName từ BaseEntity
            var tableName = _entity.GetTableName();
            string idColumnName = "";
            PropertyInfo? idPropertyInfo = (typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn && a.IsIdentity))?.FirstOrDefault()) ?? throw new InvalidInputException($"Entity {tableName} không có Id property");
            idColumnName = idPropertyInfo.Name;
            // Tạo câu truy vấn
            var query = $"select * from {tableName} where {idColumnName} = @id";

            // Tạo param
            var param = new DynamicParameters();
            param.Add("@id", id);

            // Thực hiện truy vấn
            using UnitOfWork unitOfWork = new();
            var result = await unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(query, param);
            return result;
        }

        public TEntity? FindById<TEntity>(object id) where TEntity : BaseEntity
        {
            BaseEntity _entity = CreateBaseEntityNewInstance<TEntity>();
            // Lấy ra TableName và IdColumnName từ BaseEntity
            var tableName = _entity.GetTableName();
            string idColumnName = "";
            PropertyInfo? idPropertyInfo = (typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(PropertyEntity), false)
                .Cast<PropertyEntity>()
                .Any(a => a.IsColumn && a.IsIdentity))?.FirstOrDefault()) ?? throw new InvalidInputException($"Entity {tableName} không có Id property");
            idColumnName = idPropertyInfo.Name;
            // Tạo câu truy vấn
            var query = $"select * from {tableName} where {idColumnName} = @id";

            // Tạo param
            var param = new DynamicParameters();
            param.Add("@id", id);

            // Thực hiện truy vấn
            using UnitOfWork unitOfWork = new();
            var result = unitOfWork.Connection.QueryFirstOrDefault<TEntity>(query, param);
            return result;
        }

        public BaseEntity CreateBaseEntityNewInstance<T>() where T : BaseEntity
        {
            return (BaseEntity)(object)Activator.CreateInstance<T>();
        }


        #region Nhóm function bổ trợ truy vấn
        protected string BuildInCondition(List<int> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
            {
                return "null";
            }
            else
            {
                return string.Join(", ", lstValue.ToArray());
            }
        }

        protected string? BuildLikeFilter(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return string.Format("%{0}%", value);
            }
            else return null;
        }
        #endregion
    }
}
