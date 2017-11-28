namespace CarMarket.Web.Controllers
{
    using CarMarket.Data;
    using Domain;
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    public class CRUDCarController : BaseController
    {
        [Authorize]
        public ActionResult Create()
        {
            var model = new AddCarViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AddCarViewModel m)
        {
            //var v = Request.Params;
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                byte[] content = null;
                string fileExtension = null;
                if (m.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        m.UploadedImage.InputStream.CopyTo(memory);
                        content = memory.GetBuffer();
                        fileExtension = m.UploadedImage.FileName.Split(new[] { '.' }).Last();
                      
                    }
                }

                Car car = new Car
                {
                    Price = m.Price,
                    Model = new CarModel { Name = m.ModelName, Year = m.ModelYear, Brand = new Brand { Name = m.BrandName } },
                    Color = m.Color,
                    Mileage = m.Mileage,
                    Transmission = m.Transmission,
                    Fuel = m.Fuel,
                    NumberOfCylinders = m.NumberOfCylinders,
                    ListingDate = DateTime.Now,
                    SellerId = user,
                    Image = new Image { Content = content, FileExtension= fileExtension}
                };

                this.Data.Cars.Add(car);
                this.Data.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
        
    }
}