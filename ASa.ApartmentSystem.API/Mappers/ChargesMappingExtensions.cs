using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentSystem.API.Areas.Charge.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class ChargesMappingExtensions
    {
        public static CalcultedChargesResponse ToModel(this CalculatedCharge ccharges)
        {
            return new CalcultedChargesResponse
            {
               ApartmentNumber = ccharges.ApartmentNumber , 
               FromDate = ccharges.FromDate , 
               ToDate = ccharges.ToDate, 
               FullName = ccharges.FullName ,
               TotalCharge = ccharges.TotalCharge
            };
        }
        public static IEnumerable<CalcultedChargesResponse> Project(this IEnumerable<CalculatedCharge> charges)
            => charges.Select(ToModel);
    }
}
