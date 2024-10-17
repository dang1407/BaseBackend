using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public AuthenticateController() { } 

        [HttpGet]
        [Authorize]
        public IActionResult GetCheckBearerConfig(){
            return Ok();
        }
    }
}
