using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class ChargeExpense : IEntity
    {
        public ChargeExpense(IFormula formula)
        {
            Formula = formula;
        }
        public ChargeExpense() { }
        public int ExpenseId { get; set; }
        public int Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public FormulaType FormulaType { get; set; }
        public IFormula Formula { get; set; }

        public IEnumerable<(int payerId, int amount)> CalculateExpenseShares(ChargeBuilding building, Charge charge, int apartmentId)
        {
            var intersectionStart = charge.From > From ? charge.From : From;
            var intersectionEnd = charge.To > To ? To : charge.To;

            if ((To - From).Days == 0)
                throw new InvalidOperationException("Invalid chagre was requested ");

            var currentRangeAmount = Amount * (intersectionEnd - intersectionStart).Days / (To - From).Days;
            var buildingService = new BuildingTimeSpanInfoService(building, From, To);
            return Formula.CalculateShares(buildingService, currentRangeAmount, apartmentId);
        }
    }
}