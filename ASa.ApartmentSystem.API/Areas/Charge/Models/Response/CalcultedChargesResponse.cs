using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.Charge.Models.Response
{
    public class CalcultedChargesResponse
    {
        public int TotalCharge { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string FullName { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
