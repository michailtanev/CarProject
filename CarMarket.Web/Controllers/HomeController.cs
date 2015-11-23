//Snezhina
namespace CarMarket.Web.Controllers
{
    using CarMarket.Data;
    using Domain;
    using CarMarket.Web.Models;
    using System.Linq;
    using System.Web.Mvc;
    public class HomeController : BaseController
    {

        private ICarMarketData d;
        public HomeController(ICarMarketData r) 
        {
            this.d = r;
        }
        
       
        private IQueryable<CarViewModel> GetAllLaptops()
        { 
            var data = d.Cars.All().Select(x => new CarViewModel
            {
                Id = x.CarId,
                ImageId = x.Image.ImageId,
                Brand = x.Model.Brand.Name,
                Model = x.Model.Name,
                ModelYear = x.Model.Year,
                Price = x.Price,
                ListingDate = x.ListingDate
            }).OrderByDescending(x => x.ListingDate);

            return data;
        }
        public ActionResult Index()
        {
           
            var viewModel = GetAllLaptops();
            return View(viewModel);
        }
        
    }
}