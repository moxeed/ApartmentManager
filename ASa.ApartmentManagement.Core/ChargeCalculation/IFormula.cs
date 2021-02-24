using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public interface IFormula
    {
        List<(int payerId, int share)> CalculateShares(Building building, IEnumerable<(int payerId, int DaysLived)> payers, int amount, int apartmentId);
    }
}