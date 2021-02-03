using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.BaseInfo.DataGateways
{
    public interface ITableGatwayFactory
    {
        IBuildingTableGateway CreateBuildingTableGateway();
        IApartmentTableGateway CreateIApartmentTableGateway();
    }
}
