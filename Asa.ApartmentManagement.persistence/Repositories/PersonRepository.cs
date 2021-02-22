using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task AddOwnerTenant(OwnerTenantDto owner)
        {
            throw new NotImplementedException();
        }

        public Task AddPersongAsync(PersonDto person)
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
