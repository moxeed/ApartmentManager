using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        Task<ICollection<Expens>> GetAllByDateAsync(DateTime from, DateTime to);
    }
}
