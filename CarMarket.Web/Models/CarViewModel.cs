//Snezhina
namespace CarMarket.Web.Models
{
    using System;

    public class CarViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime ListingDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public byte[] ImagePath { get; set; }
    }
}