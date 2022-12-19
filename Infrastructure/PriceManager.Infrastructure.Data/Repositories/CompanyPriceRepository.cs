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
    public class CompanyPriceRepository : ICompanyPriceRepository
    {
        private readonly ManagerDbContext _dbContext;

        public CompanyPriceRepository(ManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CompanyPriceModel>> GetAllCompanyPrices()
        {
            var items = await _dbContext
                .CompanyPrices
                    .Include(p => p.Company)
                    .Include(p => p.Market)
                .AsNoTracking()
                .Select(x => new CompanyPriceModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    Company = new CompanyModel
                    {
                        Id = x.Company.Id,
                        Name = x.Company.Name
                    },
                    Market = new MarketModel
                    {
                        Id = x.Market.Id,
                        Name = x.Market.Name
                    }
                }).ToListAsync();

            return items;
        }

        public async Task<CompanyPriceModel> GetCompanyPriceById(int id)
        {
            var items = await _dbContext
                .CompanyPrices
                .Include(p => p.Company)
                .Include(p => p.Market)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new CompanyPriceModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    Company = new CompanyModel
                    {
                        Id = x.Company.Id,
                        Name = x.Company.Name
                    },
                    Market = new MarketModel
                    {
                        Id = x.Market.Id,
                        Name = x.Market.Name
                    }
                }).ToListAsync();

            if (!items.Any())
                throw new BaseException { Code = ResponseCode.CompanyPriceNotFound };

            return items.Single();
        }

        public async Task SetCompanyPrice(int id, decimal price)
        {
            var item = (await _dbContext.CompanyPrices.FindAsync(id))
                       ?? throw new BaseException { Code = ResponseCode.CompanyPriceNotFound };
            item.Price = price;
            
            if (await _dbContext.SaveChangesAsync() == 0)
                throw new BaseException { Code = ResponseCode.UnknownError };

        }
    }
}
