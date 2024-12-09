using BaseBackend.Domain.Entity;
using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class CustomerT24DTO : BaseDTO
    {
        public string Id { get; set; }
        public string Cif { get; set; }
        public string CustomerName { get; set; }
        public string AccountTitle { get; set; }
        public string acctTitle { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public string WorkingBalance { get; set; }
        public string LockedAmount { get; set; }
        public string PostingRestrict { get; set; }
        public string InactivMarker { get; set; }
        public string Company { get; set; }
        public string Message { get; set; }
        public bool? BlockAction { get; set; }
        public string PostingRestrictDesc { get; set; }
        public string PostingRestrictType { get; set; }
        public CustomerInfoRes CustomerInfo { get; set; }
        public SavingInfo SavingInfo { get; set; }
        public string Category_Name { get; set; }
        public bool? IsPaymentAccount { get; set; }
    }
}
