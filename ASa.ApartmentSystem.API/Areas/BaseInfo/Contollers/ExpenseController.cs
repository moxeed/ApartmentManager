using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
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



    }
}


