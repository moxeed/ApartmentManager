using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystem.Services.IOC
{
    public static class AddServicesExtenstion
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services;
        }
    }
}
