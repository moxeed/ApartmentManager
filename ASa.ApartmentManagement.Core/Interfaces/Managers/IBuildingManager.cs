using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Managers
{
    public interface IBuildingManager
    {
        Task AddBuildingAsync (BuildingDto building);
        Task EditBuldingNameAsync (BuildingNameDto building);
        Task<IEnumerable<BuildingDto>> GetBuildings();
        Task AddAppartment(ApartmentDto apartment);
        Task<IEnumerable<ApartmentDto>> GetApartmentsOfBuilding(int buildingId);
        Task<ApartmentDto> GetApartment(int apartmentId);
        Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants(int buildingId);
        Task<int> GetBuildingIdOfOwnerTenant(int apartmentId);
        Task<IEnumerable<OwnerTenantDto>> GetAllCurrrentOwnerOfApartment(int apartmentId);
    }
}


