using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class ChargeExpense : Expense
    {
        public ChargeExpense(IFormula formula)
        {
            Formula = formula;
        }
        public ChargeExpense() { }
        public FormulaType FormulaType { get; set; }
        public IFormula Formula { get; set; }

        public IEnumerable<(int payerId, int amount)> CalculateExpenseShares(ChargeBuilding building, Charge charge, int apartmentId)
        {
            var currentRangeAmount = Amount * (charge.To - charge.From).Days / (To - From).Days;
            var payers = building.GetApartmentPayerResidenceInfos(From, To, apartmentId);
            return Formula.CalculateShares(building, payers, currentRangeAmount, apartmentId);
        }
    }
}