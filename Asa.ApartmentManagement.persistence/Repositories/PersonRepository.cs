using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {


        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddOwnerTenant(OwnerTenantDto owner)
        {
            throw new NotImplementedException();
        }

        public Task AddPersongAsync(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public Task EditOwnerTenantAsync(OwnerTenantDto owner)
        {
            throw new NotImplementedException();
        }

        public Task EditPersongAsync(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OwnerTenantDto>> GetAllOwnerTenants()
        {
            throw new NotImplementedException();
        }
    }
}
