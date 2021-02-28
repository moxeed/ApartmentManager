using System;

namespace Asa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ApartmentDto
    {
        public int ApartmentId { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        public decimal Area { get; set; }
        public int OccupantCount { get; set; }
    }
}
