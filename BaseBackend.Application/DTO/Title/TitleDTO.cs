using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class TitleDTO : BaseDTO
    {
        public Guid? TitleId { get; set; }
        public string TitleName { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        #region Extend Member
        public string DepartmentName { get; set; } = string.Empty;
        #endregion
    }
}
