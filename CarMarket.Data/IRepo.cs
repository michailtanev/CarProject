using CarMarket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Data
{
   public interface IRepo
    {
       IEnumerable<Car> SearchCar(string model); 
    }
}
