//Snezhina
namespace CarMarket.Data
{
    using CarMarket.Domain;

    public interface IUnitOfWorkData
    {
        IRepository<Car> Cars { get; }

        IRepository<Brand> Brands { get; }

        IRepository<CarModel> Models { get; }

        IRepository<User> Users { get; }

        IRepository<Image> Images { get; }

        int SaveChanges();
    }
}
