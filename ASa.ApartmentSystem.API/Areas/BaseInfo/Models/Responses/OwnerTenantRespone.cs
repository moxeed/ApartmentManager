using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Responses
{
    public class OwnerTenantRespone
    {
        public int OwnerTenantId { get; set; }
        public int? OccupantCount { get; set; }
        public bool IsOwner { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

    }
}
