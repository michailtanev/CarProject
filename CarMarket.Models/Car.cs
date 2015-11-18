﻿namespace CarMarket.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ListingDate { get; set; }

        public string SellerId { get; set; }               //foreign key
        [Required]
        public virtual User Seller { get; set; }          //Navigation property; virtual for lazy loading

        public int CarModelId { get; set; }                //foreign key
        [Required]
        public virtual CarModel Model { get; set; }        //Navigation property; virtual for lazy loading

        public int? ImageId { get; set; }                 //foreign key
        public virtual Image Image { get; set; }

        public string Color { get; set; }
        public int? Mileage { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public int? NumberOfCylinders { get; set; }
        [StringLength(1000)]
        public string SellerNotes { get; set; }
    }
}
