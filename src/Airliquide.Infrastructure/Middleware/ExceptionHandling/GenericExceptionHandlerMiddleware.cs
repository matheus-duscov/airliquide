using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Airliquide.Infrastructure.Middleware.ExceptionHandling
{
    public class GenericExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GenericExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(
                    string.Format(
                        "Unhandled error: {0}",
                        "Ocorreu um erro inesperado"),
                    Encoding.UTF8);
            }
        }
    }
}
