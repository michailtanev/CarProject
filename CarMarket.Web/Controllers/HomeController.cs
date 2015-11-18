//Snezhina
namespace CarMarket.Web.Controllers
{
    using CarMarket.Web.Models;
    using System.Linq;
    using System.Web.Mvc;
    public class HomeController : BaseController
    {
        private IQueryable<CarViewModel> GetAllLaptops()
        {
            var data = this.Data.Cars.All().Select(x => new CarViewModel
            {
                Id = x.CarId,
                ImagePath = x.Image.Content,
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