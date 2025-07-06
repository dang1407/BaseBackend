using BaseBackend.Application;
using BaseBackend.Application.Cache;
using BaseBackend.CacheManager;
using BaseBackend.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace BaseBackend.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                string? userIdString = jwtToken.Claims.FirstOrDefault(c => c.Type == adm_user.C_user_id)?.Value;
                int userId = 0;
                Int32.TryParse(userIdString, out userId);
                var username = jwtToken.Claims.FirstOrDefault(c => c.Type == adm_user.C_username)?.Value;
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                UserProfile? cachedUser = ProfileCacheManager.GetUserProfile(userId);

                // Nếu chưa có profile thì dựng profile
                if (cachedUser == null)
                {
                    adm_userService userService = new adm_userService();
                    cachedUser = userService.GenerateUserProfile(userId);
                    ProfileCacheManager.AddOrUpdateUser(cachedUser);
                }
                // Gán profile vào UserContext để gọi ở bất cứ đâu
                UserContext.Current = cachedUser;
            }

            await _next(context);
        }
    }

}
