using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Asa.ApartmentManagement.Core.BaseInfo.Managers;

namespace Asa.ApartmentManagement.Core.IOC
{
    public static class AddCoreExtenstion
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IBuildingManager, BuildingManager>();
            services.AddScoped<IPersonManager, PersonManager>();
            
            return services;
        }
    }
}
