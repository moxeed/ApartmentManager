using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Managers
{
    public interface IPersonManager
    {

        Task AddPersonAsync(PersonDto person);
        Task EditPersonAsync(PersonDto person );
        Task AddOwnerTenantAsync(OwnerTenantDto ow);
        Task EditOwnerTenantAsync(OwnerTenantDto ow);
        Task<OwnerTenantDto> GetCurrentOwnerTenantById(int ownertenantId);
        Task<IEnumerable<PersonDto>> GetPersonsAsync();
    }
}
