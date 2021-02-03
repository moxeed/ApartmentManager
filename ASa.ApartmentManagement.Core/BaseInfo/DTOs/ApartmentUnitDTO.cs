using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ApartmentUnitDTO
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public int BuidlingId { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
    }
}
