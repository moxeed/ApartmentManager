using Asa.ApartmentManagement.Core.ChargeCalculation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Core.Interfaces.Repositories
{ 
    public interface IChargeRepository
    {
        void AddCharge(Charge charge);
        void DeleteCharge(int chargeId);

        Task<IEnumerable<Charge>> GetBuildingCharges(int buildingId, DateTime from, DateTime to);
        Task<IEnumerable<ChargeItem>> GetChargeApartmentChargesAsync(int apartmentId);
        Task<IEnumerable<ChargeItem>> GetChargePayerChargesAsync(int payerId);

        Task Commit();
    }
}
