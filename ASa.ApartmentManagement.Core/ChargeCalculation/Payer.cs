using Asa.ApartmentManagement.Core.Common;
using System;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class Payer : IEntity
    {
        public int PayerId { get; set; }
        public int OccupantCount { get; set; }
        public bool IsOwner { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public DateTime ActualTo => To ?? DateTime.Now;
    }
}