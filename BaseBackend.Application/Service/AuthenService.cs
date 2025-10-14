using BaseBackend.Application.Service.Securities;
using BaseBackend.Common;
using BaseBackend.Domain;
using BaseBackend.Domain.Entity.adm;
using BaseBackend.Infrastructure;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static BaseBackend.Application.Service.Securities.EncryptionService;

namespace BaseBackend.Application
{
    public class AuthenService: IAuthenService
    {
        private IClientAuthenticateRepository _clientAuthenticateRepository;
        public AuthenService(IClientAuthenticateRepository clientAuthenticateRepository)
        {
            _clientAuthenticateRepository = clientAuthenticateRepository;
        }
        private readonly adm_userService _userService = new adm_userService();
        public string Login(string? userName, string? password)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new InvalidInputException(SharedResource.InputDataInvalid);
            }
            adm_user? user = _userService.GetUserByUserName(userName);

            if(user == null)
            {
                throw new ExecuteErrorException("Tên đăng nhập không tồn tại");
            }

            string encryptPassword = EncryptPassword(password, user.password_salt!);
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

        public async Task<AdmClientAuthenticate> GenerateEncryptData(string path)
        {
            if(SafeAPI.WhiteList.Contains(path))
            {
                return new AdmClientAuthenticate()
                {
                    public_key = "",
                    private_key = ""
                };
            } else
            {
                EncryptionService encryptionService = new EncryptionService();
                RSAKeyPair keyPair = encryptionService.GenerateRSAKeyPair();
                AdmClientAuthenticate clientAuth = new AdmClientAuthenticate();
                clientAuth.private_key = keyPair.PrivateKey;
                clientAuth.public_key = keyPair.PublicKey;
                clientAuth.requested_dtg = DateTime.Now;
                try
                {
                    await _clientAuthenticateRepository.InsertItem(clientAuth);
                    AdmClientAuthenticate result = clientAuth.CloneToUpdate();
                    result.private_key = null;
                    result.public_key = encryptionService.ExportPublicKeyToPem(clientAuth.public_key);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new ExecuteErrorException("Lỗi khi lưu khóa mã hóa", ex);
                }
            }
        }
    }
}
