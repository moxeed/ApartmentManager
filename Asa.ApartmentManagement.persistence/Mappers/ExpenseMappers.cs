using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
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

        public static IEnumerable<ExpenseDto> Project(this IEnumerable<ExpenseInfo> expense)
            => expense.Select(ToDto);
    }
}
