using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public class adm_general_settingRepository : BaseRepository
    {
        public List<adm_general_setting> GetAllGeneralSettings()
        {
            string query = @"select * from adm_general_setting";
            using UnitOfWork unitOfWork = new UnitOfWork();
            return unitOfWork.Connection.Query<adm_general_setting>(query).ToList();
        }

        public string? GetSettingValueBySettingKey(string settingKey)
        {
            string query = @"
select setting_value 
from adm_general_setting 
where setting_key = @setting_key";
            DynamicParameters param = new DynamicParameters();
            param.Add("@settingKey", settingKey);
            using UnitOfWork unitOfWork = new UnitOfWork();
            return unitOfWork.Connection.Query<string>(query, param).FirstOrDefault();
        }

        public int UpdateSettingValueBySettingKey(string settingKey, string settingValue)
        {
            string query = @"
update adm_general_setting 
set setting_value = @setting_value 
where setting_key = @setting_key";
            DynamicParameters param = new DynamicParameters();
            param.Add("@setting_value", settingValue);
            param.Add("@setting_key",settingKey);
            using UnitOfWork unitOfWork = new UnitOfWork(); 
            int affectedRows = unitOfWork.Connection.Execute(query, param);
            if (affectedRows == 0) throw new ExecuteErrorException(SharedResource.ExecuteErrorMessage);
            return affectedRows;
        }
    }
}
