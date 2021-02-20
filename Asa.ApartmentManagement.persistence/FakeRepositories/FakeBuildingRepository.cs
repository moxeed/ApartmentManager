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

        public async Task AddApartmentAsync(ApartmentDto apartment)
        {
            apartment.Id = _apartments.Max(a => a.Id) + 1;
            _apartments.Add(apartment);
        }

        public async Task AddBuildingAsync(BuildingDto building)
        {
            building.Id = _buildings.Max(a => a.Id) + 1;
            _buildings.Add(building);
        }

        public async Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            var building = _buildings.FirstOrDefault(b => b.Id == buildingName.BuildingId);
            if (building is null)
                throw new NullReferenceException();
            building.Name = buildingName.BuildingName;
        }

        public async Task<IEnumerable<ApartmentDto>> GetBuildingApartments(int buildingId)
        {
            return _apartments.Where(a => a.BuidlingId == buildingId);
        }

        public async Task<BuildingDto> GetBuildingAsync(int buildingId)
        {
            return _buildings.FirstOrDefault(b => b.Id == buildingId);
        }

        public async Task<IEnumerable<BuildingDto>> GetBuildingsAsync()
        {
            return _buildings;
        }
    }
}
