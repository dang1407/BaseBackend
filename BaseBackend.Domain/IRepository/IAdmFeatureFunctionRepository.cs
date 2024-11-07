using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public interface IAdmFeatureFunctionRepository : IBaseRepository<AdmFeatureFunction, AdmFeatureFunctionFilter, int>
    {
        public List<string> CheckPagePermision(int pageId, string funcCode);
    }
}
