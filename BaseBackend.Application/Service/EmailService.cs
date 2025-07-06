namespace BaseBackend.Application
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string fromEmail, string toEmail, string subject, string body)
        {
            try
            {
                string server = "smtp.gmail.com"; // replace it with your own domain name
                int port = 465; // alternative port is 8889
                bool enableSsl = true; // false for port 25 or 8889, true for port 465
                string from = ConfigUtils.GetAppSettingConfig("EmailAddress"); // from address and SMTP Username
                string password = ConfigUtils.GetAppSettingConfig("EmailAppPassword"); // replace it with your real Password
                string to = "dang14072k2@gmail.com"; // recipient address

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("from_name", from)); // replace from_name with real name
                message.To.Add(new MimeKit.MailboxAddress("to_name", to)); // replace to_name with real name
                message.Subject = "This is an email";
                message.Body = new MimeKit.TextPart("plain")
                {
                    Text = @"This is from MailKit.Net.Smtp using C sharp with SMTP authentication."
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(server, port, enableSsl);
                    client.Authenticate(from, password);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
