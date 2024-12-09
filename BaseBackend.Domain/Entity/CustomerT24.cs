using BaseBackend.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class CustomerT24 : BaseEntity
    {
        public CustomerT24() : base("accountinfo", "Id", false, false)
        {
        }

        [PropertyEntity("Id")]
        public int Id { get; set; }

        [PropertyEntity("Cif")]
        public string Cif { get; set; }

        [PropertyEntity("CustomerName")]
        public string CustomerName { get; set; }

        [PropertyEntity("AccountTitle")]
        public string AccountTitle { get; set; }

        [PropertyEntity("acctTitle")]
        public string acctTitle { get; set; }

        [PropertyEntity("Category")]
        public string Category { get; set; }

        [PropertyEntity("Currency")]
        public string Currency { get; set; }

        [PropertyEntity("WorkingBalance")]
        public string WorkingBalance { get; set; }

        [PropertyEntity("LockedAmount")]
        public string LockedAmount { get; set; }

        [PropertyEntity("PostingRestrict")]
        public string PostingRestrict { get; set; }

        [PropertyEntity("InactivMarker")]
        public string InactivMarker { get; set; }

        [PropertyEntity("Company")]
        public string Company { get; set; }

        [PropertyEntity("Message")]
        public string Message { get; set; }

        [PropertyEntity("BlockAction")]
        public bool? BlockAction { get; set; }

        [PropertyEntity("PostingRestrictDesc")]
        public string PostingRestrictDesc { get; set; }

        [PropertyEntity("PostingRestrictType")]
        public string PostingRestrictType { get; set; }

        [PropertyEntity("CustomerInfo")]
        public CultureInfo CustomerInfo { get; set; }

        [PropertyEntity("SavingInfo")]
        public SavingInfo SavingInfo { get; set; }

        [PropertyEntity("Category_Name")]
        public string Category_Name { get; set; }

        [PropertyEntity("IsPaymentAccount")]
        public bool? IsPaymentAccount { get; set; }

        public override int GetId()
        {
            return Id;
        }

        public override void SetDeleted(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void SetVersion(int version)
        {
            throw new NotImplementedException();
        }
    }
}
