namespace BaseBackend.Application
{
    public interface IEmailService
    {
        public void SendEmail(string fromEmail, string toEmail, string subject, string body);    
    }
}
