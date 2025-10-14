using BaseBackend.Common;
using BaseBackend.Domain;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BaseBackend.Application.Service.Securities
{
    public class EncryptionService
    {
        // Mã hóa dữ liệu
        public string EncryptAES(string plainText, string _aesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(_aesKey.Substring(0, 32));
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        // Giải mã dữ liệu
        public string DecryptAES(string cipherText, string aesKeyBase64, string ivBase64)
        {
            byte[] key = Convert.FromBase64String(aesKeyBase64);
            byte[] iv = Convert.FromBase64String(ivBase64);
            cipherText = cipherText.Trim('"');
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(buffer))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        public RSAKeyPair GenerateRSAKeyPair(int keySize = 1024)
        {
            using (var rsa = RSACng.Create())
            {
                rsa.KeySize = keySize;

                var privateKeyParameters = rsa.ExportParameters(true);
                string privateKey = JsonHelper.SerializeObject(privateKeyParameters);

                var publicKeyParameters = rsa.ExportParameters(false);
                string publicKey = JsonHelper.SerializeObject(publicKeyParameters);

                return new RSAKeyPair(privateKey, publicKey);
            }
        }

        public string DecryptRSA(string cipherText, string privateKeyJson)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);
            var privateKeyParameters = JsonHelper.DeserializeObject<RSAParameters>(privateKeyJson);
            using (var rsa = RSACng.Create())
            {
                rsa.ImportParameters(privateKeyParameters);
                byte[] decryptedBytes = rsa.Decrypt(buffer, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        public string ExportPublicKeyToPem(string jsonPublicKey)
        {
            // 1️⃣ Parse JSON sang RSAParameters
            var rsaParams = JsonConvert.DeserializeObject<RSAParameters>(jsonPublicKey);

            // 2️⃣ Tạo RSA và import key
            using var rsa = RSA.Create();
            rsa.ImportParameters(rsaParams);

            // 3️⃣ Export ra dạng SubjectPublicKeyInfo (PEM chuẩn)
            var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();

            // 4️⃣ Chuyển sang Base64 + format PEM
            var base64 = Convert.ToBase64String(publicKeyBytes, Base64FormattingOptions.InsertLineBreaks);
            var pem = $"-----BEGIN PUBLIC KEY-----\n{base64}\n-----END PUBLIC KEY-----";

            return pem;
        }
        public class RSAKeyPair
        {
            public string PrivateKey { get; set; }
            public string PublicKey { get; set; }

            public RSAKeyPair(string privateKey, string publicKey)
            {
                PrivateKey = privateKey;
                PublicKey = publicKey;
            }
        }
    }
}
