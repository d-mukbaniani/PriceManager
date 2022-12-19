using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PriceManager.Infrastructure.Data.Interfaces;
using PriceManager.Infrastructure.Models.Enums;
using PriceManager.Infrastructure.Models.Exceptions;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Models.Response;
using PriceManager.Infrastructure.Services.Interfaces;

namespace PriceManager.Infrastructure.Services.Services
{
    public class PriceManagementService : IPriceManagementService
    {
        private readonly ILogger<PriceManagementService> _logger;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMarketRepository _marketRepository;
        private readonly ICompanyPriceRepository _companyPriceRepository;

        public PriceManagementService(
            ILogger<PriceManagementService> logger,
            ICompanyRepository companyRepository, 
            IMarketRepository marketRepository,
            ICompanyPriceRepository companyPriceRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
            _marketRepository = marketRepository;
            _companyPriceRepository = companyPriceRepository;
        }

        public async Task<GenericResponse<IEnumerable<CompanyModel>>> GetAllCompanies()
        {
            try
            {
                var items = await _companyRepository.GetAllCompanies();

                return new GenericResponse<IEnumerable<CompanyModel>>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = items
                };
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[GetAllCompanies] exception occurred");
                return new GenericResponse<IEnumerable<CompanyModel>> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetAllCompanies] unknown exception occurred");
                return new GenericResponse<IEnumerable<CompanyModel>> { ResponseCode = ResponseCode.UnknownError };
            }
        }

        public async Task<GenericResponse<CompanyModel>> GetCompany(int id)
        {
            try
            {
                var item = await _companyRepository.GetCompanyById(id);

                return new GenericResponse<CompanyModel>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = item
                };
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[GetCompany] exception occurred, id: {id}", id);
                return new GenericResponse<CompanyModel> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetCompany] unknown exception occurred, id: {id}", id);
                return new GenericResponse<CompanyModel> { ResponseCode = ResponseCode.UnknownError };
            }
        }
        
        public async Task<GenericResponse<IEnumerable<MarketModel>>> GetAllMarkets()
        {
            try
            {
                var items = await _marketRepository.GetAllMarkets();

                return new GenericResponse<IEnumerable<MarketModel>>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = items
                };
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[GetAllMarkets] exception occurred");
                return new GenericResponse<IEnumerable<MarketModel>> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetAllMarkets] unknown exception occurred");
                return new GenericResponse<IEnumerable<MarketModel>> { ResponseCode = ResponseCode.UnknownError };
            }
        }

        public async Task<GenericResponse<MarketModel>> GetMarket(int id)
        {
            try
            {
                var item = await _marketRepository.GetMarketById(id);

                return new GenericResponse<MarketModel>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = item
                };
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[GetMarket] exception occurred, id: {id}", id);
                return new GenericResponse<MarketModel> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetMarket] unknown exception occurred, id: {id}", id);
                return new GenericResponse<MarketModel> { ResponseCode = ResponseCode.UnknownError };
            }
        }

        public async Task<GenericResponse<IEnumerable<CompanyPriceModel>>> GetAllPrices()
        {
            try
            {
                var items = await _companyPriceRepository.GetAllCompanyPrices();

                return new GenericResponse<IEnumerable<CompanyPriceModel>>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = items
                };
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[GetAllPrices] exception occurred");
                return new GenericResponse<IEnumerable<CompanyPriceModel>> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetAllPrices] Unknown exception occurred");
                return new GenericResponse<IEnumerable<CompanyPriceModel>> {ResponseCode = ResponseCode.UnknownError};
            }
        }

        public async Task<GenericResponse<CompanyPriceModel>> GetPrice(int id)
        {
            try
            {
                var item = await _companyPriceRepository.GetCompanyPriceById(id);

                return new GenericResponse<CompanyPriceModel>
                {
                    ResponseCode = ResponseCode.Success,
                    Data = item
                };
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[GetPrice] exception occurred, id: {id}", id);
                return new GenericResponse<CompanyPriceModel> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetPrice] Unknown exception occurred, id: {id}", id);
                return new GenericResponse<CompanyPriceModel> { ResponseCode = ResponseCode.UnknownError };
            }
        }

        public async Task<BaseResponse> SetPrice(int id, decimal price)
        {
            try
            {
                if (price <= 0)
                {
                    _logger.LogInformation("[SetPrice] invalid amount, id: {id}, price: {price}", id, price);
                    return new BaseResponse {ResponseCode = ResponseCode.InvalidAmount};
                }

                _logger.LogInformation("[SetPrice] changing amount, id: {id}, price: {price}", id, price);
                await _companyPriceRepository.SetCompanyPrice(id, price);
                
                return new BaseResponse { ResponseCode = ResponseCode.Success};
            }
            catch (BaseException ex)
            {
                _logger.LogInformation(ex, "[SetPrice] exception occurred, id: {id}, price: {price}", id, price);
                return new GenericResponse<CompanyPriceModel> { ResponseCode = ex.Code };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[SetPrice] unknown exception occurred, id: {id}, price: {price}", id, price);
                return new GenericResponse<CompanyPriceModel> { ResponseCode = ResponseCode.UnknownError };
            }
        }
    }
}
