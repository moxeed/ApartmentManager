using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.Shared
{
    public class Apartment : IEntity
    {
        public int ApartmentId { get; set; }
        public decimal Area { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public ICollection<OwnerTenant> Payers { get; set; }
    }
}