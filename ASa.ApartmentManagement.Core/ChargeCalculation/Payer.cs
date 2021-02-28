using System;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class Payer
    {
        public int OwnerTenantId { get; set; }
        public int OccupantCount { get; set; }
        public bool IsOwner { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int PersonId { get; set; }
        public int ApartmentId { get; set; }
        public ChargeApartment Apartment { get; set; }
    }
}