using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class Account : BaseEntity, IEntity<Guid>
    {
        public Account() : base("account", "AccountId", true, true)
        {
        }
        [PropertyEntity("AccountId")]
        public Guid AccountId { get; set; }
        [PropertyEntity("UserName")]
        public string UserName { get; set; } = string.Empty;
        [PropertyEntity("Password")]
        public string Password { get; set; } = string.Empty;
        [PropertyEntity("Email")]
        public string Email { get; set; } = string.Empty;
        [PropertyEntity("Role")]
        public string Role { get; set; } = string.Empty;
        [PropertyEntity("CompanyId")]
        public Guid CompanyId { get; set; }
        [PropertyEntity("Version")]
        public int Version { get; set; }
        [PropertyEntity("Deleted")]
        public Guid GetId()
        {
            return AccountId;
        }

        public void SetId(Guid id)
        {
            AccountId = id;
        }
    }
}
