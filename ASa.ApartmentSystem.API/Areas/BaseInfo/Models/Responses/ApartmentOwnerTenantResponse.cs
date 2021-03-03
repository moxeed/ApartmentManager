using Asa.ApartmentManagement.Core.BaseInfo.DTOs;

namespace Asa.ApartmentManagement.ApplicationServices.Models
{
    public class ApartmentOwnerTenantResponse
    {
        public ApartmentDto Apartment { get; set; }
        public OwnerTenantDto Owner { get; set; }
        public OwnerTenantDto Tenant { get; set; }
    }
}
