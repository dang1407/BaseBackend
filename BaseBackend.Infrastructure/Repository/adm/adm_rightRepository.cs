using BaseBackend.Domain;
using Dapper;
using Npgsql;

namespace BaseBackend.Infrastructure.Repository.adm
{
    public class adm_rightRepository : BaseRepository
    {
        public List<AdmRight> GetRightByFeatureIdAsync(int featureID)
        {
            string query = @"
select * 
from adm_right
where feature_id = @feature_id";
            using UnitOfWork unitOfWork = new UnitOfWork();
            DynamicParameters param = new DynamicParameters();
            param.Add("@feature_id", featureID);
            var result = unitOfWork.Connection.Query<AdmRight>(query, param);
            return result.ToList();
        }

        public List<adm_feature_function> GetFeatureFunctionByFeatureId(int featureID)
        {
            var query = @"
select *
from adm_feature_function 
where feature_id = @feature_id";
            using UnitOfWork unitOfWork = new UnitOfWork();
            DynamicParameters param = new DynamicParameters();
            param.Add("@feature_id", featureID);
            var result = unitOfWork.Connection.Query<adm_feature_function>(query, param);
            return result.ToList();

        }

        public List<adm_function> GetFunctionByFeatureId(int featureID)
        {
            string query = @"
select distinct enFeatureFunction.Function_ID, enFunction.name
from adm_feature_function enFeatureFunction
inner join adm_Function enFunction on enFunction.Function_ID = enFeatureFunction.Function_ID
where enFeatureFunction.feature_id = @feature_id";

            using UnitOfWork unitOfWork = new UnitOfWork();
            DynamicParameters param = new DynamicParameters();
            param.Add("@feature_id", featureID);
            var result = unitOfWork.Connection.Query<adm_function>(query, param);
            return result.ToList();
        }

        public List<AdmRole> GetAllActiveRole()
        {
            string query = @"
select role_id, code, name, description, is_active 
from adm_role
where deleted = 0
    and is_active = @active
";
            using UnitOfWork unitOfWork = new UnitOfWork();
            DynamicParameters param = new DynamicParameters();
            param.Add("@active", true);
            var result = unitOfWork.Connection.Query<AdmRole>(query, param);
            return result.ToList();
        }
        public List<adm_feature> GetAllActiveFeature()
        {
            var query = @"
select feature_id, name, description, parent_id
from adm_feature 
where deleted = 0 
    and active = @active
    and feature_id != @globalconfig";

            using UnitOfWork unitOfWork = new UnitOfWork();
            DynamicParameters param = new DynamicParameters();
            param.Add("@active", SharedResource.Status.Active);
            param.Add("@globalconfig", SharedResource.GlobalConfig);
            var result = unitOfWork.Connection.Query<adm_feature>(query, param);
            return result.ToList();
        }

        public List<AdmRight> GetRightByFeatureId(int featureID)
        {
            string query = @"
select * 
from adm_right
where feature_id = @feature_id";
            using UnitOfWork unitOfWork = new UnitOfWork();
            DynamicParameters param = new DynamicParameters();
            param.Add("@feature_id", featureID);
            var result = unitOfWork.Connection.Query<AdmRight>(query, param);
            return result.ToList();
        }

        public List<adm_feature> GetFeaturesByListFeatureIDs(List<int> listFeatureIDs)
        {
            string query = string.Format(@"
select *
from adm_feature 
where feature_id in ({0})
", BuildInCondition(listFeatureIDs));
            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.Connection.Query<adm_feature>(query);
            return result.ToList();
        }

        public int DeleteRightByFeatureID(int? featureID, UnitOfWork unitOfWork)
        {
            string query = @"
delete from adm_right
where feature_id = @feature_id
	and role_id is not null";
            DynamicParameters param = new DynamicParameters();
            param.Add("@feature_id", featureID);
            int affectedRows = unitOfWork.Connection.Execute(query, param, unitOfWork.Transaction);
            return affectedRows;
        }
    }
}
