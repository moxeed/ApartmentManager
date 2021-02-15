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

        public async Task AddBuilding(BuildingDto building)
        {
            ValidateBuilding(building);
            building.Id = 10;
        }

        private static void ValidateBuilding(BuildingDto building)
        {
            const int MAX_BUILDING_NAME_LENGTH = 50;
            var buildingNameIsValid = string.IsNullOrWhiteSpace(building.Name) || building.Name.Length > MAX_BUILDING_NAME_LENGTH;
            if (buildingNameIsValid)
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty nor larger than {MAX_BUILDING_NAME_LENGTH} character");
            }
            const int MINIMUM_BUILDING_UNITS_COUNT = 1;
            if (building.NumberOfUnits < MINIMUM_BUILDING_UNITS_COUNT)
            {
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Units, $"The number of units cannot be less than {MINIMUM_BUILDING_UNITS_COUNT }.");
            }
        }

        public Task EditBuldingName(BuildingDto building)
        {
            throw new NotImplementedException();
        }
    }
}
