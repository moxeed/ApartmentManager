using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuilding(BuildingDto building);
        Task EditBuldingName(BuildingDto building);
    }
}
