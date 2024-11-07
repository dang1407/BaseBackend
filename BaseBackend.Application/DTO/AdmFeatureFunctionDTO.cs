using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class AdmFeatureFunctionDTO : BaseDTO
    {
        public int FeatureFunctionId { get; set; }
        public int FeatureId { get; set; }
        public int FunctionId { get; set; }
    }
}
