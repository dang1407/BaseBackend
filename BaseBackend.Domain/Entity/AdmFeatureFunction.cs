using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class AdmFeatureFunction : BaseEntity, IEntity<int>
    {
        public AdmFeatureFunction() : base("AdmFeatureFunction", "FeatureFunctionId", false, false)
        {
        }
        [PropertyEntity("FeatureFunctionId")]
        public int FeatureFunctionId { get; set; }

        [PropertyEntity("FeatureId")]
        public int FeatureId { get; set; }
        [PropertyEntity("FunctionId")]
        public int FunctionId { get; set; }

        public int GetId()
        {
            return FeatureFunctionId;
        }

        public void SetId(int id)
        {
            FeatureFunctionId = id;
        }
    }
}
