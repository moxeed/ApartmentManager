using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Asa.ApartmentManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asa.ApartmentManagement.Persistence.IOC
{
    public static class AddPersistenceExtenstion
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChargeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddDbContext<BaseInfoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IChargeRepository, ChargeRepository>();
            return services;
        }
    }
}
