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
    public class BuildingManager
    {
        ITableGatwayFactory _tablegatwayFactory;
        public BuildingManager(ITableGatwayFactory tablegatwayFactory)
        {
            _tablegatwayFactory = tablegatwayFactory;
        }
        public int JustForTest(int a, int b)
        {
            return a + b;
        }
        public async Task AddBuilding(BuildingDTO building)
        {
            ValidateBuilding(building);
            var tableGateway = _tablegatwayFactory.CreateBuildingTableGateway();
            var id = await tableGateway.InsertBuildingAsync(building).ConfigureAwait(false);
            building.Id = id;

        }

        private static void ValidateBuilding(BuildingDTO building)
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

        public async Task<IEnumerable<ApartmentUnitDTO>> GetAllApartmentUnits(int buildingId)
        {
            var tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            return  await tableGateway.GetAllByBuildingId(buildingId).ConfigureAwait(false);            
        }
    }
}
