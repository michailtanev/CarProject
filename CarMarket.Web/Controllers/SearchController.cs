using CarMarket.Data;
using CarMarket.Domain;
using CarMarket.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMarket.Web.Controllers
{
    public class SearchController : BaseController
    {
        
        [HttpGet]
        public ActionResult Search()
        {
            SearchcarViewModel model = new SearchcarViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Search(SearchcarViewModel model)
        {
            if (ModelState.IsValid)
            {
                string carBrand = Convert.ToString(model.CarModel);
                var db = new CarMarketDbContext();
                IEnumerable<Car> cars = db.Cars
                    .Where(x => x.Model.Brand.Name == carBrand) 
                    .ToList();                    
                return PartialView("_SearchCar", cars);
            }
            return Json("Error");
        }
    }
}