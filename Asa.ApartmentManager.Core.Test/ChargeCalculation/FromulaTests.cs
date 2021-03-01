using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.ChargeCalculation.Formulas;
using Asa.ApartmentManagement.Core.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManager.Core.Test.ChargeCalculation
{
    public class FromulaTests
    {

        [SetUp]
        public void Setup()
        {
        }
    
        [Test]
        public void Get_All_Implemented_Formula_Type()
        {
            List<FormulaName> formulaNames = CalculationFormulaFactory.GetAll();
            List<FormulaName> CreatedFormulas = new List<FormulaName>();

            FormulaName areabased = new  FormulaName(FormulaType.AreaBased , "Asa.ApartmentManagement.Core.ChargeCalculation.Formulas.AreaBaseFormula");

            CreatedFormulas.Add(areabased);
            bool checkExistence = false;
            foreach (var formul in formulaNames) { 
                checkExistence = formulaNames.Any(item => item.TypeName == formul.TypeName );
                if (checkExistence)
                {
                    break;
                }
            }

            Assert.IsTrue(checkExistence);
        }


        [Test]
        public void Create_Formula_That_Not_Exist()
        {
            List<FormulaName> formulaNames = CalculationFormulaFactory.GetAll();
            IFormula formula = CalculationFormulaFactory.Create(FormulaType.AreaBased);
            Assert.IsNotNull(formula, "formala is created");   
        }

        [Test]
        public void Calculate_Charge_Based_On_AreaBasedFormuls()//?? is nesesary
        {
            IFormula formuls = new AreaBaseFormula();
            //formuls.CalculateShares();
        }

     

    }
}
