using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]

    sealed class CalculationFormulaAttribute : Attribute
    {
        public FormulaType FormulaTitle { get; }

        public CalculationFormulaAttribute(FormulaType v)
        {
            this.FormulaTitle = v;
        }

    }
}
