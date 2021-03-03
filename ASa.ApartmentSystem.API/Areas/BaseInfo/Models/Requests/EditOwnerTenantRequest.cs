        using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class EditOwnerTenantRequest
    {

        public int OwnerTenantId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public bool IsOwner { get; set; }
        public int? OccupantCount { get; set; }

    }
}
