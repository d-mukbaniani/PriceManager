using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PriceManager.Infrastructure.Models.Enums;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Models.Response;
using PriceManager.Infrastructure.Services.Interfaces;

namespace PriceManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _authorizationService;

        public SecurityController(ISecurityService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("CreateToken")]
        public async Task<GenericResponse<string>> CreateToken(LoginRequest login) =>
            await _authorizationService.CreateJWT(login);

    }
}