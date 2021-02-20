using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class Expense
    {
        public int ExpensId { get; set; }
        public decimal Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int ExpensCategoryId { get; set; }
        public ExpensCategory ExpensCategory { get; set; }
    }
}