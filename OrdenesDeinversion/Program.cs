using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.BusinessLogic.Implementations;
using OrdenesDeinversion.DAL;
using OrdenesDeinversion.Models.Entity;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Services;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Context>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Context"));
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEjecutarOrdenDeInversion, EjecutarOrdenDeInversion>();
builder.Services.AddScoped<IServicioOrdenesDeInversion, ServicioOrdenesDeInversion>();
builder.Services.AddScoped<IServicioActivosFinanciero, ServicioActivosFinanciero>();
builder.Services.AddScoped<IEliminarOrdenDeInversion, EliminarOrdenDeInversion>();
builder.Services.AddScoped<IConsultarOrdenDeInversion, ConsultarOrdenDeInversion>();
builder.Services.AddScoped<IActualizarOrdenDeInversion, ActualizarOrdenDeInversion>();


//Entity

builder.Services.AddScoped<IUnitOfWork>((provider) =>
{
    Context modelDbContext = provider.GetRequiredService<Context>();
    return new UnitOfWork(modelDbContext);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
