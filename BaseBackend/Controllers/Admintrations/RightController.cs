using BaseBackend.Application.Service.adm;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Admintrations
{
    [Route("api/web/manage/internal/Right")]
    public class RightController : BaseController
    {
        [HttpPost]
        public adm_rightDTO Post([FromBody] adm_rightDTO dtoRequest)
        {
            adm_rightService biz = new adm_rightService();
            var dtoResponse = new adm_rightDTO();

            switch (this.ActionCode)
            {
                case ApiActionCode.SetupViewForm:
                    // Check View Permisison
                    //dtoResponse.FunctionCodes = base.GetPagePermission(SMX.FeatureWeb.Right, FunctionCode.VIEW);

                    dtoResponse.FeatureWeb = biz.SetupViewForm();
                    break;
                case ApiActionCode.GetItemsForView:
                    {
                        // Check View Permisison
                        //dtoResponse.FunctionCodes = base.GetPagePermission(SMX.FeatureWeb.Right, FunctionCode.VIEW);

                        var result = biz.GetItemsForView(dtoRequest.FeatureId.GetValueOrDefault(0));
                        dtoResponse.Functions = result.Functions;
                        dtoResponse.FeatureFunctions = result.FeatureFunctions;
                        dtoResponse.BuildRightConfigs = result.BuildRightConfigs;
                        break;
                    }
                case ApiActionCode.SaveItem:
                    // Check Item permission
                    //dtoResponse.FunctionCodes = base.GetPagePermission(SMX.FeatureWeb.Right, FunctionCode.EDIT);

                    biz.SaveItem(dtoRequest.FeatureId.GetValueOrDefault(0), dtoRequest.BuildRightConfigs ?? []);
                    break;
                default:
                    throw new NotImplementedException(this.ActionCode);
            }

            return dtoResponse;
        }

        /// <summary>
        /// Dữ liệu đầu vào/ra cho Api
        /// </summary>
        public class adm_rightDTO : BaseDTO
        {
            public int? FeatureId { get; set; }
            public List<adm_function>? Functions { get; set; }
            //public List<Flex_Rule> Flex_Rules { get; set; }
            public List<adm_feature>? FeatureWeb { get; set; }
            public List<adm_feature_function>? FeatureFunctions { get; set; }
            public List<BuildRightConfig>? BuildRightConfigs { get; set; }
        }

        /// <summary>
        /// Các chức năng do api cung cấp
        /// </summary>
        public class ApiActionCode : BaseApiActionCode
        {
            public const string GetItemsForView = "GetItemsForView";
            public const string SaveItem = "SaveItem";
        }
    }
}
