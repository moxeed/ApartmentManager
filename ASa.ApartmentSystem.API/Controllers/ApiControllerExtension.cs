using Asa.ApartmentSystem.API.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Asa.ApartmentSystem.API.Controllers
{
    public static class ApiControllerExtension
    {
        public static void ConfigureApiOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(c =>
            {
                c.InvalidModelStateResponseFactory =
                e => new BadRequestObjectResult(new ErrorResponse(e.ModelState, e.HttpContext.Request.Path));
            });
        } 
    }
}
