using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public interface IPermisionRepository 
    {
        List<FunctionRight> GetAllPagePermision();
        List<string> GetPageItemPermision(int pageId, int itemId, string funcCode);
    }
}
