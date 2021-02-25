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

        Task<ICollection<BaseInfo.Domain.ExpenseInfo>> GetAllByDateAsync(DateTime from, DateTime to);
        Task AddExpenseCategoryAsync(ExpenseCategoryDto expenseCategory);
        Task<IEnumerable<ExpenseCategoryDto>> GetAllExpenseCategories();
    }
}
