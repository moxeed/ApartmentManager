using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BaseInfoDbContext _context;
        public PersonRepository(BaseInfoDbContext context)
        {
            _context = context;
        }

        public Task AddOwnerTenantAsync(OwnerTenantDto owner)
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

        public Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<OwnerTenantDto> GetCurrentOwnerTenantById(int ownertenantId)
        {
            throw new NotImplementedException();
        }
    }
}
