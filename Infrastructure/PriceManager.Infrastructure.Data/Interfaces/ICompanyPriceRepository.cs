using PriceManager.Infrastructure.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceManager.Infrastructure.Data.Interfaces
{
    public interface ICompanyPriceRepository
    {
        Task<IEnumerable<CompanyPriceModel>> GetAllCompanyPrices();
        Task<CompanyPriceModel> GetCompanyPriceById(int id);
        Task SetCompanyPrice(int id, decimal price);
    }
}
