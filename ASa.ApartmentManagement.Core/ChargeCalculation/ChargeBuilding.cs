using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class ChargeBuilding : IEntity
    {
        public int BuildingId { get; set; }
        public ICollection<ChargeApartment> Apartments { get; set; }
        public decimal Area => Apartments.Sum(a => a.Area);

        public IEnumerable<Charge> CalculateCharge(DateTime from, DateTime to, IEnumerable<ChargeExpense> expenses) 
        {
            var charges = new List<Charge>();
            foreach (var expens in expenses) 
            {
                foreach (var apartment in Apartments)
                {
                    var charge = new Charge(apartment.ApartmentId, from, to);
                    charge.CalculateBuildingCharge(this, expens);
                    charges.Add(charge);
                }
            }
            return charges;
        }

        internal decimal GetApartmentArea(int apartmentId) 
        {
            var apartment = Apartments.FirstOrDefault(a => a.ApartmentId == apartmentId);
            if (apartment is null)
                throw new ArgumentNullException($"No Apartment With {apartmentId} Id Exists");

            return apartment.Area;
        }

        internal IEnumerable<(int PayerId, int DaysLived)> GetPayerResidenceInfos(DateTime from, DateTime to)
        {
            var payerResidenceInfos = new List<(int, int)>();
            foreach (var apartment in Apartments)
            {
                payerResidenceInfos.AddRange(apartment.GetPayerResisdenceInfo(from, to));
            }
            return payerResidenceInfos;
        }
        
        internal IEnumerable<(int PayerId, int DaysLived)> GetApartmentPayerResidenceInfos(DateTime from, DateTime to, int apartmentId)
        {
            var apartment = Apartments.FirstOrDefault(a => a.ApartmentId == apartmentId);
            if (apartment is null)
                throw new ArgumentNullException($"No Apartment With {apartmentId} Id Exists");

            return apartment.GetPayerResisdenceInfo(from, to);
        }
    }
}
