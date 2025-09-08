using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SecureAuthApi.Middleware
{
    public class RoleAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBody = context.Response.Body;
            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                context.Response.Body = originalBody; // reset stream
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(
                    "{\"error\": \"Access Denied. Admin role is required.\"}"
                );
            }
            else
            {
                newBody.Seek(0, SeekOrigin.Begin);
                await newBody.CopyToAsync(originalBody);
            }
        }
    }
}
