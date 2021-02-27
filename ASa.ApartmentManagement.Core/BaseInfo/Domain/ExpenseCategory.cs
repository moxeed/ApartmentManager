using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class ExpenseCategory : IEntity
    {
        public int ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; }
        public FormulaType FormulaType { get; set; }
    }
}