using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public interface IEmailService
    {
        public void SendEmail(string fromEmail, string toEmail, string subject, string body);    
    }
}
