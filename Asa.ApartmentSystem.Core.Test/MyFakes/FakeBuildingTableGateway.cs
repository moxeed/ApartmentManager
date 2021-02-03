using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Core.Test.MyFakes
{
    internal class FakeBuildingTableGateway : IBuildingTableGateway
    {
        public Task<int> InsertBuildingAsync(BuildingDTO building)
        {
           return Task.FromResult(1);
        }
    }
}
