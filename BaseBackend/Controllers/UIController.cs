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
            UserProfile profile = UserContext.Current;

                List<adm_feature> listFeature = profile.ListRight?.Select(en => new adm_feature()
                {
                    feature_id = en.feature_id,
                    parent_id = en.parent_id,
                    name = en.name,
                    url = en.url,
                    icon = en.icon
                }).ToList() ?? [];
                return Ok(new
                {
                    ListFeature = listFeature
                });
        }
    }
}
