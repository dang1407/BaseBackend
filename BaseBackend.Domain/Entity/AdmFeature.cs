using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain.Entity
{
    public class AdmFeature : BaseEntity
    {

        public AdmFeature() : base("AdmFeature", "FeatureId", true,true)
        {

        }

        [PropertyEntity("FeatureId")]
        public int FeatureId { get; set; }
        [PropertyEntity("Name")]
        public string Name { get; set; } = string.Empty;
        [PropertyEntity("ParentId")]
        public int ParentId { get; set; }
        [PropertyEntity("Status")]
        public int Status {  get; set; }
        [PropertyEntity("Url")]
        public string Url { get; set; } = string.Empty;
        [PropertyEntity("IsVisible")]
        public int IsVisible { get; set; }
        [PropertyEntity("Version")]
        public int Version {  get; set; }
        [PropertyEntity("Deleted")]
        public int Deleted { get; set; }
        public override int GetId()
        {
            return FeatureId;
        }

        public override void SetDeleted(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public override void SetId(int id)
        {
            FeatureId = id;
        }

        public override void SetVersion(int version)
        {
            throw new NotImplementedException();
        }
    }
}
