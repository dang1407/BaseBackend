using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class Employee : BaseEntity, IEntity<Guid>
    {
        [PropertyEntity("EmployeeId")]
        public Guid EmployeeId { get; set; }

        [PropertyEntity("EmployeeCode")]
        public string? EmployeeCode { get; set; }

        [PropertyEntity("FullName")]
        public string? FullName { get; set; }
        [PropertyEntity("TitleId")]
        public Guid TitleId { get; set; }
        [PropertyEntity("Gender")]
        public Gender? Gender { get; set; }
        [PropertyEntity("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        [PropertyEntity("Address")]
        public string? Address { get; set; }
        [PropertyEntity("Mobile")]
        public string? Mobile { get; set; }
        [PropertyEntity("BankAccount")]
        public string? BankAccount { get; set; }
        [PropertyEntity("BankBranch")]
        public string? BankBranch { get; set; }
        [PropertyEntity("BankName")]
        public string? BankName { get; set; }
        [PropertyEntity("PersonalIdentification")]
        public string? PersonalIdentification { get; set; }
        [PropertyEntity("PICreatedDate")]
        public DateTime? PICreatedDate { get; set; }
        [PropertyEntity("PICreatedPlace")]
        public string? PICreatedPlace { get; set; }
        [PropertyEntity("Email")]
        public string? Email { get; set; }
        [PropertyEntity("AvatarLink")]
        public string? AvatarLink { get; set; }

        #region Extend Members
        public Guid DepartmentId { get; set; }
        public string? TitleName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyMobile { get; set; }
        public string? CompanyName { get; set; }
        #endregion
        public Employee() : base("Employee", "EmployeeId", true, true)
        {
        }

        public Guid GetId()
        {
            return EmployeeId;
        }

        public void SetId(Guid id)
        {
            EmployeeId = id;
        }
    }
}
