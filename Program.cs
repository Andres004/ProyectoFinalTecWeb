using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoFinal.Data;
using ProyectoFinal.Repositories;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configure Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Register Repositories
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

// 4. Register Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ITripService, TripService>();

// 5. Configure JWT Authentication
var key = builder.Configuration["Jwt:Key"] ?? "super_secret_key_12345_must_be_long_enough";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

var app = builder.Build();

// 6. Configure Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Important: Auth before Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();