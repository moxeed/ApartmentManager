using System;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class EditOwnerTenantRequest
    {
        public int ApartmentId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public bool IsOwner { get; set; }
        public int PersonId { get; set; }
        public int? OccupantCount { get; set; }
    }
}
