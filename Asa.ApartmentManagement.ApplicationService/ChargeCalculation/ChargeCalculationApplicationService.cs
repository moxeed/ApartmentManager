using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.ApplicationServices.ChargeCalculation
{
    class ChargeCalculationApplicationService
    {
        private readonly IBuildingRepository buildingRepository;
        private readonly IChargeRepository chargeRepository;
        private readonly IExpenseRepository expenseRepository;

        public ChargeCalculationApplicationService(IBuildingRepository buildingRepository, IChargeRepository chargeRepository, IExpenseRepository expenseRepository)
        {
            this.buildingRepository = buildingRepository;
            this.chargeRepository = chargeRepository;
            this.expenseRepository = expenseRepository;
        }

        public async Task CalculateCharge(int buildbingId, DateTime from, DateTime to) 
        {
            var expenses = await expenseRepository.GetChargeExpenseAsync();
            var budling = await buildingRepository.GetChargeBuildingAsync(buildbingId);

            var charges = budling.CalculateCharge(from, to, expenses);

            foreach (var charge in charges)
            {
                await chargeRepository.AddChargeAsync(charge);
            }
        }
    }
}
