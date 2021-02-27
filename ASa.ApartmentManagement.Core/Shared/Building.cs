using Asa.ApartmentManagement.Core.Common;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.Shared
{
    public class Building : IEntity
    {
        public int BuildingId { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}
