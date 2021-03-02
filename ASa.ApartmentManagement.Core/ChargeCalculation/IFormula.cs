using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public interface IFormula
    {
        IEnumerable<(int payerId, int share)> CalculateShares(BuildingTimeSpanInfoService building, int amount, int apartmentId);
    }
}