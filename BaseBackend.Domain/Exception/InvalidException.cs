﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public class InvalidException : BaseException
    {
        public InvalidException(string message) : base(message, 400)
        {
            DevMessage = message;
            UserMessage = message;
        }
    }
}
