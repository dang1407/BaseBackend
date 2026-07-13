using BaseBackend.Domain;
using BaseBackend.Domain.Filter;

namespace BaseBackend.Infrastructure.IRepository
{
    public interface IAdmRightRepo : IBaseRepo<AdmRight, AdmRightFilter>
    {
    }
}
