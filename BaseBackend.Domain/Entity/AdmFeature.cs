using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain.Entity
{
    public class AdmFeature : BaseEntity, IEntity<int>
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
        public int GetId()
        {
            return FeatureId;
        }

        public void SetId(int id)
        {
            FeatureId = id;
        }
    }
}
