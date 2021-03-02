using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{

    [CalculationFormula(FormulaType.OccupantBased)]
    public class OccupantBasedFormula : IFormula
    {
        public IEnumerable<(int payerId, int share)> CalculateShares(BuildingTimeSpanInfoService building, int amount, int apartmentId)
        {
            var occupants = building.GetPayerResidenceInfos();
            var total = occupants.Sum(o => o.DaysLived * o.OccupantCount);
            var shares = new List<(int payerId, int share)>();
            if (total == 0) return new List<(int payerId, int share)>();

            var payers = building.GetApartmentPayerResidenceInfos(apartmentId);
            foreach (var payer in payers) 
            {
                shares.Add((payer.PayerId, payer.OccupantCount * payer.DaysLived / total));
            }

            return shares;
        }
    }
}
