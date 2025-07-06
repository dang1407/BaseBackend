using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class adm_general_settingService
    {
        private readonly adm_general_settingRepository _repository = new adm_general_settingRepository();

        public List<adm_general_setting> GetAllGeneralSettings()
        {
            return _repository.GetAllGeneralSettings();
        }

        public string? GetSettingValueBySettingKey(string settingKey)
        {
            return _repository.GetSettingValueBySettingKey(settingKey);
        }

        public void UpdateGeneralSettingByKey(string settingKey, string settingValue)
        {
            _repository.UpdateSettingValueBySettingKey(settingKey, settingValue);
        }
    }
}
