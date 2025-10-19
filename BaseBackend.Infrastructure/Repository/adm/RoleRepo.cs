using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public class RoleRepo : BaseRepository, IRoleRepo
    {
        public async Task<int> DeleteItem(int id, IUnitOfWork? unitOfWork)
        {
            return await base.DeleteItemByIdAsync<AdmRole>(id);
        }

        public async Task<AdmRole?> GetById(int id)
        {
            return await base.FindByIdAsync<AdmRole>(id);
        }

        public async Task<List<AdmRole>> GetPaging(AdmRoleFilter filter, PagingInfo pagingInfo)
        {
            string query = @"
select * from adm_role role
where role.deleted = @is_not_deleted
";
            if (!string.IsNullOrWhiteSpace(filter.code))
            {
                query += " and role.code ilike @code ";
            }

            if (!string.IsNullOrWhiteSpace(filter.name))
            {
                query += " and role.name ilike @name";
            }

            query += " order by name, role_id limit @page_size offset @offset";
            DynamicParameters param = new DynamicParameters();
            param.Add("@code", BuildLikeFilter(filter.code));
            param.Add("@name", BuildLikeFilter(filter.name));
            param.Add("@offset", pagingInfo.PageIndex * pagingInfo.PageSize);
            param.Add("@page_size", pagingInfo.PageSize);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);
            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<AdmRole>(query, param);
            return result.ToList();
        }

        public async Task<AdmRole> InsertItem(AdmRole role, IUnitOfWork? unitOfWork)
        {
            return (AdmRole)await base.InsertItemAsync<AdmRole>(role, unitOfWork);
        }

        public Task<int> UpdateItem(AdmRole role, IUnitOfWork? unitOfWork)
        {
            return base.UpdateItemAsync<AdmRole>(role, unitOfWork);
        }
    }
}
