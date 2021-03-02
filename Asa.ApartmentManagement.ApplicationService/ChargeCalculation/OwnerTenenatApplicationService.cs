using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.ApplicationServices.ChargeCalculation
{
    public class OwnerTenenatApplicationService : IOwnerTenenatApplicationService
    {
        private readonly IChargeCalculationApplicationService _chargeCalculationApplicationService;
        private readonly IPersonManager _personManager;

        public OwnerTenenatApplicationService(IChargeCalculationApplicationService chargeCalculationApplicationService
            , IPersonManager personManager)
        {
            _chargeCalculationApplicationService = chargeCalculationApplicationService;
            _personManager = personManager;
        }
        public async Task EditOwnerTenantAsync(OwnerTenantDto ownerTenant)
        {
            await _personManager.EditOwnerTenantAsync(ownerTenant);
            await _chargeCalculationApplicationService.ReCalculateChargeAsync(ownerTenant.ApartmentId, ownerTenant.From, ownerTenant.To);
        }
    }
}
