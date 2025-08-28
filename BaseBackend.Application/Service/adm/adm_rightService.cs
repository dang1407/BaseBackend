using BaseBackend.Domain;
using BaseBackend.Infrastructure;
using BaseBackend.Infrastructure.Repository.adm;

namespace BaseBackend.Application.Service.adm
{
    public class adm_rightService : BaseService
    {
        adm_rightRepository _dao = new adm_rightRepository();
        public List<adm_feature> SetupViewForm()
        {
            return _dao.GetAllActiveFeature();
        }

        public (List<adm_function> Functions, List<adm_feature_function> FeatureFunctions, List<BuildRightConfig> BuildRightConfigs)
                GetItemsForView(int featureId)
        {
            //01.Get FeatureFunction 
            var functions = _dao.GetFunctionByFeatureId(featureId).OrderBy(en => en.function_id).ToList();
            List<adm_feature_function> lstFeatFunction = _dao.GetFeatureFunctionByFeatureId(featureId).OrderBy(en => en.function_id).ToList();

            foreach (adm_function itemFuntion in functions)
            {
                adm_feature_function? enFeatureFunction = lstFeatFunction.Find(en => en.function_id == itemFuntion.function_id);
                if (enFeatureFunction != null)
                {
                    itemFuntion.feature_function_rule_id = enFeatureFunction.rule_id;
                }
            }

            List<BuildRightConfig> lstRightConfig = new List<BuildRightConfig>();
            List<adm_right> lstAllowedRight = _dao.GetRightByFeatureId(featureId);

            //02.Get AllRole active
            List<adm_role> lstRole = _dao.GetAllActiveRole();

            foreach (var item in lstRole)
            {
                BuildRightConfig enConfig = new BuildRightConfig();
                enConfig.ItemId = item.role_id;
                enConfig.Name = item.name;
                enConfig.FunctionIds = lstAllowedRight.Where(en => en.role_id == item.role_id).Select(en => en.function_id).Distinct().ToList(); // Danh sách các function được phép làm
                lstRightConfig.Add(enConfig);
            }

            return (functions, lstFeatFunction, lstRightConfig);
        }

        public void SaveItem(int featureId, List<BuildRightConfig> buildRightConfigs)
        {
            //Prepare Data
            List<adm_right> lstRight = new List<adm_right>();
            foreach (var item in buildRightConfigs)
            {
                if (item.FunctionIds != null)
                {
                    foreach (int? functionID in item.FunctionIds)
                    {
                        adm_right right = new adm_right();
                        right.role_id = item.ItemId;
                        right.function_id = functionID;
                        right.feature_id = featureId;
                        lstRight.Add(right);
                    }
                }
            }

            using UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.BeginTransaction();
                _dao.DeleteRightByFeatureID(featureId, unitOfWork);
                foreach(var item in lstRight)
                {
                    _dao.InsertItem(item, unitOfWork);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new ExecuteErrorException(ex.Message);
            }
        }
    }
}
