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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            return services;
        }
    }
}
