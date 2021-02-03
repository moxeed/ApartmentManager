using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystem.Core.Test.MyFakes
{
    class TableGatewyFactory : ITableGatwayFactory
    {
        public IBuildingTableGateway CreateBuildingTableGateway()
        {
            return new FakeBuildingTableGateway();
        }

        public IApartmentTableGateway CreateIApartmentTableGateway()
        {
            throw new NotImplementedException();
        }
    }
}
