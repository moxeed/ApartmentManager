using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly ChargeDbContext _context;

        public ChargeRepository(ChargeDbContext context)
        {
            _context = context;
        }

        public void AddCharge(Charge charge) => _context.Add(charge);

        public void DeleteCharge(int chargeId)
        {
            var charge = _context.Charges.FirstOrDefault(c => c.ChargeId == chargeId);
            if (charge is null)
                throw new NullReferenceException($"Cannot Find Charge with {chargeId} id");

            _context.Charges.Remove(charge);
        }

        public async Task<IEnumerable<ChargeItem>> GetChargeApartmentChargesAsync(int apartmentId)
            => await _context.ChargeItems.Where(i => _context.Payers.Any(p => p.ApartmentId == apartmentId && p.PersonId == i.PayerId)).ToListAsync();

        public async Task<IEnumerable<ChargeItem>> GetChargePayerChargesAsync(int payerId)
            => await _context.ChargeItems.Where(i => i.PayerId == payerId).ToListAsync();

        public Task Commit() => _context.SaveChangesAsync();

    }
}
