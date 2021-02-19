using System;
using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.Charge.Models.Requests
{
    public class BuildingChargeRequest
    {
        [Required]
        public int? BuildingId { get; set; }

        [Required]
        public DateTime? From { get; set; }

        [Required]
        public DateTime? To { get; set; }
    }
}