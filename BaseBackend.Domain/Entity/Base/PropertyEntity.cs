using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public sealed class PropertyEntity : Attribute
    {
        public string ColumnName { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsColumn { get; set; }

        public PropertyEntity(string columnName, bool isColumn = true, bool isIdentity = false)
        {
            ColumnName = columnName;
            IsIdentity = isIdentity;
            IsColumn = isColumn;
        }
    }
}
