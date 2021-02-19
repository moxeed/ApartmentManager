using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfwork Create();
    }
}
