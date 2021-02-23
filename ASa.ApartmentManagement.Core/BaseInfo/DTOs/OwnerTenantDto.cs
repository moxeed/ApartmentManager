using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class OwnerTenantDto
    {
        public int OwnerTenantId { get; set; }
        public int? OccupantCount { get; set; }
        public bool IsOwner { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int PersonId { get; set; }
        public int ApartmentId { get; set; }

    }
}
