
using Newtonsoft.Json;
namespace BaseBackend.Utils
{
    public static class Utils
    {
        public static string SerializeObject(object? obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
