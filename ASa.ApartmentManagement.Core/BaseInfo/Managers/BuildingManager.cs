using System.Collections.Generic;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;

namespace Asa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class BuildingManager : IBuildingManager
    {
        private readonly IBuildingRepository _repository;

        public BuildingManager()//IBuildingRepository repository)
        {
            //_repository = repository;
        }

        public async Task AddBuildingAsync(BuildingDto building)
        {
            ValidateBuilding(building);
            await _repository.AddBuildingAsync(building);
        }

        public Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            ValidateBuildingName(buildingName);
            return _repository.EditBuldingNameAsync(buildingName);
        }

        private static void ValidateBuilding(BuildingDto building)
        {
            if (string.IsNullOrWhiteSpace(building.Name))
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty");
            }
            const int MINIMUM_BUILDING_UNITS_COUNT = 2;
            if (building.NumberOfUnits < MINIMUM_BUILDING_UNITS_COUNT)
            {
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Units, $"The number of units cannot be less than {MINIMUM_BUILDING_UNITS_COUNT }.");
            }
        }

        private static void ValidateBuildingName(BuildingNameDto building)
        {
            if (string.IsNullOrWhiteSpace(building.BuildingName))
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty");
            }
        }

        public Task<IEnumerable<BuildingDto>> GetBuildings()
        {
            return Task.Run(() => (IEnumerable<BuildingDto>)new List<BuildingDto>
            {
                new BuildingDto { Id = 1 }
            });
        }
    }
}
