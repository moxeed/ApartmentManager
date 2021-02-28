using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Asa.ApartmentSystem.API.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Contollers
{

    [Area("BaseInfo")]

    public class ExpenseController : ApiBaseController
    {

        private readonly IExpenseManager _expenseManerger;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseManager expenseManerger,
            IExpenseRepository expenseRepository)
        {
            _expenseManerger = expenseManerger;
            _expenseRepository = expenseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] AddExpenseRequest request)
        {
            var expense = request.ToDto();
            await _expenseManerger.AddExpenseAsync(expense);
            return Created(Request.Path, expense.WrapResponse(Request.Path));
        }

        [HttpPut]
        public async Task<IActionResult> EditExpense([FromBody] EditExpenseRequest request)
        {
            var expense = request.ToDto();
            await _expenseManerger.EditExpenseAsync(expense);
            return Created(Request.Path, expense.WrapResponse(Request.Path));
        }

        [HttpDelete("{expenseId:int}")]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            await _expenseManerger.DeleteExpenseAsync(expenseId);
            return Ok(expenseId.WrapResponse(Request.Path));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpense()
        {
            var expenses = await _expenseRepository.GetAllAsync();
            return Ok(expenses.WrapResponse(Request.Path));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExpense(int id)
        {
            var expenses = await _expenseRepository.GetAllAsync();
            return Ok(expenses.FirstOrDefault(c => c.ExpenseId == id).WrapResponse(Request.Path));
        }

        [HttpPost("Category")]
        public async Task<IActionResult> AddExpenseCategory(AddExpenseCategoryRequest addExpenseCategory)
        {
            var expenseCategory = addExpenseCategory.ToDto();
            await _expenseManerger.AddExpenseCategory(expenseCategory);
            return Created(Request.Path, expenseCategory.WrapResponse(Request.Path));
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetAllExpenseCategory()
        {
            var expenseCategories = await _expenseRepository.GetAllExpenseCategories();
            return Ok(expenseCategories.WrapResponse(Request.Path));
        }
    }
}


