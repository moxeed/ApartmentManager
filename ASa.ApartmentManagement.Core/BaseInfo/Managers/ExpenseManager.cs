using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class ExpenseManager : IExpenseManager
    {


        private readonly IExpenseRepository _expenseRepository;


        public ExpenseManager(IExpenseRepository repository)
        {
            _expenseRepository = repository;
        }

        private void ValidateExpense(ExpenseDto expense)
        {
            if (expense.To < expense.From)
            {
                throw new ValidationException(ErrorCodes.Invalid_Entrence_Time, $"Date entrance should not be greater than Exit Time ");
            }

        }

        public async Task AddExpenseAsync(ExpenseDto expense)
        {
            ValidateExpense(expense);
            await _expenseRepository.AddExpense(expense);
            
        }

        public Task EditExpenseAsync(ExpenseDto expense)
        {
            //TODO : Charges should be recalculate after a change in expense
            return _expenseRepository.EditExpense(expense);
        }

        public async Task DeleteExpenseAsync(int expenseId)
        {
            //TODO : Charges should be recalculate
            await _expenseRepository.DeleteExpense(expenseId);

        }
    }
}
