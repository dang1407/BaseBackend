using BaseBackend.Domain;

namespace BaseBackend.Infrastructure
{
    public interface IBaseRepo<TEntity, TFilter> where TEntity : BaseEntity where TFilter : BaseFilter
    {
        Task<List<TEntity>> GetPagingAsync(TFilter? filter, PagingInfo? pagingInfo);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> InsertItemAsync(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> UpdateItemAsync(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> DeleteItemAsync(TEntity item, IUnitOfWork? unitOfWork = null);
    }
}
