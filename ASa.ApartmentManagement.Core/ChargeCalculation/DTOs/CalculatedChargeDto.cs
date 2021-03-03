using System;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.DTOs
{
    public class CalculatedChargeDto
    {
        public int TotalCharge { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string FullName { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
