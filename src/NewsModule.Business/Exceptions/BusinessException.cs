﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.Exceptions
{
    internal class BusinessException : Exception
    {
        public int StatusCode { get; set; }
        public BusinessException(string message, int statusCode = 400) : base(message)
        {

            StatusCode = statusCode;

        }
    }
}
