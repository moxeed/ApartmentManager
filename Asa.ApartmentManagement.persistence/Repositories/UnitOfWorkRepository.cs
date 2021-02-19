using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkFactory
    {
        public IUnitOfwork Create() => new ApplicationDbContext();

    }
}
