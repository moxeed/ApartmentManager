using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.ChargeCalculation.Formulas;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Asa.ApartmentManagement.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {

        private readonly BaseInfoDbContext _baseInfoContext;
        private readonly ChargeDbContext _chargeContext;

        public ExpenseRepository(BaseInfoDbContext baseInfoContext, ChargeDbContext chargeContext)
        {
            _baseInfoContext = baseInfoContext;
            _chargeContext = chargeContext;
        }
        public async Task AddExpense(ExpenseDto expense)
        {
            var entry = expense.ToEntry();

            _baseInfoContext.ExpenseInfos.Add(entry);
            await _baseInfoContext.SaveChangesAsync();
            expense.ExpenseId = entry.ExpenseId;
        }
  
        public async Task DeleteExpense(int expenseid)
        {
            var expense = _baseInfoContext.ExpenseInfos.FirstOrDefault(c => c.ExpenseId == expenseid);

            if (expense is null)
                throw new NullReferenceException($"Cannot Find Expense with {expenseid} id");

            _baseInfoContext.ExpenseInfos.Remove(expense);
            await _baseInfoContext.SaveChangesAsync();
        }

        public async Task EditExpense(ExpenseDto expense)
        {
            if (!_baseInfoContext.ExpenseInfos.Any(c => c.ExpenseId == expense.ExpenseId))
                throw new NullReferenceException($"Cannot Find Expense with {expense.ExpenseId} id");
            var entry = expense.ToEntry();

            _baseInfoContext.ExpenseInfos.Update(entry);
            await _baseInfoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllAsync()
        {
            var expenses = await _baseInfoContext.ExpenseInfos.Include(c => c.ExpenseCategory).ToListAsync();
            return expenses.Project();
        }

        public async Task AddExpenseCategoryAsync(ExpenseCategoryDto expenseCategory)
        {
            var entry = new ExpenseCategory
            {
                ExpenseCategoryName = expenseCategory.ExpensCategoryName,
                FormulaType = expenseCategory.FormulaType
            };

            await _baseInfoContext.ExpensCategories.AddAsync(entry);
            await _baseInfoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseCategoryDto>> GetAllExpenseCategories()
        {
            var categories = await _baseInfoContext.ExpensCategories.ToListAsync();
            return categories.Select(p => new ExpenseCategoryDto
            {
                ExpensCategoryId = p.ExpenseCategoryId,
                ExpensCategoryName = p.ExpenseCategoryName,
                FormulaType = p.FormulaType
            });
        }

        public async Task<IEnumerable<ChargeExpense>> GetChargeExpenseAsync(DateTime from, DateTime to)
        {
            var expenses = await _baseInfoContext.ExpenseInfos.Where(e => e.From < to && e.To >= from)
                .Include(e => e.ExpenseCategory)
                .ToListAsync();
            
            return expenses.Select(e => 
            {
                var chargeExpense = e.ToChargExpense();
                chargeExpense.Formula = CalculationFormulaFactory.Create(chargeExpense.FormulaType);
                return chargeExpense;
            });
        }
    }
}
