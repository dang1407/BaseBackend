using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class CachedUserManager
    {
        private readonly IMemoryCache _memoryCache;
        public CachedUserManager(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
        }

        public void CacheUserById(string id, CachedUserInfo cachedUserInfo)
        {
            _memoryCache.Set(id, cachedUserInfo);    
        }
    }
}
