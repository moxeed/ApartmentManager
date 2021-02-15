using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuildingAsync (BuildingDto building);
        Task EditBuldingNameAsync (BuildingNameDto buildingName);
    }
}
