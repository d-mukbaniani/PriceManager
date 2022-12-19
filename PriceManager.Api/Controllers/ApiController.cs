using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Models.Response;
using PriceManager.Infrastructure.Services.Interfaces;

namespace PriceManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [EnableCors("AllowOrigin")]
    public class ApiController : ControllerBase
    {
        private readonly IPriceManagementService _priceManagementService;

        public ApiController(IPriceManagementService priceManagementService)
        {
            _priceManagementService = priceManagementService;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("GetAllCompanies")]
        public async Task<GenericResponse<IEnumerable<CompanyModel>>> GetAllCompanies() =>
            await _priceManagementService.GetAllCompanies();

        [EnableCors("AllowOrigin")]
        [HttpGet("GetCompany/{id}")]
        public async Task<GenericResponse<CompanyModel>> GetCompany(int id) =>
            await _priceManagementService.GetCompany(id);


        [EnableCors("AllowOrigin")]
        [HttpGet("GetAllMarkets")]
        public async Task<GenericResponse<IEnumerable<MarketModel>>> GetAllMarkets() =>
            await _priceManagementService.GetAllMarkets();

        [EnableCors("AllowOrigin")]
        [HttpGet("GetMarket/{id}")]
        public async Task<GenericResponse<MarketModel>> GetMarket(int id) =>
            await _priceManagementService.GetMarket(id);

        [EnableCors("AllowOrigin")]
        [HttpGet("GetAllPrices")]
        public async Task<GenericResponse<IEnumerable<CompanyPriceModel>>> GetAllPrices() =>
            await _priceManagementService.GetAllPrices();

        [EnableCors("AllowOrigin")]
        [HttpGet("GetPrice/{id}")]
        public async Task<GenericResponse<CompanyPriceModel>> GetPrice(int id) =>
            await _priceManagementService.GetPrice(id);

        [EnableCors("AllowOrigin")]
        [HttpPost("SetPrice/{id}/{price}")]
        public async Task<BaseResponse> SetPrice(int id, decimal price) =>
            await _priceManagementService.SetPrice(id, price);

    }
}
