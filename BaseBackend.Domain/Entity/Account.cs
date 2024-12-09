using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class Account : BaseEntity
    {
        public Account() : base("account", "AccountId", true, true)
        {
        }
        [PropertyEntity("AccountId")]
        public int AccountId { get; set; }
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
        public override int GetId()
        {
            return AccountId;
        }

        public override void SetDeleted(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public override void SetId(int id)
        {
            AccountId = id;
        }

        public override void SetVersion(int version)
        {
            throw new NotImplementedException();
        }
    }
}
