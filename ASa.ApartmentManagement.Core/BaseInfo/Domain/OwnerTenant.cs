using System;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class OwnerTenant
    {
        public int OwnerTenantId { get; set; }
        public int? OccupantCount { get; set; }
        public bool IsOwner { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        public int PersonId { get; set; }
        public int ApartmentId { get; set; }
        public Person Person { get; set; }
        public Apartment Apartment{ get; set; }
    }
}
