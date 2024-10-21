using BaseBackend.Application;
using Microsoft.Extensions.Caching.Memory;

namespace BaseBackend.Middleware
{
    public class UserCacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;

        public UserCacheMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request is authenticated
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                var accountId = context.User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value;
                var role = context.User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
                var fullName = context.User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
                var userName = context.User.Claims.FirstOrDefault(c => c.Type == "UserName")?.Value;
                if (!string.IsNullOrEmpty(accountId))
                {
                    // Check if user information is already cached
                    if (!_cache.TryGetValue(accountId, out CachedUserInfo? userInfo))
                    {
                        // If not cached, create new user info object
                        userInfo = new CachedUserInfo
                        {
                            AccountId = accountId,
                            // Other claims you might need
                            UserName = userName ?? "",
                            FullName = fullName ?? "",
                            Role = role ?? ""
                        };

                        // Cache the user info for a duration
                        var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));
                        _cache.Set(accountId, userInfo, cacheOptions);
                    }

                    // Attach user info to HttpContext for later use in other layers
                    context.Items[$"{accountId}"] = userInfo;
                }
            }

            // Call the next middleware
            await _next(context);
        }
    }

}
