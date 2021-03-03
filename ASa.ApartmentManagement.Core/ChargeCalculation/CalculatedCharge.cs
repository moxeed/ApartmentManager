using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class CalculatedCharge
    {
        public int TotalCharge { get; set; }
        public DateTime FromDate { get; set;  }
        public DateTime ToDate { get; set; }
        public string FullName { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
