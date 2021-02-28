using Asa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class Charge : IEntity 
    {
        public Charge(int apartmentId, DateTime from, DateTime to)
        {
            ApartmentId = apartmentId;
            From = from;
            To = to;
            Items = new HashSet<ChargeItem>();
        }

        public int ChargeId { get; set; }
        public int ApartmentId { get; set; }
        public DateTime CalculateDateTime { get; set; } = DateTime.Now;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<ChargeItem> Items { get; set; }

        public void CalculateBuildingCharge(ChargeBuilding building, IEnumerable<ChargeExpense> expenses) 
        {
            var items = new List<ChargeItem>();
            foreach (var expense in expenses) 
            {
                var shares = expense.CalculateExpenseShares(building, this, ApartmentId);
                items.AddRange(shares.Select(s => new ChargeItem { 
                    Amount = s.amount, 
                    ExpenseId = expense.ExpenseId, 
                    PayerId = s.payerId 
                }));
            }
            Items = items;
        }
    }
}