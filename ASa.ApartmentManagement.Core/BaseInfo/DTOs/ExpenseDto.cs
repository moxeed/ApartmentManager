using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ExpenseDto
    {

        public int ExpenseID ;
        public int ExpenseCategoryID;
        public string Title;
        public int Price;
        public DateTime From;
        public DateTime To;
    }

}
