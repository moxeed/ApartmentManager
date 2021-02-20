using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class OwnerTenant
    {
        public int OwnerTenantId { get; set; }
        public int PersonId { get; set; }
        public int ApartmentId { get; set; }
        public Person Person { get; set; }
        public Apartment Apartment{ get; set; }
    }
}
