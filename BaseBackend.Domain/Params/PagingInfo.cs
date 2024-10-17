using BaseBackend.Domain.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class PagingInfo
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = SharedResource.DefaultPageSize;
    }
}
