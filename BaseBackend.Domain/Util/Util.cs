using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain.Util
{
    public static class Util
    {
        public static DateTime? GetDateValueForSearching(DateTime? dte, int seachingType)
        {
            if (dte == null)
            {
                return null;
            }

            if (seachingType == DateSeachingType.StartDate)
            {
                return dte.Value.Date;
            }
            else
            {
                return dte.Value.Date.AddDays(1).AddTicks(-1);
            }
        }
        public static string BuildLikeFilter(string value) 
        {
            return string.Format($"%{value}%");
        }
    }
}
