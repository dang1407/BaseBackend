using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class AdmFeatureFunction : BaseEntity
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

        public override int GetId()
        {
            return FeatureFunctionId;
        }

        public override void SetDeleted(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public override void SetId(int id)
        {
            FeatureFunctionId = id;
        }

        public override void SetVersion(int version)
        {
            throw new NotImplementedException();
        }
    }
}
