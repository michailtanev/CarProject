using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMarket.Web.Models
{
    public class SearchcarViewModel
    {
        [Display(Name = "Car Brand")]
        public string CarModel { get; set; }
    }
}