using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
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
                Amount = expense.Price,
                ExpensCategoryId = expense.ExpenseCategoryID,
                From = expense.From,
                To = expense.To
            };

            _context.ExpenseInfos.Add(entry);
            await _context.SaveChangesAsync();

            expense.ExpenseID = entry.ExpensId;
        }

  

        public async Task DeleteExpense(int expenseid)
        {
            var expense = _context.ExpenseInfos.FirstOrDefault(c => c.ExpensId == expenseid);

            if (expense is null)
                throw new NullReferenceException($"Cannot Find Expense with {expenseid} id");

            _context.ExpenseInfos.Remove(expense);

            await _context.SaveChangesAsync();
        }

        public async Task EditExpense(ExpenseDto expense)
        {
            if (!_context.ExpenseInfos.Any(c => c.ExpensId == expense.ExpenseID))
                throw new NullReferenceException($"Cannot Find Expense with {expense.ExpenseID} id");


            //todo move mapping
            var entry = new ExpenseInfo
            {
                ExpensId = expense.ExpenseID,
                Amount = expense.Price,
                ExpensCategoryId = expense.ExpenseCategoryID,
                From = expense.From,
                To = expense.To
            };

            _context.ExpenseInfos.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ExpenseInfo>> GetAllByDateAsync(DateTime from, DateTime to)
        {
            return await _context.ExpenseInfos.ToListAsync();
        }

        public async Task AddExpenseCategoryAsync(ExpenseCategoryDto expenseCategory)
        {
            var entry = new ExpensCategory
            {
                ExpensCategoryName = expenseCategory.ExpensCategoryName,
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
                ExpensCategoryId = p.ExpensCategoryId,
                ExpensCategoryName = p.ExpensCategoryName,
                FormulaType = p.FormulaType
            });
        }
    }
}
