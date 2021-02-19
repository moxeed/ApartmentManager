using System;
using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class AddApartmentRequest
    {
        const string MIN_APARTMENT_AREA = "20";

        [Required]
        [Range(typeof(decimal), MIN_APARTMENT_AREA, "79228162514264337593543950335")]
        public decimal? Area { get; set; }

        [Required]
        public int? Number { get; set; }
    }
}
