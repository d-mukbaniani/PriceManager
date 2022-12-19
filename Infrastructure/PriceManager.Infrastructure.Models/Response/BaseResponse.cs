using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using PriceManager.Infrastructure.Models.Enums;

namespace PriceManager.Infrastructure.Models.Response
{
    public class BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }
        public string ResponseString =>
            ResponseCode.GetType()
                .GetMember(ResponseCode.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
    }
}
