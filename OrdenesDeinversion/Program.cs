using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.BusinessLogic.Implementations;
using OrdenesDeinversion.DAL;
using OrdenesDeinversion.Models.Entity;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Services;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<Context>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Context"));
});


// Agregar servicios de autenticación y autorización
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });


// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    // Definir el esquema de seguridad JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el token JWT con el prefijo Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();






builder.Services.AddScoped<IEjecutarOrdenDeInversion, EjecutarOrdenDeInversion>();
builder.Services.AddScoped<IServicioOrdenesDeInversion, ServicioOrdenesDeInversion>();
builder.Services.AddScoped<IServicioActivosFinanciero, ServicioActivosFinanciero>();
builder.Services.AddScoped<IEliminarOrdenDeInversion, EliminarOrdenDeInversion>();
builder.Services.AddScoped<IConsultarOrdenDeInversion, ConsultarOrdenDeInversion>();
builder.Services.AddScoped<IActualizarOrdenDeInversion, ActualizarOrdenDeInversion>();

builder.Services.AddScoped<IUsuarios, OrdenesDeinversion.BusinessLogic.Implementations.Usuarios>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();

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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

    });
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
