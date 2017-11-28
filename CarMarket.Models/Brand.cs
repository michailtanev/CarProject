namespace CarMarket.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CarModel> Models { get; set; } //in case we want to see all models from specific brand; virtual for lazy loading
    }
}
