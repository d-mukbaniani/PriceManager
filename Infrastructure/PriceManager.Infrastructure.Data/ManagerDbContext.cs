using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PriceManager.Infrastructure.Data.Entities;
using PriceManager.Infrastructure.Data.Seed;

namespace PriceManager.Infrastructure.Data
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Market> Markets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPrice> CompanyPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyData();
        }

    }
}
