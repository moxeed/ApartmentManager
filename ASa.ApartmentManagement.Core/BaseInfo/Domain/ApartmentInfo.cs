using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class ApartmentInfo : Apartment
    {
        public new BuildingInfo Building { get; set; }
        public ICollection<OwnerTenant> OwnerTenants { get; set; }
    }
}