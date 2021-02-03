using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class SqlTableGatewayFactory: ITableGatwayFactory
    {
        string _connectionString;
        public SqlTableGatewayFactory(string connectionString)
        {
            _connectionString= connectionString;
        }

        public IBuildingTableGateway CreateBuildingTableGateway() => new BuildingTableGateway(_connectionString);

        public IApartmentTableGateway CreateIApartmentTableGateway() => new ApartmentTableGateway(_connectionString);
    }
}
