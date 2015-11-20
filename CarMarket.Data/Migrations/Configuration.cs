//Snezhina
namespace CarMarket.Data.Migrations
{
    using Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CarMarketDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarMarketDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedUserWithCars(context);
        }

        private void SeedUserWithCars(CarMarketDbContext context)
        {
            var testUser = new User
            {
                Email = "test_user@abv.bg",
                UserName = "testUser",
                PhoneNumber = "888 789 678"
            };
           

            var existingTestUser = context.Users.Where(u => string.Compare(u.Email, testUser.Email, true) == 0).FirstOrDefault();
            if (existingTestUser == null)
            {
                this.userManager.Create(testUser, "123456");

                //car 1
                var car1 = new Car()
                {
                    Price = 134995,
                    ListingDate = new DateTime(2015,1,8),
                    Color = "Red",
                    Mileage = 1557,
                    Transmission = "6-Speed Manual",
                    Fuel = "Gasoline",
                    NumberOfCylinders = 8,
                    SellerNotes = "some info"
                };
                car1.Seller = testUser;
                var img = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                    "../CarMarket.Data/Migrations/imgs/ferrari.jpg")),
                    FileExtension = "jpg"
                };
                car1.Image = img;
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
                var car2 = new Car()
                {
                    Price = 58980,
                    ListingDate = new DateTime(2015, 8, 15),
                    Color = "Satin Cashmere Metallic",
                    Mileage = 12480,
                    Transmission = "8-Speed Automatic",
                    Fuel = "Gasoline",
                    NumberOfCylinders = 8,
                    SellerNotes = "some info"
                };
                car2.Seller = testUser;
                var img2 = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                    "../CarMarket.Data/Migrations/imgs/lexus.jpg")),
                    FileExtension = "jpg"
                };
                car2.Image = img2;
                var brand2 = new Brand()
                {
                    Name = "Lexus",
                };
                var carModel2 = new CarModel()
                {
                    Name = "LS 460 Base",
                    Year = 2013,
                    Brand = brand2
                };
                var ExistingModel2 = context.CarModels.Where(m => string.Compare(m.Name, carModel2.Name, true) == 0).FirstOrDefault();
                if (ExistingModel2 == null)
                {
                    car2.Model = carModel2;
                }
                else
                {
                    car2.Model = ExistingModel2;
                }
                //end car 2

                //car 3
                var car3 = new Car()
                {
                    Price = 55799,
                    ListingDate = new DateTime(2015, 10, 23),
                    Color = "White",
                    Mileage = 39697,
                    Transmission = "6-Speed Automatic",
                    Fuel = "Diesel",
                    NumberOfCylinders = 4,
                    SellerNotes = "some info"
                };
                car3.Seller = testUser;
                var img3 = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                    "../CarMarket.Data/Migrations/imgs/ford.jpg")),
                    FileExtension = "jpg"
                };
                car3.Image = img3;
                var brand3 = new Brand()
                {
                    Name = "Ford",
                };
                var carModel3 = new CarModel()
                {
                    Name = "F250 Lariat",
                    Year = 2014,
                    Brand = brand3
                };
                var ExistingModel3 = context.CarModels.Where(m => string.Compare(m.Name, carModel3.Name, true) == 0).FirstOrDefault();
                if (ExistingModel3 == null)
                {
                    car3.Model = carModel3;
                }
                else
                {
                    car3.Model = ExistingModel3;
                }
                //end car 3

                //car 4
                var car4 = new Car()
                {
                    Price = 95095,
                    ListingDate = new DateTime(2015, 11, 2),
                    Color = "Glacier White Metallic",
                    Mileage = 151,
                    Transmission = "8-Speed Automatic",
                    Fuel = "Gasoline",
                    NumberOfCylinders = 6,
                    SellerNotes = "some info"
                };
                car4.Seller = testUser;
                var img4 = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                    "../CarMarket.Data/Migrations/imgs/audi.jpg")),
                    FileExtension = "jpg"
                };
                car4.Image = img4;
                var brand4 = new Brand()
                {
                    Name = "Audi",
                };
                var carModel4 = new CarModel()
                {
                    Name = "A8 L 3.0T",
                    Year = 2015,
                    Brand = brand4
                };
                var ExistingModel4 = context.CarModels.Where(m => string.Compare(m.Name, carModel4.Name, true) == 0).FirstOrDefault();
                if (ExistingModel3 == null)
                {
                    car4.Model = carModel4;
                }
                else
                {
                    car4.Model = ExistingModel4;
                }
                //end car 4

                context.Cars.Add(car1);
                context.Cars.Add(car2);
                context.Cars.Add(car3);
                context.Cars.Add(car4);
                context.SaveChanges();
            }
        }
    }
}
