using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class AddBuildingRequest
    {
        const int MIN_APARTMENT_COUNT = 2;

        [Required]
        [Range(MIN_APARTMENT_COUNT, int.MaxValue)]
        public int? ApartmentCount { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
