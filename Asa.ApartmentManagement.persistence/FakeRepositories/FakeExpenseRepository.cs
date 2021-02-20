using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.FakeRepositories
{
    public class FakeExpenseRepository : IExpenseRepository
    {
        public Task<ICollection<Core.BaseInfo.Domain.Expense>> GetAllByDateAsync(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
