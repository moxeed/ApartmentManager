using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.FakeRepositories
{
    public class FakeExpenseRepository : IExpenseRepository
    {


        private readonly ICollection<ExpenseDto> _expenses  ;

        public async Task AddExpense(ExpenseDto expense)
        {
            expense.ExpenseID = _expenses.Max(a => a.ExpenseID) + 1;
            _expenses.Add(expense);
        }

        public async Task DeleteExpense(int expenseid)
        {
            foreach (var e in _expenses)
            {
                if (e.ExpenseID == expenseid)
                {
                    _expenses.Remove(e);
                }
            }
        }

        public Task EditExpense(ExpenseDto expense)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Core.BaseInfo.Domain.ExpenseInfo>> GetAllByDateAsync(DateTime from, DateTime to)
        {

            _expenses.Add(
                new ExpenseDto { ExpenseID = 1 }
            );

            return (Task<ICollection<Core.BaseInfo.Domain.ExpenseInfo>>)_expenses;
        }

    }
}
