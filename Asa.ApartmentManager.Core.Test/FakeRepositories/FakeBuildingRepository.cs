using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.FakeRepositories
{
    public class FakeBuildingRepository : IBuildingRepository
    {
        private readonly ICollection<BuildingDto> _buildings;
        private readonly ICollection<ApartmentDto> _apartments;


        public FakeBuildingRepository()
        {
            _buildings = new List<BuildingDto>();
            BuildingDto building = new BuildingDto { BuildingId = 0, Name = "Test", NumberOfUnits = 10 };
            _buildings.Add(building);
            _apartments = new List<ApartmentDto>();
        }

        public async Task AddApartmentAsync(ApartmentDto apartment)
        {
            apartment.ApartmentId = _apartments.Max(a => a.ApartmentId) + 1;
            _apartments.Add(apartment);
        }

        public async Task AddBuildingAsync(BuildingDto building)
        {
            building.BuildingId = _buildings.Max(a => a.BuildingId) + 1;
            _buildings.Add(building);
        }

        public async Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            var building = _buildings.FirstOrDefault(b => b.BuildingId == buildingName.BuildingId);
            if (building is null)
                throw new NullReferenceException();
            _buildings.Remove(building);
            building.Name = buildingName.BuildingName;
            _buildings.Add(building);
        }
        

        public Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OwnerTenantDto>> GetAllCurrrentOwnerOfApartment(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApartmentDto>> GetBuildingApartments(int buildingId)
        {
            return _apartments.Where(a => a.BuildingId == buildingId);
        }

        public async Task<BuildingDto> GetBuildingAsync(int buildingId)
        {
            return  _buildings.FirstOrDefault(b => b.BuildingId == buildingId);
        }

        public Task<int> GetBuildingIdByApartmentId(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetBuildingIdByUnit(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BuildingDto>> GetBuildingsAsync()
        {
            
            return await Task.Run(() => (IEnumerable<BuildingDto>)new List<BuildingDto>
            {
                new BuildingDto { BuildingId = 1 }
            });
        }

        public Task<ChargeBuilding> GetChargeBuildingAsync(int buildingId)
        {
            throw new NotImplementedException();
        }
    }
}
