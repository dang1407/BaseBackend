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
    public abstract class BaseEntity(string tableName, string primaryKey, bool hasDeleted, bool hasVersion) : IDisposable
    {
        private List<string> _listChangedColumn = [];

        private string _tableName { get; set; } = tableName;

        private string _primaryKeyColumnName { get; set; } = primaryKey;


        private bool _hasVersion { get; set; } = hasVersion;
        private bool _hasDeleted { get; set; } = hasDeleted;
        public bool GetHasVersion()
        {
            return _hasVersion;
        }


        public string GetTableName()
        {
            return _tableName;
        }

        public bool GetHasDeleted()
        {
            return _hasDeleted;
        }

        public string GetPrimaryKeyColumnName()
        {
            return _primaryKeyColumnName;
        }

        protected void NotifyPropertyChanged(string columnName)
        {
            if (string.Compare(columnName, _primaryKeyColumnName) == 0) return;
            if (_listChangedColumn == null)
            {
                _listChangedColumn = new List<string> { columnName };
            }
            else if (!_listChangedColumn.Contains(columnName))
            {
                _listChangedColumn.Add(columnName);
            }
        }

        public bool CheckChangedProperty(string propertyName)
        {
            return _listChangedColumn.Contains(propertyName);
        }

        public void ClearChangedColumn()
        {
            _listChangedColumn.Clear();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<string> GetListChangeColumn()
        {
            return _listChangedColumn;
        }
    }
}
