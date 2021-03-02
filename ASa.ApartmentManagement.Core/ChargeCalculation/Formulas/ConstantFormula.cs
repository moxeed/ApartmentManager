using Asa.ApartmentManagement.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{

    [CalculationFormula(FormulaType.Constant)]
    public class ConstantFormula : IFormula
    {
        public IEnumerable<(int payerId, int share)> CalculateShares(BuildingTimeSpanInfoService building, int amount, int apartmentId)
        {
            var payers = building.GetApartmentPayerResidenceInfos(apartmentId);
            var totalDays = payers.Sum(p => p.DaysLived);
            var shares = new List<(int payerId, int share)>();
            foreach (var payer in payers) 
            {
                shares.Add((payer.PayerId, amount * payer.DaysLived / totalDays));
            }

            return shares;
        }
    }
}
