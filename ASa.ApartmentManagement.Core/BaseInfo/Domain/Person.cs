using Asa.ApartmentManagement.Core.Common;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class Person : IEntity
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public ICollection<OwnerTenant> OwnerTenants { get; set; }
    }
}