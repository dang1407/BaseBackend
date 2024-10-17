using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class EmployeeDTO : BaseDTO
    {
        public Guid EmployeeId { get; set; }

        public string? EmployeeCode { get; set; }

        public string? FullName { get; set; }
        public Guid TitleId { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? BankAccount { get; set; }
        public string? BankBranch { get; set; }
        public string? BankName { get; set; }
        public string? PersonalIdentification { get; set; }
        public DateTime? PICreatedDate { get; set; }
        public string? PICreatedPlace { get; set; }
        public string? Email { get; set; }
        public string? AvatarLink { get; set; }
        public Guid DepartmentId { get; set; }

        #region Extend Members
        public string? TitleName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyMobile { get; set; }
        public string? CompanyName { get; set; }
        #endregion
    }
}
