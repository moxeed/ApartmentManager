using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Asa.ApartmentSystem.API.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Contollers
{

    [Area("BaseInfo")]

    public class ExpenseController : ApiBaseController
    {

        private readonly IExpenseManager _expenseManerger;

        public ExpenseController(IExpenseManager expenseManerger)
        {
            _expenseManerger = expenseManerger;
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] AddExpenseRequest request)
        {
            var expense = request.ToDto();
            await _expenseManerger.AddExpenseAsync(expense);
            return Created(Request.Path, expense.WrapResponse(Request.Path));
        }


        [HttpPut]
        public async Task<IActionResult> EditExpense([FromBody] AddExpenseRequest request) 
        {
            var expense = request.ToDto();
            await _expenseManerger.EditExpenseAsync(expense);
            return Created(Request.Path, expense);
        }

    }
}


