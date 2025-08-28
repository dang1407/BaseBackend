using BaseBackend.Domain;
using Microsoft.Extensions.Configuration;

namespace BaseBackend.Application
{
    public static class GlobalCache
    {
        public static List<FunctionRight> ListPagePermisions { get; private set; } = new List<FunctionRight>();
        public static List<adm_general_setting> ListGeneralSettings { get; private set; } = new List<adm_general_setting>();

        //public static Dictionary<string, string> configDict = new Dictionary<string, string>();
        public static void InitCache()
        {
            PermisionService permisionService = new PermisionService();
            adm_general_settingService generalSettingService = new adm_general_settingService();
            // Load Permision
            ListPagePermisions = permisionService.GetAllPagePermisions();
            // Load GeneralSetting
            ListGeneralSettings = generalSettingService.GetAllGeneralSettings();

            //var builder = new ConfigurationBuilder()
            //            .SetBasePath(Directory.GetCurrentDirectory())
            //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();
            //configDict = GetAllConfigsV4(configuration);
        }

        public static Dictionary<string, string> GetAllConfigsV4(IConfiguration configuration)
        {
            return configuration.AsEnumerable()
                .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                .ToDictionary(x => x.Key, x => x.Value!);
        }
    }
}
