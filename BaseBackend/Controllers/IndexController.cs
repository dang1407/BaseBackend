using BaseBackend.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPagePermisions()
        {
            return Ok(GlobalCache.ListPagePermisions);
        }
        [HttpGet]
        [Route("config")]
        public IActionResult GetConfig() 
        {
            return Ok(new
            {
                ScheduleAdmobMinute = 20
            });
        }
    }
}
