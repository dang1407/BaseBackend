using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public static class GlobalCache
    {
        public static List<FunctionRight> ListPagePermisions { get; private set; } = new List<FunctionRight>();
        public static void InitCache(IPermisionService permisionService)
        {

            ListPagePermisions = permisionService.GetAllPagePermisions();
        }
    }
}
