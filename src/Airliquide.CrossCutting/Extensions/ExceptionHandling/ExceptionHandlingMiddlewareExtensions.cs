using Airliquide.Infrastructure.Middleware.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Airliquide.CrossCutting.Extensions.ExceptionHandling
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static void UseExceptionHandlingMiddlewares(this IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseMiddleware<BusinessExceptionHandlerMiddleware>();
            app.UseMiddleware<InfrastructureExceptionHandlerMiddleware>();
            app.UseMiddleware<GenericExceptionHandlerMiddleware>();
        }
    }
}
