namespace SecureAuthApi.Middleware;

public class SecurityHeadersMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityHeadersMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var headers = context.Response.Headers;

        headers["X-Content-Type-Options"] = "nosniff";
        headers["X-Frame-Options"] = "DENY";
        headers["X-XSS-Protection"] = "0";
        headers["Referrer-Policy"] = "no-referrer";
        headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains; preload";
        headers["Content-Security-Policy"] = "default-src 'self'; frame-ancestors 'none'; base-uri 'self';";

        await _next(context);
    }
}
