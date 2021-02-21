using Asa.ApartmentManagement.Core.Common;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class ChargeItem : IEntity
    {
        public int PayerId { get; set; }
        public int ExpensId { get; set; }
        public decimal Amount { get; set; }
    }
}