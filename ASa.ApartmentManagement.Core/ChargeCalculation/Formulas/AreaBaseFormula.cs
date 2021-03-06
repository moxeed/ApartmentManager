﻿using Asa.ApartmentManagement.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{

    [CalculationFormula(FormulaType.AreaBased)]
    public class AreaBaseFormula : IFormula
    {
        public IEnumerable<(int payerId, int share)> CalculateShares(BuildingTimeSpanInfoService building, int amount, int apartmentId)
        {
            var payers = building.GetApartmentPayerResidenceInfos(apartmentId);
            var area = building.GetApartmentArea(apartmentId);
            var apartmentShare = amount * area / building.Area;
            var totalDays = payers.Sum(p => p.DaysLived);
            var shares = new List<(int payerId, int share)>();

            foreach (var payer in payers) 
            {
                shares.Add((payer.PayerId, (int)apartmentShare * payer.DaysLived / totalDays));
            }

            return shares;
        }
    }
}
