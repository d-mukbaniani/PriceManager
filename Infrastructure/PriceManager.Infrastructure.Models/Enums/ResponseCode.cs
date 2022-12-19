using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PriceManager.Infrastructure.Models.Enums
{
    public enum ResponseCode
    {
        [Display(Name = "Completed Successfully")]
        Success = 0,
        [Display(Name = "Invalid Login")]
        InvalidLogin,
        [Display(Name = "Company Not Found")]
        CompanyNotFound,
        [Display(Name = "Market Not Found")]
        MarketNotFound,
        [Display(Name = "CompanyPrice Not Found")]
        CompanyPriceNotFound,
        [Display(Name = "Invalid Amount")]
        InvalidAmount,
        [Display(Name = "Unknown Error")]
        UnknownError = -1
    }
}
