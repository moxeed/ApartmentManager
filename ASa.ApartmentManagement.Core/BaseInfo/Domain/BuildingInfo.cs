using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class BuildingInfo : IEntity
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public ICollection<ApartmentInfo> Apartments { get; set; }
    }
}
