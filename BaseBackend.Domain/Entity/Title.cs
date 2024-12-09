using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class Title : BaseEntity
    {
        public Title() : base("Title", "TitleId", true, true)
        {
        }

        [PropertyEntity("TitleId")]
        public int TitleId { get; set; }
        [PropertyEntity("TitleName")]
        public string TitleName { get; set; } = string.Empty;
        [PropertyEntity("DepartmentId")]
        public Guid DepartmentId { get; set; }
        [PropertyEntity("Version")]
        public int Version { get; set; }
        [PropertyEntity("Deleted")]
        public bool Deleted { get; set; }    
        #region Extend Member
        public string DepartmentName { get; set; } = string.Empty;
        #endregion

        public override int GetId()
        {
            return TitleId;
        }

        public override void SetDeleted(bool isDeleted)
        {
            Deleted = isDeleted;
        }

        public override void SetId(int id)
        {
            TitleId = id;
        }

        public override void SetVersion(int version)
        {
            Version = version;
        }
    }
}
