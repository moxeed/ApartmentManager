using Asa.ApartmentSystem.Infra.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.ApplicationService
{
    public class BaseInfoApplicationService
    {
        ITableGatwayFactory tableGatwayFactory;
        public BaseInfoApplicationService(string connectionString)
        {
            //HACK: This approach is not the best one, we will change it as soon as DI tools get introduced
            tableGatwayFactory = new SqlTableGatewayFactory(connectionString);
        }
        public async Task<int> CreateBuilding(string Name, int numberofUnits)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            var buildingDto = new BuildingDTO { Name = Name, NumberOfUnits = numberofUnits };
            await buildingManager.AddBuilding(buildingDto);
            return buildingDto.Id;
        }
        public async Task<IEnumerable<ApartmentUnitDTO>> GetUnitsForBuilding(int buildingId)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            var result = await buildingManager.GetAllApartmentUnits(buildingId);
            return result;
        }
    }
}
