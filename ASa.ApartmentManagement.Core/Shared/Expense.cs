using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Shared;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class Expense : IEntity
    {
        public int ExpenseId { get; set; }
        public int Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}