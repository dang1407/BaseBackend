using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public class DateSeachingType
    {
        public const int StartDate = 1;
        public const int EndDate = 2;
    }
}
