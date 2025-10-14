using BaseBackend.Application.Service.Securities;
using BaseBackend.Common;
using BaseBackend.Domain;
using BaseBackend.Domain.Entity.adm;
using BaseBackend.Infrastructure;
using Newtonsoft.Json;
using System.Text;

namespace BaseBackend.Middleware
{
    public class DecryptionMiddleware
    {
        private readonly RequestDelegate _next;
        public DecryptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context, IClientAuthenticateRepository clientAuthenticateRepository)
        {
            if (context.Request.Method == "GET" || SafeAPI.WhiteList.Contains(context.Request.Path))
            {
                await _next(context);
                return;
            }

            // Giải mã request
            context.Request.EnableBuffering();
            string body = "";
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024,
                leaveOpen: true))
            {
                body = await reader.ReadToEndAsync();
            }
            context.Request.Body.Position = 0;
            int? clientAuthenticateID = null;
            try
            {
                // Nếu request có header AES-Key thì mới giải mã
                string path = context.Request.Path;
                string rsaPublicKeyData = context.Request.Headers["x-a-code"].ToString();
                string clientAuthenIDString = context.Request.Headers["x-b-code"].ToString();
                clientAuthenticateID = int.Parse(clientAuthenIDString);
                AdmClientAuthenticate? clientAuthenticate = await clientAuthenticateRepository.GetItemById(clientAuthenticateID.Value);

                if (string.IsNullOrEmpty(rsaPublicKeyData) || clientAuthenticate == null)
                {
                    throw new ExecuteErrorException("Invalid request");
                }
                var encryptionService = new EncryptionService();
                // Giải mã chuỗi AES key và IV bằng RSA private key lưu ở DB
                string aesKeyIVString = encryptionService.DecryptRSA(rsaPublicKeyData, clientAuthenticate.private_key!);
                aesKeyIVString = aesKeyIVString.Trim('"');
                string[] parts = aesKeyIVString.Split(':');
                string aesKey = parts[0];
                string aesIV = parts[1];
                string decryptedData = encryptionService.DecryptAES(body, aesKey, aesIV);
                // Thay thế request body bằng dữ liệu đã giải mã
                var bytes = Encoding.UTF8.GetBytes(decryptedData);
                context.Request.ContentType = "application/json";
                context.Request.ContentLength = bytes.Length;
                context.Request.Body = new MemoryStream(bytes);
                context.Request.Body.Position = 0;
                await _next(context);
            }
            catch (Exception ex)
            {
                throw new ExecuteErrorException("Lỗi khi kết nối đến máy chủ", ex);
            }
            finally
            {
                if (clientAuthenticateID != null)
                    await clientAuthenticateRepository.DeleteItemByID(clientAuthenticateID.Value);
            }
        }
    }
}