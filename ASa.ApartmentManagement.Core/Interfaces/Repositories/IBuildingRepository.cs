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
        Task<Building> GetBuildingAsync(int buildingId);
        Task AddApartmentAsync(ApartmentDTO apartment);
        Task<IEnumerable<ApartmentDTO>> GetBuildingApartments();
    }
}
