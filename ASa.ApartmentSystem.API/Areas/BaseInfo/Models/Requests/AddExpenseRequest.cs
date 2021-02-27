using System;
using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class AddExpenseRequest
    {
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
