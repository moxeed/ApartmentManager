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
        private readonly IBuildingRepository _buildingrepository;


        public BuildingManager(IBuildingRepository repository)
        {
            _buildingrepository = repository;
        }

        private void ValidateBuilding(BuildingDto building)
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

        private  void ValidateBuildingName(BuildingNameDto building)
        {
            if (string.IsNullOrWhiteSpace(building.BuildingName))
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty");
            }
        }

        private async Task ValidateApartment(ApartmentDto apartment)
        {
            const int MIN_AREA_FOR_UNIT = 20;
            if(apartment.Area < MIN_AREA_FOR_UNIT)
            {
                throw new ValidationException(ErrorCodes.Invalid_Area, $"Area of an Apartment can not be smaller than 20");
            }
            var building  = await  _buildingrepository.GetBuildingAsync(apartment.BuildingId);
            if(building.NumberOfUnits < apartment.Number)
            {
                throw new ValidationException(ErrorCodes.Max_Apartment_Number, $"Number Unit should not be greater than counts of building aparment");
            }

            foreach (var c in await _buildingrepository.GetBuildingApartments(building.BuildingId))
            {
                if(c.Number == apartment.Number)
                {
                    throw new ValidationException(ErrorCodes.Invalid_Apartment_Number, $"This apartment Number Already exists");
                }
            }

        }

        public async Task AddBuildingAsync(BuildingDto building)
        {
            ValidateBuilding(building);
            await _buildingrepository.AddBuildingAsync(building);
        }


        public Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            ValidateBuildingName(buildingName);
            return _buildingrepository.EditBuldingNameAsync(buildingName);
        }

        public Task<IEnumerable<BuildingDto>> GetBuildings()
        {
            return _buildingrepository.GetBuildingsAsync();
        }

        public async Task AddAppartment(ApartmentDto apartment)
        {
            await ValidateApartment(apartment);
            await _buildingrepository.AddApartmentAsync(apartment);   
        }

        public Task<IEnumerable<ApartmentDto>> GetApartmentsOfBuilding(int buildingId)
        {
            return _buildingrepository.GetBuildingApartments(buildingId);
        }
        public Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId)
        {
            return _buildingrepository.GetAllCurrentOwnerTenants(buildingId);
        }

        public async Task<int> GetBuildingIdOfOwnerTenant(int apartmentId)
        {
            var buildingId= await _buildingrepository.GetBuildingIdByApartmentId(apartmentId);
            return buildingId;
        }
    }
}
