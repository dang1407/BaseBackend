using BaseBackend.Application;
using BaseBackend.Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace BaseBackend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly adm_userService _adm_userService = new adm_userService();
        private readonly AuthenService _authenService = new AuthenService();
        public AuthenticateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public  ActionResult LoginAsync([FromBody] AccountDTO loginDTO)
        {
            string token = _authenService.Login(loginDTO.Username, loginDTO.Password);
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddMinutes(Int32.Parse(ConfigUtils.JwtConfiguration.TokenValidityInMinutes)),
            };

            string systemName = ConfigUtils.JwtConfiguration.AccessTokenKey;
            Response.Cookies.Append(systemName, token, cookieOptions);
            return Ok(new
            {
                AccessToken = token,
            });
        }

        [HttpPost]
        [Route("sign-up")]
        public ActionResult SignUp([FromBody] AccountDTO loginDTO)
        {
            if (loginDTO.adm_user == null) throw new ExecuteErrorException(SharedResource.InputDataInvalid); 
            _authenService.SignUp(loginDTO.adm_user);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("relogin")]
        public IActionResult ReLogin()
        {
            var roles = User.FindAll(ClaimTypes.Role)?.Select(c => c.Value);

            return Ok(roles);
        }

//        [HttpPost]
//        [Route("refresh-token/{companyId}")]
//        public async Task<IActionResult> RefreshToken(TokenModel tokenModel, Guid companyId)
//        {
//            if (tokenModel is null)
//            {
//                return BadRequest("Invalid client request");
//            }

//            string? accessToken = tokenModel.AccessToken;
//            string? refreshToken = tokenModel.RefreshToken;

//            var principal = GetPrincipalFromExpiredToken(accessToken);
//            if (principal == null)
//            {
//                return BadRequest("Invalid access token or refresh token");
//            }

//#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//            string Username = principal.Identity.Name;
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
//#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
//            var loginDTO = new AccountDTO()
//            {
//                Username = Username ?? "Unknow user"
//            };
//            var user = await _userService.FindAccountAsync(loginDTO);

//            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
//            {
//                return BadRequest("Invalid access token or refresh token");
//            }

//            var newAccessToken = CreateToken(principal.Claims.ToList());
//            var newRefreshToken = GenerateRefreshToken();

//            user.RefreshToken = newRefreshToken;
//            //await _userManager.UpdateAsync(user);

//            return new ObjectResult(new
//            {
//                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
//                refreshToken = newRefreshToken
//            });
//        }

        [HttpGet]
        [Route("new-access-token")]
        public IActionResult GetNewAccessToken()
        {
            string? cookie = HttpContext.Request.Cookies["refreshToken"];
            return Ok(new
            {
                cookie
            });
        }

        [HttpPost]
        [Route("confirm-email")]
        public IActionResult SendVerificationEmail(string email)
        {


            try
            {
                var emailMimeMessage = new MimeMessage();
                emailMimeMessage.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailSettings:EmailUsername").Value));
                emailMimeMessage.To.Add(MailboxAddress.Parse(email));
                emailMimeMessage.Subject = "Xin chào";
                emailMimeMessage.Body = new TextPart(TextFormat.Html) { Text = "Xin chào" };

                var smtp = new SmtpClient();
                smtp.Connect(_configuration.GetSection("EmailSettings:EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration.GetSection("EmailSettings:EmailUsername").Value, _configuration.GetSection("EmailSettings:EmailPassword").Value);
                smtp.Send(emailMimeMessage);
                smtp.Disconnect(true);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("Login/Keycloak")]
        [HttpPost]
        public async Task<IActionResult> LoginCallback()
        {
            var authResult = await HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);
            if (authResult?.Succeeded != true)
            {
                // Handle failed authentication
                return RedirectToAction("Login");
            }

            // Get the access token and refresh token
            var accessToken = authResult?.Properties?.GetTokenValue("access_token") ?? "";
            var refreshToken = authResult?.Properties?.GetTokenValue("refresh_token") ?? "";

            // Save the tokens to the user's session or database
            HttpContext.Session.SetString("access_token", accessToken);
            HttpContext.Session.SetString("refresh_token", refreshToken);

            // Redirect the user to the desired page
            return RedirectToAction("Index");
        }

        public static string GenerateVerificationCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
        }
    }

    public class TokenModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class AccountDTO
    {
        public string? Username { get; set; } 
        public string? Password { get; set; }
        public adm_user? adm_user { get; set; }
    }
}
