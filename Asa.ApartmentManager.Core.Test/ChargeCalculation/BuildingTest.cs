using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Shared;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManager.Core.Test.ChargeCalculation
{
    public class BuildingTest
    {
        [Test]
        public void Building_Can_Calculate_Total_Area() 
        {
            var building = new ChargeBuilding
            {
                BuildingId = 1,
                Apartments = new List<ChargeApartment>
                {
                    new ChargeApartment { ApartmentId = 1, Area = 100 },
                    new ChargeApartment { ApartmentId = 1, Area = 120 },
                    new ChargeApartment { ApartmentId = 1, Area = 300 },
                }
            };
            var totalArea = building.Area;

            Assert.AreEqual(building.Apartments.Sum(a => a.Area), totalArea);
        }
        
        [Test]
        public void Building_Throws_Exception_If_Request_For_Not_Existed_Apartment_Area() 
        {
            var building = new ChargeBuilding
            {
                BuildingId = 1,
                Apartments = new List<ChargeApartment>
                {
                    new ChargeApartment { ApartmentId = 1, Area = 100 },
                    new ChargeApartment { ApartmentId = 1, Area = 120 },
                    new ChargeApartment { ApartmentId = 1, Area = 300 },
                }
            };
            
            Assert.Throws<ArgumentNullException>(() => building.GetApartmentArea(5));
        }

        [Test]
        public void Building_Gives_Correct_Area_If_Apartment_Exists() 
        {
            var targetApartment = new Apartment { ApartmentId = 2, Area = 120 };
            var building = new ChargeBuilding
            {
                BuildingId = 1,
                Apartments = new List<ChargeApartment>
                {
                    new ChargeApartment { ApartmentId = 1, Area = 100 },
                    new ChargeApartment { ApartmentId = 2, Area = 120 },
                    new ChargeApartment { ApartmentId = 1, Area = 300 },
                }
            };

            decimal area = -1;
            Console.WriteLine(area);
            Assert.DoesNotThrow(() => area = building.GetApartmentArea(targetApartment.ApartmentId));
            Console.WriteLine(targetApartment.Area);
            Assert.AreEqual(area, targetApartment.Area);
        }
    }
}
