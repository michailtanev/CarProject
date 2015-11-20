//Snezhina
namespace CarMarket.Data
{

    using Microsoft.AspNet.Identity.EntityFramework;
    using CarMarket.Domain;
    using System.Data.Entity;

    public class CarMarketDbContext : IdentityDbContext<User>
    {
        public CarMarketDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Brand> Brands { get; set; }
        public virtual IDbSet<CarModel> CarModels { get; set; }
        public virtual IDbSet<Image> Images { get; set; }

        public static CarMarketDbContext Create()
        {
            return new CarMarketDbContext();
        }
    }
}
