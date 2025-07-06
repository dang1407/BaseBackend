using BaseBackend.Domain;

namespace BaseBackend.Application
{
    public static class GlobalCache
    {
        public static List<FunctionRight> ListPagePermisions { get; private set; } = new List<FunctionRight>();
        public static List<adm_general_setting> ListGeneralSettings { get; private set; } = new List<adm_general_setting>();
        public static void InitCache()
        {
            PermisionService permisionService = new PermisionService(); 
            adm_general_settingService generalSettingService = new adm_general_settingService();
            // Load Permision
            ListPagePermisions = permisionService.GetAllPagePermisions();
            // Load GeneralSetting
            ListGeneralSettings =  generalSettingService.GetAllGeneralSettings();
        }
    }
}
