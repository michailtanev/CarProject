using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Domain
{
    public class CarModel
    {
        [Key]
        public int CarModelId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        public int BrandId { get; set; }               //foreign key
        [Required]
        public virtual Brand Brand { get; set; }      //Navigation property; virtual for lazy loading
    }
}
