using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class BuildingManager : IBuildingManager
    {
        private readonly IBuildingRepository _repository;

        public BuildingManager(IBuildingRepository repository)
        {
            _repository = repository;
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
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty nor larger than {MAX_BUILDING_NAME_LENGTH} character");
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
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty nor larger than {MAX_BUILDING_NAME_LENGTH} character");
            }
        }
    }
}
