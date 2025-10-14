using Newtonsoft.Json;

namespace BaseBackend.Common
{
    public static class JsonHelper
    {
        public static T? DeserializeObject<T>(string objString)
        {
            return JsonConvert.DeserializeObject<T>(objString);
        }

        public static string SerializeObject(object? obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
