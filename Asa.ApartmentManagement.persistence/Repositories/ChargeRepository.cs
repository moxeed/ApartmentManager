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

        private readonly ApplicationDbContext _context;

        public ChargeRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddChargeAsync(Charge charge)
        {
            _context.Add(charge);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChargeAsync(int chargeId)
        {
            var charge = _context.Charges.FirstOrDefault(c => c.ChargeId == chargeId);

            if (charge is null)
                throw new NullReferenceException($"Cannot Find Charge with {chargeId} id");

            _context.Charges.Remove(charge);

            await _context.SaveChangesAsync();

        }

        public Task GetChargeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
