using System;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices
{
    public interface IChargeCalculationApplicationService
    {
        Task CalculateChargeAsync(int buildbingId, DateTime from, DateTime to);
        Task ReCalculateChargeAsync(int buildbingId, DateTime from, DateTime? to);
    }
}
