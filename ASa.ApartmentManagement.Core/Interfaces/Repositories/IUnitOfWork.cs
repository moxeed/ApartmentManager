using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IUnitOfwork: IDisposable
    {
        IBuildingRepository BuildingRepository { get; }
    }
}
