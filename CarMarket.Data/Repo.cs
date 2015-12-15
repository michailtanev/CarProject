using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Data
{
   public  class Repo : IRepo
    {

        public IEnumerable<Domain.Car> SearchCar(string model)
        {
            using (var con = new CarMarketDbContext())
            {
                var carlist = con.Cars.Where(x => x.Model.Equals(model));
                return carlist;
            }
            return null;
        }
    }
}
