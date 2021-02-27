using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class ExpenseInfo : IEntity
    {
        public int ExpensId { get; set; }
        public int Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int ExpensCategoryId { get; set; }
        public ExpensCategory ExpensCategory { get; set; }
    }
}