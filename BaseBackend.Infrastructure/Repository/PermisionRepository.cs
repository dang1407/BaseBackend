using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public class PermisionRepository : BaseRepository
    {
        public List<string> GetPageItemPermision(int pageId, int itemId, string funcCode)
        {
            throw new NotImplementedException();
        }

        public List<FunctionRight> GetAllPagePermision()
        {
            string sql = @"
select 
	enFeature.feature_id,
    enFunction.code as function_code,
    enFunction.function_id,
    enFeature.url,
    enFeature.icon,
    enFeaturefunction.rule_id
from adm_feature enFeature 
	inner join adm_feature_function enFeatureFunction on enFeature.feature_id = enFeatureFunction.feature_id
	inner join adm_function enFunction on enFeatureFunction.function_id = enFunction.function_id
                ";
            var param = new DynamicParameters();
            using UnitOfWork unitOfWork = new ();
            List<FunctionRight> result = unitOfWork.Connection.Query<FunctionRight>(sql, param).ToList();
            return result;
        }
    }
}
