namespace CarMarket.Data.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CarMarketDbContext>
    {

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarMarketDbContext context)
        {
            this.SeedCarsWithBrandandCarModel(context);
        }

        private void SeedCarsWithBrandandCarModel(CarMarketDbContext context)
        {
            var users = context.Users.ToList();
            var car1 = new Car()
            {
                Price = 134995,
                ListingDate = DateTime.Now,
                Color = "Red",
                Mileage = 1557,
                Transmission = "6-Speed Manual",
                Fuel = "Gasoline",
                NumberOfCylinders = 8,
                SellerNotes = "some info"
            };
            var img = new Image()
            {
                Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                                                    "../CarMarket.Data/Migrations/imgs/ferrari.jpg")),
                FileExtension = "jpg"
            };
            car1.Image = img;
            

            car1.Seller = users[0];
            var brand = new Brand()
            {
                Name = "Ferrari",
            };
            var carModel = new CarModel()
            {
                Name = "F430 Spider",
                Year = 2007,
                Brand = brand
            };

           
            var ExistingModel = context.CarModels.Where(m => string.Compare(m.Name, carModel.Name, true) == 0).FirstOrDefault();
            if (ExistingModel == null)
            {
                car1.Model = carModel;
            }
            else
            {
                car1.Model = ExistingModel;
            }

            //car2
            //var car2 = new Car()
            //{
            //    Price = 100000,
            //    ListingDate = DateTime.Now,
            //    Color = "Silver Crystal Effect",
            //    Mileage = 3444,
            //    Transmission = "7-Speed Automatic with Auto-Shift",
            //    Fuel = "Gasoline",
            //    NumberOfCylinders = 4,
            //    SellerNotes = "some info"
            //};
            //var img2 = new Image()
            //{
            //    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            //                                       "../CarMarket.Data/Migrations/imgs/audi.jpg")),
            //    FileExtension = "jpg"
            //};
            //car2.Image = img2;
            //car2.Seller = users[1];

            //var carModel2 = new CarModel()
            //{
            //    Name = "RS 5 4.2",
            //    Year = 2014
            //};
            //var models2 = new HashSet<CarModel>();
            //models2.Add(carModel2);

            //var brand2 = new Brand()
            //{
            //    Name = "Audi",
            //    Models = models2
            //};
            //var ExistingBrand2 = context.Brands.Where(b => string.Compare(b.Name, brand2.Name, true) == 0).FirstOrDefault();
            //if (ExistingBrand2 == null)
            //{
            //    car2.Model.Brand = brand2;
            //}
            //else
            //{
            //    car2.Model.Brand = ExistingBrand2;
            //}
            context.Cars.Add(car1);
            //context.Cars.Add(car2);
            context.SaveChanges();
        }
    }
}
