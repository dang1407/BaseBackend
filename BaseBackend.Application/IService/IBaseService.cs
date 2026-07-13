using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public interface IBaseService<TEntity, TFilter> where TEntity : BaseEntity where TFilter : BaseFilter
    {
        Task<List<TEntity>> GetPagingAsync(TFilter? filter, PagingInfo? pagingInfo);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> InsertItemAsync(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> UpdateItemAsync(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> DeleteItemAsync(int id, IUnitOfWork? unitOfWork = null);
    }
}
