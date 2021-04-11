using Airliquide.Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Airliquide.Infrastructure.Middleware.ExceptionHandling
{
    public class InfrastructureExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public InfrastructureExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (InfrastructureException e)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(
                    string.Format(
                        "Infrastructure error: {0}",
                        e.Message),
                    Encoding.UTF8);
            }
        }
    }
}
