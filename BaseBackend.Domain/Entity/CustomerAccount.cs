using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class CustomerAccount
    {
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public decimal AccountSurplus { get; set; }
        public decimal BlockedAmt { get; set; }
        public string Currency { get; set; }
        public string BranchCode { get; set; }
    }
}
