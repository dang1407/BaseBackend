using BaseBackend.Domain;

namespace BaseBackend.CacheManager
{
    public class UserProfile
    {
        public string? Username { get; set; }
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? RolesString { get; set; }
        public List<FunctionRight>? ListRight { get; set; }
        
    }
}
