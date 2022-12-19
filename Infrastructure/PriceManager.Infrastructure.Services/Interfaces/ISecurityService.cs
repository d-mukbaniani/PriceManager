using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Models.Response;

namespace PriceManager.Infrastructure.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<GenericResponse<string>> CreateJWT(LoginRequest login);
    }
}
