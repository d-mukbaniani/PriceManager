using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PriceManager.Infrastructure.Data.Entities;

namespace PriceManager.Infrastructure.Data.Seed
{
    public static class DataSeed
    {

        public static IEnumerable<Company> GetCompanies()
        {
            var items = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Alphabet Inc"
                },
                new Company
                {
                    Id = 2,
                    Name = "Apple Inc"
                },
                new Company
                {
                    Id = 3,
                    Name = "Microsoft"
                },
                new Company
                {
                    Id = 4,
                    Name = "Netflix, Inc"
                },
                new Company
                {
                    Id = 5,
                    Name = "Tesla, Inc"
                }
            };

            return items;
        }

        public static IEnumerable<Market> GetMarkets()
        {
            var items = new List<Market>
            {
                new Market
                {
                    Id = 1,
                    Name = "NYSE"
                },
                new Market
                {
                    Id = 2,
                    Name = "NASDAQ"
                },
                new Market
                {
                    Id = 3,
                    Name = "Euronext"
                }
            };

            return items;
        }

        public static IEnumerable<CompanyPrice> GetCompanyPrices()
        {
            var items = new List<CompanyPrice> { };
            int id = 0;

            items.AddRange(
                from company in GetCompanies() 
                    from market in GetMarkets() 
                            select new CompanyPrice {
                                    Id = ++id, CompanyId = company.Id, MarketId = market.Id, Price = 0
                                }
                );

            return items;
        }

    }
}
