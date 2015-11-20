using CarMarket.Web.Models;
//Snezhina
namespace CarMarket.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CarController : BaseController
    {
       
        public ActionResult CarDetails(int id)
        {
            var viewModel = this.Data.Cars.All().Where(x => x.CarId == id)
                .Select(x => new CarDetailsViewModel
                {
                    Id = x.CarId,
                    Price = x.Price,
                    ListingDate = x.ListingDate,
                    Brand = x.Model.Brand.Name,
                    Model = x.Model.Name,
                    ModelYear = x.Model.Year,
                    ImageId = x.Image.ImageId,
                    Color = x.Color,
                    Mileage = x.Mileage,
                    Transmission = x.Transmission,
                    Fuel = x.Fuel,
                    NumberOfCylinders = x.NumberOfCylinders,
                    SellerEmail = x.Seller.Email,
                    SellerNotes = x.SellerNotes

                }).FirstOrDefault();

            return View(viewModel);
        }

        public ActionResult Image(int id)
        {
            var image = this.Data.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}