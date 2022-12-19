using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Infrastructure.Models.Models
{
    public class CompanyPriceModel
    {
        public int Id { get; set; }
        public CompanyModel Company { get; set; }
        public MarketModel Market { get; set; }
        public decimal Price { get; set; }
    }
}
