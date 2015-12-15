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
            SearchcarViewModel vm = new SearchcarViewModel();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Search(SearchcarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int mile = int.Parse(vm.CarModel);
                var con = new CarMarketDbContext();
                IEnumerable<Car> ca = con.Cars.Where(x => x.Mileage == mile);
                return PartialView("_SearchCar", ca);
            }
            return Json("Error");
        }
    }
}