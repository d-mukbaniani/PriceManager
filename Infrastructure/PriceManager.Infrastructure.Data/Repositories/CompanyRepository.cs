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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ManagerDbContext _dbContext;

        public CompanyRepository(ManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CompanyModel>> GetAllCompanies()
        {
            var items = await _dbContext
                .Companies
                .AsNoTracking()
                .Select(x => new CompanyModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return items;
        }

        public async Task<CompanyModel> GetCompanyById(int id)
        {
            var items = await _dbContext
                .Companies
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new CompanyModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            if (!items.Any())
                throw new BaseException { Code = ResponseCode.CompanyNotFound };

            return items.Single();
        }
    }
}
