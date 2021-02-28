using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ChargeDbContext _chargeContext;
        private readonly BaseInfoDbContext _baseInfoContext;

        public BuildingRepository(ChargeDbContext chargeContext, BaseInfoDbContext baseInfoContext)
        {
            _chargeContext = chargeContext;
            _baseInfoContext = baseInfoContext;
        }

        public Task AddApartmentAsync(ApartmentDto apartment)
        {
            throw new NotImplementedException();
        }

        public Task AddBuildingAsync(BuildingDto building)
        {
            throw new NotImplementedException();
        }

        public Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApartmentDto>> GetBuildingApartments(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<BuildingDto> GetBuildingAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetBuildingIdByUnit(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BuildingDto>> GetBuildingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChargeBuilding> GetChargeBuildingAsync(int buildingId)
            => _chargeContext.ChargeBuildings
                .Include(b => b.Apartments)
                .ThenInclude(a => a.Payers)
                .FirstOrDefaultAsync(b => b.BuildingId == buildingId);
    }
}
