using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Infrastructure.Models.Models
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
