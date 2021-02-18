using Asa.ApartmentManagement.Core.ChargeCalculation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManager.Core.Test.ChargeCalculation
{
    public class ApartmentTest
    {
        [Test]
        public void Aaprtment_Can_Find_One_Payer_In_A_Interval() 
        {
            var apartment = new Apartment
            {
                ApartmentId = 1,
                Area = 1000,
                Payers = new List<Payer>
                {
                    new Payer{ IsOwner = false, From = DateTime.Now.AddDays(-30), To = DateTime.Now.AddDays(-15), OccupantCount = 3, PayerId = 1},
                    new Payer{ IsOwner = false, From = DateTime.Now.AddDays(-60), To = DateTime.Now.AddDays(-40), OccupantCount = 1, PayerId = 2},
                    new Payer{ IsOwner = false, From = DateTime.Now.AddDays(-25), To = DateTime.Now.AddDays(10), OccupantCount = 5, PayerId = 3},
                }
            };

            var payers = apartment.GetPayerResisdenceInfo(DateTime.Now.AddDays(-8), DateTime.Now.AddDays(5));

            Assert.AreEqual(payers.Count(), 1);
            Assert.NotNull(payers.FirstOrDefault());
            Assert.IsTrue(payers.Any(c => c.PayerId == 3));
            Assert.AreEqual(payers.First().DaysLived, 13);
        }
        
        [Test]
        public void Aaprtment_Can_Find_Payers_In_A_Interval() 
        {
            var apartment = new Apartment
            {
                ApartmentId = 1,
                Area = 1000,
                Payers = new List<Payer>
                {
                    new Payer{ IsOwner = false, From = DateTime.Now.AddDays(-30), To = DateTime.Now.AddDays(-15), OccupantCount = 3, PayerId = 1},
                    new Payer{ IsOwner = false, From = DateTime.Now.AddDays(-60), To = DateTime.Now.AddDays(-40), OccupantCount = 1, PayerId = 2},
                    new Payer{ IsOwner = false, From = DateTime.Now.AddDays(-25), To = DateTime.Now.AddDays(10), OccupantCount = 5, PayerId = 3},
                }
            };

            var payers = apartment.GetPayerResisdenceInfo(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(5));

            Assert.AreEqual(payers.Count(), 2);
            Assert.NotNull(payers.FirstOrDefault());
            Assert.IsTrue(payers.Any(c => c.PayerId == 3));
            Assert.IsTrue(payers.Any(c => c.PayerId == 1));
            Assert.IsTrue(payers.Any(c => c.DaysLived == 4));
            Assert.IsTrue(payers.Any(c => c.DaysLived == 25));
        }
    }
}
