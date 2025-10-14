using BaseBackend.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace BaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClientIP()
        {
            IPAddress? clientIP = HttpContext.Connection.RemoteIpAddress;
            string ipAddress = "0.0.0.0";
            if (clientIP != null)
            {
                ipAddress = clientIP.ToString();
            }
            return Ok(ipAddress);
        }
        [HttpGet]
        [Route("config")]
        public IActionResult GetConfig() 
        {
            return Ok(new
            {
                a = ConfigUtils.GetAppSettingConfig("EmailAddress")
            });
        }

        [HttpGet]
        [Route("sendEmail")]
        public IActionResult SendEmail(IEmailService emailSevice) 
        {
            emailSevice.SendEmail("dang14072k2@gmail.com", "dang14072k2@gmail.com", "Test email", "Xin chào");
            return Ok("Đã nhận lệnh gửi Email");
        }

    }
}
