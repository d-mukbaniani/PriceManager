using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriceManager.Infrastructure.Data.Interfaces;
using PriceManager.Infrastructure.Models.Enums;
using PriceManager.Infrastructure.Models.Exceptions;
using PriceManager.Infrastructure.Models.Models;

namespace PriceManager.Infrastructure.Data.Repositories
{
    public class MarketRepository : IMarketRepository
    {
        private readonly ManagerDbContext _dbContext;

        public MarketRepository(ManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MarketModel>> GetAllMarkets()
        {
            var items = await _dbContext
                .Markets
                .AsNoTracking()
                .Select(x => new MarketModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return items;
        }

        public async Task<MarketModel> GetMarketById(int id)
        {
            var items = await _dbContext
                .Markets
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new MarketModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            if (!items.Any())
                throw new BaseException { Code = ResponseCode.MarketNotFound };

            return items.Single();
        }
    }
}
