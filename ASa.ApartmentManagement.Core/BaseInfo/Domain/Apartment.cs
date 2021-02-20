using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public decimal Area { get; set; }
        public int Number { get; set; }
    }
}