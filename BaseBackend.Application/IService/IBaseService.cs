using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public interface IBaseService<TEntity, TFilter> where TEntity : BaseEntity where TFilter : BaseFilter
    {
        Task<List<TEntity>> GetPaging(TFilter? filter, PagingInfo? pagingInfo);
        Task<TEntity?> GetById(int id);
        Task<TEntity> InsertItem(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> UpdateItem(TEntity item, IUnitOfWork? unitOfWork = null);
        Task<int> DeleteItem(int id, IUnitOfWork? unitOfWork = null);
    }
}
