﻿using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ExpenseCategoryDto
    {
        public int ExpensCategoryId { get; set; }
        public string ExpensCategoryName { get; set; }
        public FormulaType FormulaType { get; set; }
    }
}