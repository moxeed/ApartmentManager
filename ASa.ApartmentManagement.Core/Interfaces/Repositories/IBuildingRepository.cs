using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuildingAsync (BuildingDto building);
        Task EditBuldingNameAsync (BuildingNameDto buildingName);
        Task<BuildingDto> GetBuildingAsync(int buildingId);
        Task<IEnumerable<BuildingDto>> GetBuildingsAsync();
        Task AddApartmentAsync(ApartmentDto apartment);
        Task<IEnumerable<ApartmentDto>> GetBuildingApartments(int buildingId);
        Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId);
        Task<ChargeBuilding> GetChargeBuildingAsync(int buildingId);
        Task<int> GetBuildingIdByApartmentId(int apartmentId);
    
    }
}
