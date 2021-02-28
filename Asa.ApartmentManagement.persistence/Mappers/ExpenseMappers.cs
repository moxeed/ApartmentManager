using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asa.ApartmentManagement.Persistence.Mappers
{
    public static class ExpenseMappers
    {
        public static ExpenseDto ToDto (this ExpenseInfo expense) 
        {
            return new ExpenseDto
            {
                Title = expense.Title,
                ExpenseCategoryId = expense.ExpenseCategoryId,
                ExpenseId = expense.ExpenseId,
                From = expense.From,
                To = expense.To,
                Amount = expense.Amount,
                ExpenseCategoryName = expense.ExpenseCategory.ExpenseCategoryName
            };
        }

        public static ExpenseInfo ToEntry(this ExpenseDto expense)
        {
            return new ExpenseInfo
            {
                Title = expense.Title,
                ExpenseCategoryId = expense.ExpenseCategoryId,
                ExpenseId = expense.ExpenseId,
                From = expense.From,
                To = expense.To,
                Amount = expense.Amount
            };
        }

        public static ChargeExpense ToChargExpense(this ExpenseInfo expense)
        {
            return new ChargeExpense
            {
                ExpenseId = expense.ExpenseId,
                From = expense.From,
                To = expense.To,
                Amount = expense.Amount,
                FormulaType = expense.ExpenseCategory.FormulaType
            };
        }

        public static IEnumerable<ExpenseDto> Project(this IEnumerable<ExpenseInfo> expense)
            => expense.Select(ToDto);
    }
}
