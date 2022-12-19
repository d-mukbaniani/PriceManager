﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PriceManager.Infrastructure.Data.Entities
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
