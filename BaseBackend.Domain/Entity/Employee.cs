using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class Employee : BaseEntity
    {
        [PropertyEntity("EmployeeId")]
        public int EmployeeId { get; set; }

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

        [PropertyEntity("Version")]
        public int Version { get; set; }
        [PropertyEntity("Deleted")]
        public int Deleted {  get; set; }    
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

        public override int GetId()
        {
            return EmployeeId;
        }

        public override void SetId(int id)
        {
            EmployeeId = id;
        }

        public override void SetVersion(int version)
        {
            throw new NotImplementedException();
        }

        public override void SetDeleted(bool isDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
