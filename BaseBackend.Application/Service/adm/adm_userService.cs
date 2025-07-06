using BaseBackend.CacheManager;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class adm_userService
    {
        private readonly adm_userRepository userRepository = new adm_userRepository();
        public adm_user GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public List<adm_user> GetPaging(adm_userFilter filter, PagingInfo pagingInfo) 
        {
            return userRepository.GetPaging(filter, pagingInfo);   
        }

        public adm_user? GetUserByUserName(string username)
        {
            return userRepository.GetUserByUserName(username);
        }

        public void InsertUser(adm_user user)
        {
            // Validate 
            if(string.IsNullOrWhiteSpace(user.username) || string.IsNullOrWhiteSpace(user.password)) {
                throw new ExecuteErrorException(SharedResource.InputDataInvalid);
            }
            user.created_by = CurrentUserContext.CurrentUser.username;
            user.created_time = DateTime.Now;
            userRepository.InsertItem(user);
        }

        public void UpdateUser(adm_user user) 
        {
            user.updated_time = DateTime.Now;
            user.updated_by = CurrentUserContext.CurrentUser.username;  
            int affectedRows = userRepository.UpdateItem(user);
            if (affectedRows == 0) throw new ExecuteErrorException(SharedResource.ExecuteErrorMessage);
        }

        /// <summary>
        /// Hàm dựng profile, hiện tại dựng trước roles và Right
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserProfile GenerateUserProfile(int? userId)
        {
            UserProfile profile = new UserProfile();
            profile.UserId = userId;
            if (userId == null) return profile;
            adm_user user = userRepository.GetById(userId.Value);
            profile.Username = user.username;
            profile.Email = user.email;
            profile.Phone = user.phone;
            List<adm_role> roles = userRepository.GetRolesOfEmployee(userId);
            profile.RolesString = string.Join(",", roles.Select(r => r.name));
            var userRight = userRepository.GetRightsOfEmployee(userId.Value, roles.Select(r=> r.role_id.GetValueOrDefault(0)).ToList());
            profile.ListRight = userRight;
            return profile;
        }
    }
}
