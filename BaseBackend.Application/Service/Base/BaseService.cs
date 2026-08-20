using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class BaseService
    {
        private BaseRepository baseRepo = new BaseRepository();
        public async Task<TEntity?> GetItemByIDAsync<TEntity>(int? id) where TEntity : BaseEntity
        {
            return await baseRepo.FindByIdAsync<TEntity>(id);
        }
    }
}
