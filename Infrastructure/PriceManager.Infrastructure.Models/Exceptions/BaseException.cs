using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Infrastructure.Models.Enums;

namespace PriceManager.Infrastructure.Models.Exceptions
{
    public class BaseException : Exception
    {
        public ResponseCode Code { get; set; }
    }
}
