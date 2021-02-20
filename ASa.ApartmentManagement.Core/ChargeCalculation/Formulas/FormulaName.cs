using Asa.ApartmentManagement.Core.Common;
using System;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{
    public  class FormulaName
    {
        public FormulaName(FormulaType title, string typeName)
        {
            Title = title;
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
        }

        public FormulaType Title { get; }
        public string TypeName { get; }
    }
}