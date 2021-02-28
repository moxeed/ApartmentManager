using System;
using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class AddOwnerTenantRequest
    {
        [Required]
        public DateTime From { get; set; }

        public DateTime? To { get; set; }
        public bool IsOwner { get; set; }
        [Required]
        public int? OccupantCount { get; set; }
        [Required]
        public int PersonId {get ;set ;}
        [Required]
        public int ApartmentId { get; set; }
    }
}
