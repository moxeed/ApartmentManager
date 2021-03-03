using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Asa.ApartmentManagement.Persistence.Mappers;
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

        public async Task AddApartmentAsync(ApartmentDto apartment)
        {
            var entry = apartment.ToEntry();
            await _baseInfoContext.ApartmentInfos.AddAsync(entry);
            await _baseInfoContext.SaveChangesAsync();

            apartment.ApartmentId = entry.ApartmentId;
        }

        public async Task AddBuildingAsync(BuildingDto building)
        {
            var entry = building.ToEntry();
            await _baseInfoContext.BuildingInfos.AddAsync(entry);
            await _baseInfoContext.SaveChangesAsync();

            building.BuildingId = entry.BuildingId;
        }

        public async Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            var building = await _baseInfoContext.BuildingInfos.FirstOrDefaultAsync(b => b.BuildingId == buildingName.BuildingId);
            if (building == null)
            {
                throw new NullReferenceException($"There is not a building with given Id");
            }
            var entry = buildingName.ToEntry(building);
            _baseInfoContext.BuildingInfos.Update(entry);
            await _baseInfoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId)
        {
            var ownerTenants = await _baseInfoContext.OwnerTenants.Where(o => o.To == null).ToListAsync();
            return ownerTenants.Project();
        }

        public async Task<int> GetBuildingIdByApartmentId(int apartmentId)
        {
            var Apartment = await _baseInfoContext.ApartmentInfos.FirstOrDefaultAsync(b => b.ApartmentId == apartmentId);
            if(Apartment == null)
            {
                throw new NullReferenceException($"There is not such an apartment with given Id");
            }
            return Apartment.BuildingId;
        }

        public async Task<IEnumerable<ApartmentDto>> GetBuildingApartments(int buildingId)
        {
            var apartments = await _baseInfoContext.ApartmentInfos
                .Include(a => a.OwnerTenants)
                .Where(c => c.BuildingId == buildingId).ToListAsync();
            return apartments.Project();
        }

        public async Task<BuildingDto> GetBuildingAsync(int buildingId)
        {
            var building = await _baseInfoContext.BuildingInfos.FirstOrDefaultAsync(b => b.BuildingId == buildingId);
            return building.ToDto();
        }

        public async Task<IEnumerable<BuildingDto>> GetBuildingsAsync()
        {
            var building = await _baseInfoContext.BuildingInfos.ToListAsync();
            return building.Project();
        }

        public Task<ChargeBuilding> GetChargeBuildingAsync(int buildingId)
            => _chargeContext.ChargeBuildings
                .Include(b => b.Apartments)
                .ThenInclude(a => a.Payers)
                .FirstOrDefaultAsync(b => b.BuildingId == buildingId);

        public async Task<IEnumerable<OwnerTenantDto>> GetAllCurrrentOwnerOfApartment(int apartmentId)
        {
            var AllCurrentOwnerTenats =  await _baseInfoContext.OwnerTenants.Where(o => o.ApartmentId == apartmentId && o.To == null).ToListAsync();
            if(AllCurrentOwnerTenats == null)
            {
                throw new NullReferenceException($"There is no Owners or Tenants in this apartment");
            }
            return AllCurrentOwnerTenats.Project();
        }
    }
}
