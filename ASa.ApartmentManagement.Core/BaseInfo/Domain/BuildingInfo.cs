using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class BuildingInfo : Building
    {
        public string BuildingName { get; set; }
        public int ApartmentCount{ get; set; }
        public new ICollection<ApartmentInfo> Apartments { get; set; }
    }
}
