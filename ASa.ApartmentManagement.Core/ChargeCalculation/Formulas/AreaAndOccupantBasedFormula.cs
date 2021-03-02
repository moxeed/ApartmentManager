using Asa.ApartmentManagement.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{

    [CalculationFormula(FormulaType.AreaAndOccupantBase)]
    public class AreaAndOccupantBasedFormula : IFormula
    {
        const int AreaPercent = 50;
        public IEnumerable<(int payerId, int share)> CalculateShares(BuildingTimeSpanInfoService building, int amount, int apartmentId)
        {
            var areaFormula = new AreaBaseFormula();
            var occupantFormula = new OccupantBasedFormula();

            var areaShares = areaFormula.CalculateShares(building, amount * AreaPercent / 100, apartmentId);
            var occupantShares = areaFormula.CalculateShares(building, amount * (100 - AreaPercent) / 100, apartmentId);

            return areaShares.Join(occupantShares, a => a.payerId, o => o.payerId, (a, o) => (a.payerId, a.share + o.share));
        }
    }
}
