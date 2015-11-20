//Snezhina
namespace CarMarket.Data
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class CarMarketData : ICarMarketData
    {

        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public CarMarketData()
            : this(new CarMarketDbContext())
        {
        }
        public CarMarketData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Car> Cars
        {
            get
            {
                return this.GetRepository<Car>();
            }
        }
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return this.GetRepository<Brand>();
            }
        }

        public IRepository<CarModel> CarModels
        {
            get
            {
                return this.GetRepository<CarModel>();
            }
        }
        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }



        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

    }

}
