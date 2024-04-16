
using System.Data.Common;

namespace BaseBackend.Application
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
 