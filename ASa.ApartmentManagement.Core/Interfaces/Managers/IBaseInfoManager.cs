using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Managers
{
    public interface IBaseInfoManager
    {
        Task<int> AddPerson(PersonDto person);


        Task<int> AddBuilding(BuildingDto person);


        Task<int> AddAparement(PersonDto person);
        IEnumerable<BuildingDto> GetBuidlingsInfo();
    }
}
