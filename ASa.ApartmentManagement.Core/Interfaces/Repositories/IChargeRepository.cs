using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{ 
    public interface IChargeRepository
    {
        Task AddChargeAsync(Charge charge);
        Task GetChargeAsync();
        Task DeleteChargeAsync(int chargeId); 
        
    }
}
