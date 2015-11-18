using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Domain
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<CarModel> Models { get; set; } //in case we want to see all models from specific brand; virtual for lazy loading
    }
}
