using Flight_client_server;
using Flight_client_server.Profiles;

using Flights.DataAccess;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper((cfg) =>
{
    cfg.AddProfile<FlightProfile>();
});
builder.Services.AddDbContext<FlightContext>((db) =>
{
    db.UseNpgsql("Port=5434;Server=localhost;Database=Flight;UserId=postgres;Password=DoNotTellAnyone",
        (sql) =>
    {
        sql.MigrationsHistoryTable("Migrations");
        sql.MigrationsAssembly("DataAccess.Migrations");
    });
});
builder.Services.AddScoped<IFlightService, FlightService>();

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
