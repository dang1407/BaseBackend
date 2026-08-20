using BaseBackend.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Authorization;
namespace BaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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
            return Ok($"Api is running {DateTime.Now.ToString("HH:mm dd/mm/yyyy")}");
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

        [RequestSizeLimit(long.MaxValue)]
        [HttpPost]
        [Route("formcollection")]
        public async Task<IActionResult> PostFile(IFormCollection request)
        {
            if (request?.Files == null || request.Files.Count == 0)
                return BadRequest(new { Message = "No file uploaded" });

            var file = request.Files[0];

            if (file.Length == 0)
                return BadRequest(new { Message = "Empty file" });

            // Sanitize file name (không check extension nữa để linh hoạt hơn)
            string originalFileName = Path.GetFileName(file.FileName) ?? $"upload_{Guid.NewGuid():N}";
            string fileName = originalFileName;

            // Loại bỏ ký tự không hợp lệ
            foreach (char invalid in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(invalid, '_');

            // Ensure base directory is safe and exists
            string baseDirectory = @"D:\Softmart\TP_Valuation\Document\Record";
            Directory.CreateDirectory(baseDirectory);

            string finalPath = Path.Combine(baseDirectory, fileName);
            string tempPath = Path.Combine(baseDirectory, $"{fileName}.uploading");

            try
            {
                // XÓA FILE CŨ NẾU TỒN TẠI
                if (System.IO.File.Exists(tempPath))
                    System.IO.File.Delete(tempPath);

                // BUFFER SIZE LỚN HƠN CHO VIDEO (2MB)
                const int bufferSize = 2 * 1024 * 1024; // 2MB buffer

                // Stream trực tiếp vào file tạm KHÔNG DÙNG WriteThrough
                using (var sourceStream = file.OpenReadStream())
                using (var targetStream = new FileStream(
                    tempPath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize,
                    FileOptions.Asynchronous | FileOptions.SequentialScan)) // SequentialScan tốt cho video
                {
                    // Copy với buffer lớn
                    await sourceStream.CopyToAsync(targetStream, bufferSize);

                    // Đảm bảo flush tất cả dữ liệu xuống đĩa
                    await targetStream.FlushAsync();
                }

                // Đợi một chút để đảm bảo OS đã ghi xong (optional nhưng an toàn hơn)
                await Task.Delay(100);

                // Verify file size
                var uploadedFileInfo = new FileInfo(tempPath);
                if (uploadedFileInfo.Length != file.Length)
                {
                    throw new Exception($"File size mismatch. Expected: {file.Length}, Actual: {uploadedFileInfo.Length}");
                }

                // Move/Replace file cũ nếu tồn tại
                if (System.IO.File.Exists(finalPath))
                {
                    System.IO.File.Delete(finalPath);
                }
                System.IO.File.Move(tempPath, finalPath);

                return Ok(new
                {
                    Message = "Upload successful",
                    FileName = fileName,
                    Size = file.Length,
                    SizeFormatted = FormatFileSize(file.Length),
                    Path = finalPath,
                    ContentType = file.ContentType
                });
            }
            catch (Exception ex)
            {
                // Cleanup temp file on error
                try
                {
                    if (System.IO.File.Exists(tempPath))
                        System.IO.File.Delete(tempPath);
                }
                catch { }

                return StatusCode(500, new
                {
                    Message = "File upload failed",
                    Detail = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
        }
        [RequestSizeLimit(long.MaxValue)]
        [HttpPost]
        [Route("formcollectionform")]
        public async Task<IActionResult> PostFileForm([FromForm] FormRequest request)
        {
            Console.WriteLine($"Content-Length header: {Request.ContentLength}");
            var file = request.File;
            Console.WriteLine($"File.Length: {file.Length}");
            string fileName = Path.GetFileName(file.FileName);
            string path = Path.Combine(@"D:\Softmart\TP_Valuation\Document\Record", fileName);

            // Đảm bảo thư mục tồn tại
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            // Dùng FileStream để ghi trực tiếp từ Request xuống Disk
            using (var targetStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Copy trực tiếp từ stream của IFormFile sang FileStream
                await file.CopyToAsync(targetStream);
                await targetStream.FlushAsync(); // Ép dữ liệu xuống đĩa hoàn toàn
            }

            return Ok();
        }
        // Helper method để format file size
        private static string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }
        public class FormRequest
        {
            public IFormFile File { get; set; }
        }
    }
}
