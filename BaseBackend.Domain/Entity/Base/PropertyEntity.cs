using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public sealed class PropertyEntity(string columnName, bool isColumn = true, bool isIdentity = false) : Attribute
    {
        public string ColumnName { get; set; } = columnName;

        public bool IsIdentity { get; set; } = isIdentity;

        public bool IsColumn { get; set; } = isColumn;
    }
}
