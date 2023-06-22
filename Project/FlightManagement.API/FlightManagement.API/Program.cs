using FlightManagement.DataAccess;
using FlightManagement.Repository;
using FlightManagement.Repository.Implementations;
using FlightManagement.Services;
using FlightManagement.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("FlightManagement.API")));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Services
builder.Services.AddTransient<IPlaneRepository, PlaneRepository>();
builder.Services.AddScoped<IPlaneServices, PlaneServices>();
builder.Services.AddTransient<IAirportDepartureRepository, AirportDepartureRepository>();
builder.Services.AddScoped<IAirportDepartureServices, AirportDepartureServices>();
builder.Services.AddTransient<IArrivalAirportRepository, ArrivalAirportRepository>();
builder.Services.AddScoped<IArrivalAirportServices, ArrivalAirportServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
