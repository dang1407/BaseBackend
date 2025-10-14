using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OfficeOpenXml.Drawing;
using OfficeOpenXml;
using BaseBackend.Application;
using System.Net.Mail;
using System.Net;

namespace BaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockupController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostExcel([FromForm] Form form)
        {
            //string filePath = "D:\\VisualStudioProjects\\Eshust\\BaseBackend\\UploadedFiles\\KetQuaDinhGia_QSDD.xlsx";
            //using (var package = new ExcelPackage(new FileInfo(filePath)))
            //{
            //    var worksheet = package.Workbook.Worksheets[0];

            //    foreach (var drawing in worksheet.Drawings)
            //    {
            //        if (drawing is ExcelPicture picture)
            //        {
            //            int row = picture.From.Row + 1;       // Excel dùng chỉ số bắt đầu từ 0, nên +1
            //            int col = picture.From.Column + 1;

            //            Console.WriteLine();
            //            return Ok($"Picture: {picture.Name}, at Cell: {worksheet.Cells[row, col].Address}");
            //            //// Nếu bạn muốn lưu ảnh ra file
            //            //byte[] imageBytes = picture.ImageBytes;
            //            //File.WriteAllBytes($"output_{picture.Name}.png", imageBytes);
            //        }
            //    }
            //}

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            string email = ConfigUtils.GetAppSettingConfig("EmailAddress"); ;
            string emailPassword = ConfigUtils.GetAppSettingConfig("EmailAppPassword");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(emailPassword))
            {
                smtpClient.UseDefaultCredentials = true;
            }
            else
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(email, emailPassword);
                smtpClient.EnableSsl = true;
            }
            string filePath = "D:\\Downloads\\KetQuaDinhGia_ChungCutest.xlsx";

            Attachment att = new Attachment(filePath);
            
            MailMessage mail = new MailMessage(email, email, "Yêu cầu định giá", "File template yêu cầu định giá");
            mail.Attachments.Add(att);
            smtpClient.Send(mail);


            return Ok();
        }

        public static bool UploadFile(byte[] fileContent, string destinationName)
        {
            string directory = Path.GetDirectoryName(destinationName) ?? "";
            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                using (FileStream writer = new FileStream(destinationName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    writer.Write(fileContent, 0, fileContent.Length);
                    writer.Close();
                }
            }
            catch (Exception )
            {
                return false;
            }

            return true;
        }

        public class Form
        {
            public int? process_valuation_id { get; set; }
            public IFormFile? file { get; set; }
        }
    }
}
