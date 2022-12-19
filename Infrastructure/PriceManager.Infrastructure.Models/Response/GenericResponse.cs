using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Infrastructure.Models.Response
{
    public class GenericResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
