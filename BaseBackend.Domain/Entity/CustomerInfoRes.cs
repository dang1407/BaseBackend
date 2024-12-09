using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class CustomerInfoRes
    {
        public string CIF { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public string TaxId { get; set; }
        public string Company { get; set; }
        public string CustomerStatus { get; set; }
        public string Industry { get; set; }
        public string Target { get; set; }
        public string CustomerType { get; set; }
        public string Residence { get; set; }
        public string Nationality { get; set; }
        public string IdentifyMethod { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string IdentType { get; set; }
        public string IdentNo { get; set; }
        public string IdentDate { get; set; }
        public string IdentExpDate { get; set; }
        public string IdentPlace { get; set; }
        public string PhoneNumber { get; set; }
        public string PostingRestrict { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
        public string IdNum { get; set; }
        public string IssueDate { get; set; }
        public string PlaceOfIssue { get; set; }
        public CustomerAccount Account { get; set; }
        public List<CustomerAccount> ListAccount { get; set; }
        public int CustomerSectorType { get; set; }
        public string CustomerSectorName { get; set; }
        public string Message { get; set; }
        public bool? BlockAction { get; set; }
        public string PostingRestrictDesc { get; set; }
        public string PostingRestrictType { get; set; }
    }
}
