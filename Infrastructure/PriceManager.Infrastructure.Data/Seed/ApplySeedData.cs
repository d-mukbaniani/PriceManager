using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PriceManager.Infrastructure.Data.Entities;

namespace PriceManager.Infrastructure.Data.Seed
{
    public static class ApplySeedData
    {
        public static void ApplyData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(b =>
            {
                b.HasData(DataSeed.GetCompanies());
            });

            modelBuilder.Entity<Market>(b =>
            {
                b.HasData(DataSeed.GetMarkets());
            });

            modelBuilder.Entity<CompanyPrice>(b =>
            {
                b.HasData(DataSeed.GetCompanyPrices());
            });

        }
    }
}
