using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class ExpenseMappingExtensions
    {

        public static ExpenseDto ToDto(this AddExpenseRequest addExpenseRequest)
        {
            return new ExpenseDto
            {
                ExpenseID = addExpenseRequest.ExpenseID,
                ExpenseCategoryID = addExpenseRequest.ExpenseCategoryID,
                Title = addExpenseRequest.Title ,
                Price = addExpenseRequest.Price , 
                From = addExpenseRequest.From , 
                To = addExpenseRequest.To
                
            };
        }

    }
}
