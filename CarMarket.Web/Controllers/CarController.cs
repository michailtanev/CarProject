using CarMarket.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMarket.Web.Controllers
{
    public class CarController : BaseController
    {
        // GET: Car
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
                    ImagePath = x.Image.Content,
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
    }
}