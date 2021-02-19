using Asa.ApartmentManagement.Core.ChargeCalculation;
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
            var building = new Building
            {
                BuildingId = 1,
                Apartments = new List<Apartment>
                {
                    new Apartment { ApartmentId = 1, Area = 100 },
                    new Apartment { ApartmentId = 1, Area = 120 },
                    new Apartment { ApartmentId = 1, Area = 300 },
                }
            };
            var totalArea = building.Area;

            Assert.AreEqual(building.Apartments.Sum(a => a.Area), totalArea);
        }
        
        [Test]
        public void Building_Throws_Exception_If_Request_For_Not_Existed_Apartment_Area() 
        {
            var building = new Building
            {
                BuildingId = 1,
                Apartments = new List<Apartment>
                {
                    new Apartment { ApartmentId = 1, Area = 100 },
                    new Apartment { ApartmentId = 2, Area = 120 },
                    new Apartment { ApartmentId = 3, Area = 300 },
                }
            };
            
            Assert.Throws<ArgumentNullException>(() => building.GetApartmentArea(5));
        }

        [Test]
        public void Building_Gives_Correct_Area_If_Apartment_Exists() 
        {
            var targetApartment = new Apartment { ApartmentId = 2, Area = 120 };
            var building = new Building
            {
                BuildingId = 1,
                Apartments = new List<Apartment>
                {
                    new Apartment { ApartmentId = 1, Area = 100 },
                    new Apartment { ApartmentId = 3, Area = 300 },
                    targetApartment
                }
            };

            decimal area = -1;
            Assert.DoesNotThrow(() => area = building.GetApartmentArea(targetApartment.ApartmentId));
            Assert.AreEqual(area, targetApartment.Area);
        }
    }
}
