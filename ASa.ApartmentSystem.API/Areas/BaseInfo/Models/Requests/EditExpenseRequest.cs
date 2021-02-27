using System;
using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class EditExpenseRequest
    {
        [Required]
        public int? ExpenseId { get; set; }
        [Required]
        public int? ExpenseCategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int? Amount { get; set; }
        [Required]
        public DateTime? From { get; set; }
        [Required]
        public DateTime? To { get; set; }
    }
}