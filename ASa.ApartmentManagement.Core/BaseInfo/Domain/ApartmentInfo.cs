using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class ApartmentInfo : IEntity
    {
        public int ApartmentId { get; set; }
        public decimal Area { get; set; }
        public int Number { get; set; }
        public int BuidingId { get; set; }
        public BuildingInfo Building { get; set; }
    }
}