
namespace CarMarket.Data
{
    using System;
    using System.Collections.Generic;
    using CarMarket.Domain;
    using System.Data.Entity;

    public class UnitOfWorkData : IUnitOfWorkData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWorkData()
            : this(new CarMarketDbContext())
        {
        }
        public UnitOfWorkData(DbContext context)
        {
            this.context = context;
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

        
        public IRepository<Car> Cars
        {
            get { return this.GetRepository<Car>(); }
        }
        public IRepository<Brand> Brands
        {
            get { return this.GetRepository<Brand>(); }
        }

        public IRepository<CarModel> Models
        {
            get { return this.GetRepository<CarModel>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }
        public IRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }

    }
}
