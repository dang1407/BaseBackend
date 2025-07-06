
using System.Data.Common;

namespace BaseBackend.Infrastructure
{
    public interface IUnitOfWork :IDisposable, IAsyncDisposable
    {
        DbConnection Connection { get; }    
        DbTransaction? Transaction { get; }
        void BeginTransaction();
        Task BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
        void RollBack();
        Task RollBackAsync();

    }
}
 