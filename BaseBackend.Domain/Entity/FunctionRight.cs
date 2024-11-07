using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class FunctionRight : BaseEntity
    {
 
        public int FeatureId { get; set; }
        public int FunctionId { get; set; }
        public string FunctionCode { get; set; }
        public string RuleCode { get; set; }

        public int? RuleID { get; set; }

        public FunctionRight()
            : base(string.Empty, string.Empty, false, false)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}:{3}", FeatureId, FunctionId, FunctionCode);
        }
    }
}
