using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices
{
    public interface IOwnerTenenatApplicationService
    {
        Task EditOwnerTenantAsync(OwnerTenantDto ownerTenant);
    }
}
