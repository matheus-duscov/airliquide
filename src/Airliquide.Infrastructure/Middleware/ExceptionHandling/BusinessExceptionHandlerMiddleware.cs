using Airliquide.Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Airliquide.Infrastructure.Middleware.ExceptionHandling
{
    public class BusinessExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public BusinessExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BusinessException e)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(
                    string.Format(
                        "Business Error: {0}",
                        e.Message),
                    Encoding.UTF8);
            }
        }
    }
}
