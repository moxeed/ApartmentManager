using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task  AddPersongAsync(PersonDto person);
        Task EditPersongAsync(PersonDto person);
        Task AddOwnerTenant(OwnerTenantDto owner);
        Task<IEnumerable<OwnerTenantDto>> GetAllOwnerTenants();
        Task EditOwnerTenantAsync(OwnerTenantDto owner);
    }
}
