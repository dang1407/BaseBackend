using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class ExecuteErrorException : BaseException
    {
        public ExecuteErrorException(string message) 
        {
            UserMessage = message;
            DevMessage = message;
        }

        public ExecuteErrorException(string userMessage, Exception ex)
        {
            UserMessage = userMessage;
            DevMessage = ex.Message;
        }
    }
}
