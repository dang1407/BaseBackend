using BaseBackend.Domain.Entity.adm;

namespace BaseBackend.Infrastructure
{
    public class ClientAuthenticateRepository : BaseRepository, IClientAuthenticateRepository
    {
        public async Task<AdmClientAuthenticate?> GetItemById(int id)
        {
            return await  base.FindByIdAsync<AdmClientAuthenticate>(id);
        }

        public async Task InsertItem(AdmClientAuthenticate item, IUnitOfWork? unitOfWork = null)
        {
            await base.InsertItemAsync<AdmClientAuthenticate>(item, unitOfWork);
        }

        public async Task DeleteItemByID(int id, IUnitOfWork? unitOfWork = null)
        {
            await base.DeleteItemByIdAsync<AdmClientAuthenticate>(id, unitOfWork);
        }
    }
}
