using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class Title : BaseEntity, IEntity<Guid>
    {
        public Title() : base("Title", "TitleId", true, true)
        {
        }

        [PropertyEntity("TitleId")]
        public Guid TitleId { get; set; }
        [PropertyEntity("TitleName")]
        public string TitleName { get; set; } = string.Empty;
        [PropertyEntity("DepartmentId")]
        public Guid DepartmentId { get; set; }
        [PropertyEntity("Version")]
        public int Version { get; set; }
        [PropertyEntity("Deleted")]
        #region Extend Member
        public string DepartmentName { get; set; } = string.Empty;
        #endregion
        public Guid GetId()
        {
            return TitleId;
        }

        public void SetId(Guid id)
        {
            TitleId = id;
        }
    }
}
