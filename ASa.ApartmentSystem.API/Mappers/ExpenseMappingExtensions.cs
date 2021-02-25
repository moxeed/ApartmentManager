using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class ExpenseMappingExtensions
    {

        public static ExpenseDto ToDto(this AddExpenseRequest addExpenseRequest)
        {
            return new ExpenseDto
            {
                ExpenseCategoryID = addExpenseRequest.ExpenseCategoryId
                ?? throw new NullReferenceException($"{nameof(addExpenseRequest.ExpenseCategoryId)} Was Nulll"),
                Title = addExpenseRequest.Title ,
                Price = addExpenseRequest.Amount
                ?? throw new NullReferenceException($"{nameof(addExpenseRequest.Amount)} Was Nulll"), 
                From = addExpenseRequest.From
                ?? throw new NullReferenceException($"{nameof(addExpenseRequest.From)} Was Nulll"), 
                To = addExpenseRequest.To
                ?? throw new NullReferenceException($"{nameof(addExpenseRequest.To)} Was Nulll")
            };
        }

        public static ExpenseDto ToDto(this EditExpenseRequest editExpenseRequest)
        {
            return new ExpenseDto
            {
                ExpenseID  = editExpenseRequest.ExpenseId
                ?? throw new NullReferenceException($"{nameof(editExpenseRequest.ExpenseId)} Was Nulll"),
                ExpenseCategoryID = editExpenseRequest.ExpenseCategoryId
                ?? throw new NullReferenceException($"{nameof(editExpenseRequest.ExpenseCategoryId)} Was Nulll"),
                Title = editExpenseRequest.Title,
                Price = editExpenseRequest.Amount
                ?? throw new NullReferenceException($"{nameof(editExpenseRequest.Amount)} Was Nulll"),
                From = editExpenseRequest.From
                ?? throw new NullReferenceException($"{nameof(editExpenseRequest.From)} Was Nulll"),
                To = editExpenseRequest.To
                ?? throw new NullReferenceException($"{nameof(editExpenseRequest.To)} Was Nulll")
            };
        }

        public static ExpenseCategoryDto ToDto(this AddExpenseCategoryRequest addExpenseCategory)
        {
            return new ExpenseCategoryDto
            {
                ExpensCategoryName = addExpenseCategory.ExpensCategoryName,
                FormulaType = (FormulaType?)addExpenseCategory.FormulaType
                ?? throw new NullReferenceException($"{nameof(addExpenseCategory.FormulaType)} Was Nulll")
            };
        }
    }
}
