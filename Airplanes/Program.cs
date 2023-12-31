using Airplanes.Contracts;
using Airplanes.Repositories;
using Airplanes.Utilities;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAirport, AirportRepository>();
builder.Services.AddScoped<IAirplane, AirplaneRepository>();
builder.Services.AddSingleton<DbContext>();
builder.Services.AddScoped<ICross, CrossRepository>();

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
