using Asa.ApartmentManagement.ApplicationServices.IOC;
using Asa.ApartmentManagement.Core.IOC;
using Asa.ApartmentManagement.Persistence.IOC;
using Asa.ApartmentSystem.API.Controllers;
using Asa.ApartmentSystem.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asa.ApartmentSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCore();
            services.AddServices();
            services.AddPersistence(Configuration);

            services.AddControllers();
            services.ConfigureApiOptions();
            services.AddCors(c => 
                c.AddPolicy("React", builder => 
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API-V1");
            });
            app.UseAsaExceptionHandler();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("React");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
