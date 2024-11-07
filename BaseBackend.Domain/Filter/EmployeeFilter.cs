using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class EmployeeFilter : BaseFilter
    {
        public string? EmployeeCode { get; set; }
        public string? FullName { get; set; }
        public string? TitleName {  get; set; }
        public Guid? AccountId { get; set; }
    }
}
