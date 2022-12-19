using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Models.Response;

namespace PriceManager.Infrastructure.Services.Interfaces
{
    public interface IPriceManagementService
    {
        Task<GenericResponse<IEnumerable<CompanyModel>>> GetAllCompanies();
        Task<GenericResponse<CompanyModel>> GetCompany(int id);
        Task<GenericResponse<IEnumerable<MarketModel>>> GetAllMarkets();
        Task<GenericResponse<MarketModel>> GetMarket(int id);
        Task<GenericResponse<IEnumerable<CompanyPriceModel>>> GetAllPrices();
        Task<GenericResponse<CompanyPriceModel>> GetPrice(int id);
        Task<BaseResponse> SetPrice(int id, decimal price);


    }
}
