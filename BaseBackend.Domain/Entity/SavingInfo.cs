using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain.Entity
{
    public class SavingInfo
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Currency { get; set; }

        public string SerialNo { get; set; }

        public string Term { get; set; }

        public string Rate { get; set; }

        public string Margin { get; set; }

        public string ValueDate { get; set; }

        public string MatDate { get; set; }

        public string Payout { get; set; }

        public string PayMethod { get; set; }
        public string RollMethod { get; set; }
        public string InterestAmt { get; set; }
        public string SavingStatus { get; set; }
    }

}
