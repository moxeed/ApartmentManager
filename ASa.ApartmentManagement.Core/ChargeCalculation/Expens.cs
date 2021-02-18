using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class Expens
    {
        public int ExpensId { get; set; }
        public decimal Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public FormulaType FormulaType { get; set; }
        public IFormula Formula { get; set; }

        public IEnumerable<(int payerId, decimal amount)> CalculateExpenseShares(Building building, Charge charge, int apartmentId)
        {
            var currentRangeAmount = Amount * (charge.To - charge.From).Days / (To - From).Days;
            var payers = building.GetApartmentPayerResidenceInfos(From, To, apartmentId);
            return Formula.CalculateShares(building, payers, currentRangeAmount, apartmentId);
        }
    }
}