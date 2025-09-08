var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(); // Add session

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSession(); // Use session
app.UseAuthorization();

app.MapRazorPages();

app.Run();
