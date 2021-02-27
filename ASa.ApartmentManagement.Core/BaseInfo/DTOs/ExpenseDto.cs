using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ExpenseDto
    {
        public int ExpenseId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
