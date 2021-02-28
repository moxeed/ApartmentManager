using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.ApplicationServices.ChargeCalculation
{
    class ChargeCalculationApplicationService : IChargeCalculationApplicationService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IChargeRepository _chargeRepository;
        private readonly IExpenseRepository _expenseRepository;

        public ChargeCalculationApplicationService(IBuildingRepository buildingRepository, IChargeRepository chargeRepository, IExpenseRepository expenseRepository)
        {
            _buildingRepository = buildingRepository;
            _chargeRepository = chargeRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task CalculateChargeAsync(int buildbingId, DateTime from, DateTime to) 
        {
            var expenses = await _expenseRepository.GetChargeExpenseAsync(from, to);
            var building = await _buildingRepository.GetChargeBuildingAsync(buildbingId);

            var charges = building.CalculateCharge(from, to, expenses);

            foreach (var charge in charges)
            {
                _chargeRepository.AddCharge(charge);
            }

            await _chargeRepository.Commit();
        }
    }
}
