using BaseBackend.Application.Cache;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace BaseBackend.Application
{
    public class AuthenService
    {
        private readonly adm_userService _userService = new adm_userService();
        public string Login(string userName, string password)
        {
            adm_user? user = _userService.GetUserByUserName(userName);

            if(user == null)
            {
                throw new ExecuteErrorException("Tên đăng nhập không tồn tại");
            }

            string encryptPassword = EncryptPassword(password, user.password_salt);
            if(string.Compare(encryptPassword, user.password) != 0)
            {
                throw new ExecuteErrorException(SharedResource.LoginFailed);
            }

            JwtConfig jwtConfig = ConfigUtils.JwtConfiguration;
            var key = Encoding.ASCII.GetBytes(jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(adm_user.C_user_id, user.user_id.ToString() ?? ""),
                    new Claim(adm_user.C_username, user.username!),
                }),

                Expires = DateTime.UtcNow.AddMinutes(Int32.Parse(jwtConfig.TokenValidityInMinutes)),
                Issuer = jwtConfig.Issuer,
                Audience = jwtConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        public void SignUp(adm_user user)
        {
            if(string.IsNullOrWhiteSpace(user.password))
            {
                throw new InvalidInputException(SharedResource.InputDataInvalid);
            }
            user.password_salt = GetPasswordSalt();
            user.password = EncryptPassword(user.password, user.password_salt);
            _userService.InsertUser(user);
        }

        /// <summary>
        /// Hàm mã hóa mật khẩu
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private static string EncryptPassword(string password, string passwordSalt)
        {
            byte[] salt = Encoding.UTF8.GetBytes(passwordSalt);
            // Mã hóa password bằng KeyDerivation.Pbkdf2 có thêm salt và lặp 10.000 lần
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000, numBytesRequested: 256));
            return hashedPassword;
        }

        private static string GetPasswordSalt()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
