using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{

    /// <summary>
    /// Lớp abstract chứa các thuộc tính chung của Entity
    /// </summary>
    public abstract class BaseEntity
    {
        public string? TableName { get; set; }
        public string IdColumnName { get; set; }
        public bool HasDeleted { get; set; }
        public bool HasVersion { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        [PropertyEntity("CreatedDate")]
        public DateTimeOffset? CreatedDate { get; set; }


        /// <summary>
        /// Người tạo
        /// </summary>
        [PropertyEntity("CreatedBy")]
        public string CreatedBy { get; set; }


        /// <summary>
        /// Ngày sửa
        /// </summary>
        [PropertyEntity("ModifiedDate")]
        public DateTimeOffset? ModifiedDate { get; set; }


        /// <summary>
        /// Người sửa
        /// </summary>
        [PropertyEntity("ModifiedBy")]
        public string ModifiedBy { get; set; }
        public BaseEntity(string tableName, string idColumnName, bool hasDeleted = true, bool hasVersion = true)
        {
            TableName = tableName;
            IdColumnName = idColumnName;
            HasDeleted = hasDeleted;
            HasVersion = hasVersion;
        }

        public abstract void SetId(int id);
        public abstract int GetId();

        public abstract void SetVersion(int version);
        public abstract void SetDeleted(bool isDeleted);
    }
}
