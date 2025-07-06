using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class InvalidInputException : BaseException
    {
        public InvalidInputException(string message) : base(message, 400)
        {
            DevMessage = message;
            UserMessage = message;
        }
    }
}
