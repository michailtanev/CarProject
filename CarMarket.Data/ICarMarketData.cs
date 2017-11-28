using System.Data.Entity;
using CarMarket.Domain;

namespace CarMarket.Data
{
    public interface ICarMarketData
    {
        IRepository<Brand> Brands { get; }
        IRepository<CarModel> CarModels { get; }
        IRepository<Car> Cars { get; }
        DbContext Context { get; }
        IRepository<Image> Images { get; }
        IRepository<User> Users { get; }

        void Dispose();
        int SaveChanges();
    }
}