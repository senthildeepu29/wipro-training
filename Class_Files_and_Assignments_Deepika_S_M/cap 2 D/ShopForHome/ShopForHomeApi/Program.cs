using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopForHomeApi.Data;
using ShopForHomeApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS - allow angular dev server
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAngularDev", policy => policy
        .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// JWT Auth
var key = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = issuer,
        ValidAudience = issuer,
        IssuerSigningKey = signingKey
    };
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope()) {
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    seeder.Seed().GetAwaiter().GetResult();
}

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularDev");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
