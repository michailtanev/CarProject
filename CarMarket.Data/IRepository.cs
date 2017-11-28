namespace CarMarket.Data
{
    using System.Collections.Generic;
    using System.Linq;
   
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T GetById(int id);
        IEnumerable<Domain.Car> SearchCar(string model);
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);
    }
}
