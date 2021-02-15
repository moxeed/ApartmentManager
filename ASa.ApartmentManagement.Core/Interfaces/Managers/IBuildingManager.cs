using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Managers
{
    public interface IBuildingManager
    {
        Task AddBuilding (BuildingDto building);
        Task EditBuldingName(BuildingDto building);
    }
}
