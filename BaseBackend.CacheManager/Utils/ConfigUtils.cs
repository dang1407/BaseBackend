using BaseBackend.Domain;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BaseBackend.Application
{
    public class ConfigUtils
    {
        public static JwtConfig JwtConfiguration { get; private set; } = new JwtConfig();
        private static List<KeyValuePair<string, string>> AppSettings { get; set; } = new List<KeyValuePair<string, string>>();
        public static void InitConfiguration(IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("Jwt");
            var appSettings = configuration.GetSection("AppSettings");
            PropertyInfo[] jwtProperies = typeof(JwtConfig).GetProperties();
            foreach (var key in jwtConfig.GetChildren())
            {
                foreach (var property in jwtProperies)
                {
                    if (string.Compare(property.Name, key.Key) == 0)
                    {
                        property.SetValue(JwtConfiguration, key.Value);
                        break;
                    }
                }
            }

            foreach (var appSetting in appSettings.GetChildren())
            {
                if (!string.IsNullOrWhiteSpace(appSetting.Value))
                {
                    AppSettings.Add(new KeyValuePair<string, string>(appSetting.Key, appSetting.Value));
                }
            }
        }

        public static string GetAppSettingConfig(string key)
        {
            foreach(KeyValuePair<string, string> setting in AppSettings)
            {
                if (string.Compare(setting.Key, key) == 0) return setting.Value;
            }
            throw new ExecuteErrorException($"Cannot find setting with key: {key}");
        }

        public static string? GetConfig(string key)
        {
            var item = AppSettings.FirstOrDefault(c => c.Key == key);
            if (item.Value == null)
                return null;

            string value = item.Value.Trim();
            //try
            //{
            //    value = Utility.Decrypt(value);
            //}
            //catch { }

            return value;
        }
        public static int GetConfigInt(string key)
        {
            string? value = GetConfig(key);
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                throw new Exception(string.Format("Giá trị cấu hình của key {0} không đúng kiểu Int", key));
            }
        }

        /// <summary>
        /// Cấu hình thời gian 1 session (đơn vị phút)
        /// Mặc định là 60p nếu không được cấu hình
        /// </summary>
        public static int SessionExpiredTime
        {
            get
            {
                try
                {
                    _SessionExpiredTime = GetConfigInt("SessionExpiredTime");
                }
                catch
                {
                    _SessionExpiredTime = 30;
                }

                return _SessionExpiredTime.Value;
            }
        }
        private static int? _SessionExpiredTime = null;

        private static int? _JwtSessionTimeout = null;
        public static int JwtSessionTimeout
        {
            get
            {
                if (_JwtSessionTimeout == null)
                {
                    _JwtSessionTimeout = GetConfigInt("JwtSessionTimeout");
                    _JwtSessionTimeout = _JwtSessionTimeout ?? 60; // default
                }

                return _JwtSessionTimeout.Value;
            }
        }
    }

    public class LoggingConfig
    {

    }

    public class LogLevelConfig
    {
        public string Default { get; set; } = "";
        public string MicrosoftAspNetCore { get; set; } = "";
    }

    public class ConnectionStringsConfig
    {
        public string DefaultConnection { get; set; } = "";
    }

    public class JwtConfig
    {
        public string Key { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public string Subject { get; set; } = "";
        public string TokenValidityInMinutes { get; set; } = "0";
        public string AccessTokenKey { get; set; } = "";
    }

}
