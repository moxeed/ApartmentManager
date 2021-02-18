using Microsoft.Extensions.DependencyInjection;

namespace Asa.ApartmentManagement.ApplicationServices.IOC
{
    public static class AddServicesExtenstion
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services;
        }
    }
}
