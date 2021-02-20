using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Asa.ApartmentManagement.Core.ChargeCalculation.Formulas
{
    public static class CalculationFormulaFactory
    {

        static List<FormulaName> formulaNames;
        static Dictionary<FormulaType, Type> formulaTypesDictionary;
        static Dictionary<FormulaType, IFormula> formulaInstances = new Dictionary<FormulaType, IFormula>();
        static readonly object lockToken = new object();
        public static List<FormulaName> GetAll()
        {
            if (formulaNames == null)
            {
                lock (lockToken)
                {
                    if (formulaNames == null)
                    {
                        ExtractFormulaNames();
                    }
                }
            }
            return formulaNames;
        }

        private static void ExtractFormulaNames()
        {
            formulaNames = new List<FormulaName>();
            ExtractFormulaTypes();
            foreach (var type in formulaTypesDictionary.Values)
            {
                ExtractFormulaNameFromAttribute(type);
            }
        }

        private static void ExtractFormulaNameFromAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(false);
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    if (attribute is CalculationFormulaAttribute attr)
                    {
                        FormulaName name = new FormulaName(attr.FormulaTitle, type.FullName);
                        formulaNames.Add(name);
                        break;
                    }
                }
            }
        }

        private static void ExtractFormulaTypes()
        {
            var domainAssembly = typeof(CalculationFormulaFactory).Assembly;
            var allTypes = domainAssembly.GetTypes();
            formulaTypesDictionary = new Dictionary<FormulaType, Type>();
            foreach (var type in allTypes)
            {
                var allInterfaces = type.GetInterfaces();
                if (allInterfaces != null && allInterfaces.Any(x => x == typeof(IFormula)))
                {
                    var attr = type.GetCustomAttribute<CalculationFormulaAttribute>();
                    formulaTypesDictionary.Add(attr.FormulaTitle, type);
                }
            }

        }

        public static IFormula Create(FormulaType typeFullName)
        {
            if (formulaInstances.ContainsKey(typeFullName))
            {
                return formulaInstances[typeFullName];
            }
            else
            {
                return CreateFormulaInstance(typeFullName);
            }
        }

        private static IFormula CreateFormulaInstance(FormulaType typeFullName)
        {
            if (formulaTypesDictionary.ContainsKey(typeFullName))
            {
                var formulaType = formulaTypesDictionary[typeFullName];
                var formula = Activator.CreateInstance(formulaType) as IFormula;
                formulaInstances.Add(typeFullName, formula);
                return formula;
            }
            throw new InvalidOperationException($"Cannot find a formula with type {typeFullName}.");
        }
    }
}

