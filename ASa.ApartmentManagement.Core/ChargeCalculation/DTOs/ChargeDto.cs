using System;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.DTOs
{
    public class ChargeDto
    {
        public DateTime CalculateDateTime { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
