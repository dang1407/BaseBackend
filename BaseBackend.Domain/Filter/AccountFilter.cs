using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class AccountFilter : BaseFilter
    {
        public Guid AccountId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
