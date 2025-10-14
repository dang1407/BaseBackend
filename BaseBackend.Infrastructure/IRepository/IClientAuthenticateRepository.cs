using BaseBackend.Domain.Entity.adm;

namespace BaseBackend.Infrastructure
{
    public interface IClientAuthenticateRepository
    {
        Task InsertItem(AdmClientAuthenticate item, IUnitOfWork? unitOfWork = null);
        Task<AdmClientAuthenticate?> GetItemById(int id);
        Task DeleteItemByID(int id, IUnitOfWork? unitOfWork = null);
    }
}
