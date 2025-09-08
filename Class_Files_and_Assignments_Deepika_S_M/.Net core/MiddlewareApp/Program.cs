var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ✅ Middleware to log requests and responses
app.Use(async (context, next) =>
{
    Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
});

// ✅ Middleware to handle errors with custom error page
app.UseExceptionHandler("/error.html");

// ✅ Enforce HTTPS
app.UseHttpsRedirection();

// ✅ Add Security Headers
app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; script-src 'self'; style-src 'self';";
    await next();
});

// ✅ Serve static files
app.UseStaticFiles();

// ✅ Fallback middleware
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from .NET Core Middleware App!");
});

app.Run();

