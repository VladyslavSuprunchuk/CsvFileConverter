using FileConverter.DatabaseProvider;
using FileConverter.Services.Interfaces;
using FileConverter.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICsvService, CsvService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    context => context.UseNpgsql(builder.Configuration.GetConnectionString("MainDb")),
    ServiceLifetime.Scoped);

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
