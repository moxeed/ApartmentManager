using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}
