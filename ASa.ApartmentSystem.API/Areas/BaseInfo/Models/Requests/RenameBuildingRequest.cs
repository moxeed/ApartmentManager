using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class RenameBuildingRequest
    {
        [Required]
        public int? BuildingId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
