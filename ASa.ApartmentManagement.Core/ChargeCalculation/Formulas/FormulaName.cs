using System;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{
    public  class FormulaName
    {
        public FormulaName(string title, string typeName)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
        }

        public string Title { get; }
        public string TypeName { get; }
    }
}