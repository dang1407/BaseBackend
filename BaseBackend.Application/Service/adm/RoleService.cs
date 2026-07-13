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

        public async Task<int> DeleteItemAsync(int id, IUnitOfWork? unitOfWork = null)
        {
            AdmRole? item = await GetByIdAsync(id);
            if (item == null) throw new NotFoundException();
            return await _roleRepo.DeleteItemAsync(item, unitOfWork);
        }

        public async Task<AdmRole?> GetByIdAsync(int id)
        {
            return await _roleRepo.GetByIdAsync(id);
        }

        public async Task<List<AdmRole>> GetPagingAsync(AdmRoleFilter? filter, PagingInfo? pagingInfo)
        {
            if(filter == null)
                filter = new AdmRoleFilter();
            if(pagingInfo == null)
                pagingInfo = new PagingInfo();
            return await _roleRepo.GetPagingAsync(filter, pagingInfo);
        }

        public Task<AdmRole> InsertItemAsync(AdmRole item, IUnitOfWork? unitOfWork = null)
        {
            item.version = SharedResource.FirstVersion;
            item.deleted = SharedResource.IsNotDeleteInt;
            item.created_by = UserContext.CurrentUser.UserId;
            item.created_time = DateTime.Now;
            return _roleRepo.InsertItemAsync(item, unitOfWork);
        }

        public Task<int> UpdateItemAsync(AdmRole item, IUnitOfWork? unitOfWork = null)
        {
            item.updated_by = UserContext.CurrentUser.UserId;
            item.updated_time = DateTime.Now;
            return _roleRepo.UpdateItemAsync(item, unitOfWork);
        }
    }
}
