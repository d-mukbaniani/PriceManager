using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PriceManager.Infrastructure.Data.Entities
{
    public class CompanyPrice
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int MarketId { get; set; }
        [ForeignKey("MarketId")]
        public Market Market { get; set; }
        public decimal Price { get; set; }
    }
}
