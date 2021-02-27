using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class ChargeApartment : Apartment
    {
        internal IEnumerable<(int PayerId, int DaysLived)> GetPayerResisdenceInfo(DateTime from, DateTime to)
        {
            return Payers.Where(p => p.From < to && p.To > from && !p.IsOwner)
                .Select(p => (p.PersonId,
                CalculateDaysLived(from, to, p)));

            //todo consider owner as payer when no one lives at this apartment
        }

        private int CalculateDaysLived(DateTime from, DateTime to, OwnerTenant payer)
        {
            var start = from > payer.From ? from : payer.From;
            var end = to > (payer.To ?? DateTime.Now) ? payer.To ?? DateTime.Now : to;

            return (end - start).Days;
        }
    }
}