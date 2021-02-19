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

        public ExpenseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<ICollection<Expens>> GetAllByDateAsync(DateTime from, DateTime to)
        {

            //TODO: GET all expenses in the That range of Time
            throw new NotImplementedException();
        }
    }
}
