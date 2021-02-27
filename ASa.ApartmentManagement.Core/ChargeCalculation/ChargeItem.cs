using Asa.ApartmentManagement.Core.Common;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class ChargeItem : IEntity
    {
        public int ChargeItemId { get; set; }
        public int PayerId { get; set; }
        public int ExpenseId { get; set; }
        public int Amount { get; set; }
        public int ChargeId { get; set; }
    }
}