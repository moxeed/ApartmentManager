using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public interface IFormula
    {
        List<(int payerId, decimal share)> CalculateShares(Building building, IEnumerable<(int payerId, int DaysLived)> payers, decimal amount, int apartmentId);
    }
}