var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    Console.WriteLine($"Request received: {context.Request.Path}");
    await context.Response.WriteAsync("Hello from TestHelloApp!");
});
