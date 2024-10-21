using BaseBackend.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public static class Util
    {
        public static CachedUserInfo GetUserInforFromRequest(HttpContext context)
        {
            CachedUserInfo userInfo = new CachedUserInfo();
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                var accountId = context.User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value;
                var role = context.User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
                var fullName = context.User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
                var userName = context.User.Claims.FirstOrDefault(c => c.Type == "UserName")?.Value;
                if (!string.IsNullOrWhiteSpace(accountId))
                {
                    userInfo = new CachedUserInfo
                    {
                        AccountId = accountId,
                        UserName = userName ?? "",
                        FullName = fullName ?? "",
                        Role = role ?? ""
                    };
                }
            }
            return userInfo;
        }
    }
}
