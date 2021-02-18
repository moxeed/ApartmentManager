using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{
    public class AreaBaseFormula : IFormula
    {
        public List<(int payerId, decimal share)> CalculateShares(Building building, IEnumerable<(int payerId, int DaysLived)> payers, decimal amount, int apartmentId)
        {
            var area = building.GetApartmentArea(apartmentId);
            var apartmentShare = amount * area / building.Area;

            var totalDays = payers.Sum(p => p.DaysLived);
            var shares = new List<(int payerId, decimal share)>();
            foreach (var payer in payers) 
            {
                shares.Add((payer.payerId, apartmentShare * payer.DaysLived / totalDays));
            }

            return shares;
        }
    }
}
