
//Mihail

namespace CarMarket.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class AddCarViewModel
    {
        [Required]
        [Range(0, 9999999)]
        public decimal Price { get; set; }

        [Required]
        public string BrandName { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        [Range(0, 9999)]
        public int ModelYear { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }

        public string Color { get; set; }

        [Range(0, 99999)]
        public int? Mileage { get; set; }

        public string Transmission { get; set; }

        public string Fuel { get; set; }

        [Range(0, 99)]
        public int? NumberOfCylinders { get; set; }

        [StringLength(300)]
        public string SellerNotes { get; set; }
    }
}