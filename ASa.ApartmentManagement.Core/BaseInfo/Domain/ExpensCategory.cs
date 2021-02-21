using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class ExpensCategory : IEntity
    {
        public int ExpensCategoryId { get; set; }
        public string ExpensCategoryName { get; set; }
        public FormulaType FormulaType { get; set; }
    }
}