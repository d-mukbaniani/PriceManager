using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PriceManager.Infrastructure.Models.Enums;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Models.Response;
using PriceManager.Infrastructure.Services.Interfaces;

namespace PriceManager.Infrastructure.Services.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ILogger<SecurityService> _logger;

        private readonly string _defaultUserName;
        private readonly string _defaultPassword;
        private readonly byte[] _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _validForDays;

        public SecurityService(ILogger<SecurityService> logger, IConfiguration configuration)
        {
            _logger = logger;

            _defaultUserName = configuration["Jwt:DefaultLogin:UserName"];
            _defaultPassword = configuration["Jwt:DefaultLogin:Password"];
            _key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _validForDays = configuration.GetValue<int>("Jwt:ValidForDays");
        }

        public async Task<GenericResponse<string>> CreateJWT(LoginRequest login)
        {
            try
            {
                if (login.UserName != _defaultUserName || login.Password != _defaultPassword)
                {
                    _logger.LogInformation("[CreateJWT] invalid login, login: {login}", login);
                    return new GenericResponse<string>
                    {
                        ResponseCode = ResponseCode.InvalidLogin
                    };
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, login.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddDays(_validForDays),
                    Issuer = _issuer,
                    Audience = _audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);


                _logger.LogInformation("[CreateJWT] token generated successfully, login: {login}", login);
                return new GenericResponse<string>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = tokenString
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[CreateJWT] unknown exception occurred, login: {login}", login);
                return new GenericResponse<string>
                {
                    ResponseCode = ResponseCode.UnknownError
                };
            }
        }

    }
}
