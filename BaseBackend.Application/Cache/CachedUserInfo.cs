using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class CachedUserInfo
    {
        public string UserName { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        // Add any other fields as needed
    }
}
