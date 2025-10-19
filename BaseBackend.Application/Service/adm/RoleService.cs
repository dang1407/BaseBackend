using BaseBackend.CacheManager;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        public RoleService(IRoleRepo roleRepo) 
        {
            _roleRepo = roleRepo;
        }

        public async Task<int> DeleteItem(int id, IUnitOfWork? unitOfWork = null)
        {
            return await _roleRepo.DeleteItem(id, unitOfWork);
        }

        public async Task<AdmRole?> GetById(int id)
        {
            return await _roleRepo.GetById(id);
        }

        public async Task<List<AdmRole>> GetPaging(AdmRoleFilter? filter, PagingInfo? pagingInfo)
        {
            if(filter == null)
                filter = new AdmRoleFilter();
            if(pagingInfo == null)
                pagingInfo = new PagingInfo();
            return await _roleRepo.GetPaging(filter, pagingInfo);
        }

        public Task<AdmRole> InsertItem(AdmRole item, IUnitOfWork? unitOfWork = null)
        {
            item.version = SharedResource.FirstVersion;
            item.deleted = SharedResource.IsNotDeleteInt;
            item.created_by = UserContext.CurrentUser.UserId;
            item.created_time = DateTime.Now;
            return _roleRepo.InsertItem(item, unitOfWork);
        }

        public Task<int> UpdateItem(AdmRole item, IUnitOfWork? unitOfWork = null)
        {
            item.updated_by = UserContext.CurrentUser.UserId;
            item.updated_time = DateTime.Now;
            return _roleRepo.UpdateItem(item, unitOfWork);
        }
    }
}
