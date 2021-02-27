using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Asa.ApartmentManagement.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {

        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddExpense(ExpenseDto expense)
        {
            //todo move mapping
            var entry = new ExpenseInfo
            {
                Title = expense.Title,
                Amount = expense.Amount,
                ExpenseCategoryId = expense.ExpenseCategoryId,
                From = expense.From,
                To = expense.To
            };

            _context.ExpenseInfos.Add(entry);
            await _context.SaveChangesAsync();

            expense.ExpenseId = entry.ExpenseId;
        }

  

        public async Task DeleteExpense(int expenseid)
        {
            var expense = _context.ExpenseInfos.FirstOrDefault(c => c.ExpenseId == expenseid);

            if (expense is null)
                throw new NullReferenceException($"Cannot Find Expense with {expenseid} id");

            _context.ExpenseInfos.Remove(expense);

            await _context.SaveChangesAsync();
        }

        public async Task EditExpense(ExpenseDto expense)
        {
            if (!_context.ExpenseInfos.Any(c => c.ExpenseId == expense.ExpenseId))
                throw new NullReferenceException($"Cannot Find Expense with {expense.ExpenseId} id");

            //todo move mapping
            var entry = new ExpenseInfo
            {
                Title = expense.Title,
                ExpenseId = expense.ExpenseId,
                Amount = expense.Amount,
                ExpenseCategoryId = expense.ExpenseCategoryId,
                From = expense.From,
                To = expense.To
            };

            _context.ExpenseInfos.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllByDateAsync(DateTime from, DateTime to)
        {
            var expenses = await _context.ExpenseInfos.Include(c => c.ExpenseCategory).ToListAsync();
            return expenses.Project();
        }

        public async Task AddExpenseCategoryAsync(ExpenseCategoryDto expenseCategory)
        {
            var entry = new ExpenseCategory
            {
                ExpenseCategoryName = expenseCategory.ExpensCategoryName,
                FormulaType = expenseCategory.FormulaType
            };

            _context.ExpensCategories.Add(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseCategoryDto>> GetAllExpenseCategories()
        {
            var categories = await _context.ExpensCategories.ToListAsync();
            return categories.Select(p => new ExpenseCategoryDto
            {
                ExpensCategoryId = p.ExpenseCategoryId,
                ExpensCategoryName = p.ExpenseCategoryName,
                FormulaType = p.FormulaType
            });
        }
    }
}
