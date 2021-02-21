using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public Task<ICollection<Core.BaseInfo.Domain.ExpenseInfo>> GetAllByDateAsync(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
