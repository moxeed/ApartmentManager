using Microsoft.AspNetCore.Builder;

namespace Asa.ApartmentSystem.API.Middlewares
{
    public static class ExceptionHandlerExtention
    {
        public static void UseAsaExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
