using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application.IService
{
    public interface IAdmFeatureFunctionService : IBaseService<AdmFeatureFunctionDTO, AdmFeatureFunctionFilter, int>
    {
    }
}
