using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuildingAsync (BuildingDto building);
        Task EditBuldingNameAsync (BuildingNameDto buildingName);

        Task<Building> GetBuilding(int buildingId);
    }
}
