using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace netCoreWorkshop.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate next;

        public APIKeyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.StartsWith("/api"))
            {
                if (!context.Request.Headers.ContainsKey("api-key") ||
                    context.Request.Headers["api-key"] != "asdfgh")
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Authentication required to execute this request");

                    return;
                }
            }

            // Call the next delegate/middleware in the pipeline
            await this.next(context);
        }
    }

    public static class APIKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIKey(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIKeyMiddleware>();
        }
    }
}
