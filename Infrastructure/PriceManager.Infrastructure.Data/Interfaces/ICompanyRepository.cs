using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PriceManager.Infrastructure.Models.Models;

namespace PriceManager.Infrastructure.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyModel>> GetAllCompanies();
        Task<CompanyModel> GetCompanyById(int id);
    }
}
