using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Managers
{
    public interface IExpenseManager
    {
        Task AddExpenseAsync(ExpenseDto expense);

        Task EditExpenseAsync(ExpenseDto expense);

        Task DeleteExpenseAsync(int expenseId);
    }
}
