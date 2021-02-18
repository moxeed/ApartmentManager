using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class Charge
    {
        public Charge(int apartmentId, DateTime from, DateTime to)
        {
            ApartmentId = apartmentId;
            From = from;
            To = to;
        }

        public int ChargeId { get; set; }
        public int ApartmentId { get; set; } 
        public DateTime CalculateDateTime { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<ChargeItem> Items { get; set; }

        public void CalculateBuildingCharge(Building building, Expens expens) 
        {
            var shares = expens.CalculateExpenseShares(building, this, ApartmentId);
            Items = shares.Select(s => new ChargeItem { 
                Amount = s.amount, 
                ExpensId = expens.ExpensId, 
                PayerId = s.payerId 
            }).ToList();
        }
    }
}