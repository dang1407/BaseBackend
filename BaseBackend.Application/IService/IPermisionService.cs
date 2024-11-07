using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public interface IPermisionService
    {
        public List<FunctionRight> GetAllPagePermisions();
        public void CheckPagePermisions(int pageId, string funcCode);
        public List<string> GetItemPermisions(int pageId, int itemId, string funcCode);
    }
}
