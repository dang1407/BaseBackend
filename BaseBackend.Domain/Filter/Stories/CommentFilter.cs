using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class CommentFilter : BaseFilter
    {
        public int? novel_id { get; set; }
        public int? chapter_id { get; set; }
    }
}
