using BaseBackend.Domain;
using BaseBackend.Domain.Entity.adm;

namespace BaseBackend.Application
{
    public interface IAuthenService 
    {
        Task<AdmClientAuthenticate> GenerateEncryptData(string path);
        string Login(string? username, string? password);
        void SignUp(adm_user user);
    }
}
