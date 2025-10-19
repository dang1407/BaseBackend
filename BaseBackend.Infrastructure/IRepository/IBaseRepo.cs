using BaseBackend.Domain;

namespace BaseBackend.Infrastructure
{
    public interface IBaseRepo<TEntity, TFilter> where TEntity : BaseEntity where TFilter : BaseFilter
    {
        Task<List<TEntity>> GetPaging(TFilter filter, PagingInfo pagingInfo);
        Task<TEntity?> GetById(int id);
        Task<TEntity> InsertItem(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> UpdateItem(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> DeleteItem(int id, IUnitOfWork? unitOfWork = null);
    }
}
