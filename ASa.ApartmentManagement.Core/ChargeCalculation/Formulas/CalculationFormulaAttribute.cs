using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]

    sealed class CalculationFormulaAttribute : Attribute
    {
        private Enum v;

        public CalculationFormulaAttribute(FormulaType v)
        {
            this.v = v;
        }

        public string FormulaTitle { get; internal set; }
    }
}
