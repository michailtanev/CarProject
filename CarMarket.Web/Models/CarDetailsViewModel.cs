//Snezhina
namespace CarMarket.Web.Models
{
    using System;

    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime ListingDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int ImageId { get; set; }
        public string Color { get; set; }
        public int? Mileage { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public int? NumberOfCylinders { get; set; }
        public string SellerEmail { get; set; }
        public string SellerPhone { get; set; }
        public string SellerNotes { get; set; }
    }
}