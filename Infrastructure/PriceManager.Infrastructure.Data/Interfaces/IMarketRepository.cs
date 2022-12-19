using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PriceManager.Infrastructure.Models.Models;

namespace PriceManager.Infrastructure.Data.Interfaces
{
    public interface IMarketRepository
    {
        Task<IEnumerable<MarketModel>> GetAllMarkets();
        Task<MarketModel> GetMarketById(int id);
    }
}
