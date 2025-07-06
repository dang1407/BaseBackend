using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class BaseException : Exception
    {
        public int ErrorCode { get; set; }
        public string? DevMessage { get; set; }
        public string? UserMessage { get; set; }
        public string? TraceId { get; set; }
        public string? MoreInfo { get; set; }
        public object? Errors { get; set; }

        public object? ErrorKeys { get; set; }

        public int? StatusCode { get; set; }
        public BaseException() { }
        public BaseException(string message, int statusCode) : base(message) 
        {
            DevMessage = message;
            UserMessage = message;
            StatusCode = statusCode;
        }
    }
}
