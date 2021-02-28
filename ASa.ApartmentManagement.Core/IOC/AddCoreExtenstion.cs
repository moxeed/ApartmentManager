using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Asa.ApartmentManagement.Core.BaseInfo.Managers;
using Asa.ApartmentManagement.Core.ChargeCalculation.Formulas;

namespace Asa.ApartmentManagement.Core.IOC
{
    public static class AddCoreExtenstion
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IBuildingManager, BuildingManager>();
            services.AddScoped<IPersonManager, PersonManager>();
            services.AddScoped<IExpenseManager, ExpenseManager>();
            
            return services;
        }
    }
}
