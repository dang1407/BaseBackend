using BaseBackend.Application.Service.adm;
using BaseBackend.CacheManager;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    [Route("api/v1/[controller]")]
    public class UIController : BaseController
    {
        [HttpGet]
        [Route("UserMenu")]
        public IActionResult GetNavMenuData()
        {
            UserProfile profile = UserContext.CurrentUser;
            List<int>? lstFeatureID = profile.ListRight?.Where(r => r.feature_id.HasValue).Select(r => r.feature_id.Value).ToList();

            adm_rightService adm_RightService = new adm_rightService();
            List<adm_feature> result = adm_RightService.GetUserFeature(lstFeatureID ?? []);
            return Ok(new
            {
                ListFeatures = result
            });
        }
    }
}
