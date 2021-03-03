using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.ChargeCalculation.DTOs;
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
        public async Task ReCalculateChargeAsync(int apartmentId, DateTime from, DateTime? to)
        {
            to ??= DateTime.MaxValue;
            var buildingId = await _buildingRepository.GetBuildingIdByApartmentId(apartmentId);
            var calculatedCharges = await _chargeRepository.GetBuildingCharges(buildingId, from, to.Value);
            var expenses = await _expenseRepository.GetChargeExpenseAsync(from, to.Value);
            var building = await _buildingRepository.GetChargeBuildingAsync(buildingId);

            var charges = new List<Charge>();

            foreach (var charge in calculatedCharges)
                charges.AddRange(building.CalculateCharge(charge.From, charge.To, expenses));
            
            foreach (var charge in charges)
            {
                _chargeRepository.AddCharge(charge);
            }

            foreach (var charge in calculatedCharges)
            {
                _chargeRepository.DeleteCharge(charge.ChargeId);
            }

            await _chargeRepository.Commit();
        }

        public Task<IEnumerable<CalculatedChargeDto>> GetPayerCalculatedChargesAsync() 
            =>_chargeRepository.GetPayerBuildingCharges();

        public Task<IEnumerable<ChargeDto>> GetCalculatedChargesAsync()
            => _chargeRepository.GetBuildingCharges();

    }
}
