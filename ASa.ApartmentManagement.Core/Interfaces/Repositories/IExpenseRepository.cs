using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        Task AddExpense(ExpenseDto expense);

        Task EditExpense(ExpenseDto expense);

        Task DeleteExpense(int expenseid);

        Task<IEnumerable<ExpenseDto>> GetAllAsync();
        Task AddExpenseCategoryAsync(ExpenseCategoryDto expenseCategory);
        Task<IEnumerable<ExpenseCategoryDto>> GetAllExpenseCategories();
        Task<IEnumerable<ChargeExpense>> GetChargeExpenseAsync(DateTime from, DateTime to);

    }
}
