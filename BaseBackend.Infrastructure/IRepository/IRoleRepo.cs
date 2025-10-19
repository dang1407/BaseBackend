using BaseBackend.Domain;

namespace BaseBackend.Infrastructure
{
    public interface IRoleRepo : IBaseRepo<AdmRole, AdmRoleFilter>
    {
    }
}
