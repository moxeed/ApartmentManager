using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class AddExpenseRequest
    {
        public int ExpenseID;
        public int ExpenseCategoryID;
        public string Title;
        public int Price;
        public DateTime From;
        public DateTime To;
    }
}
