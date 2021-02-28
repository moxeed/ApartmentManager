using Asa.ApartmentManagement.ApplicationServices.ChargeCalculation;
using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;

namespace Asa.ApartmentManagement.ApplicationServices.IOC
{
    public static class AddServicesExtenstion
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IChargeCalculationApplicationService, ChargeCalculationApplicationService>();
            return services;
        }
    }
}
