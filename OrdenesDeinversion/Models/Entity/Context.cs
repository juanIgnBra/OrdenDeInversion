using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using OrdenesDeinversion.Models.Entity.Configuracion;
using OrdenesDeinversion.Models.Entity.Dominio;
using System;

namespace OrdenesDeinversion.Models.Entity
{
    public class Context : DbContext
    {
        public const string MigrationsTableName = "Migraciones";

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }


        public DbSet<OrdenesDeInversion> ordenesDeInversion { get; set; }
        public DbSet<Activos> activos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrdenesDeInversionConfiguracion());
            modelBuilder.ApplyConfiguration(new ActivosConfiguracion());


            //Carga de datos al modelo


            modelBuilder.Entity<Activos>().HasData(
            new { Id = 1,  Nombre = "Apple", Ticker = "AAPL", TipoActivo = 1, PrecioUnitario = 177.97 },
            new { Id = 2, Nombre = "Alphabet Inc", Ticker = "GOOGL", TipoActivo = 1, PrecioUnitario = 138.21 },
            new { Id = 3, Nombre = "Microsoft", Ticker = "MSFT", TipoActivo = 1, PrecioUnitario = 329.04 },
            new { Id = 4, Nombre = "Coca Cola", Ticker = "KO", TipoActivo = 1, PrecioUnitario = 58.3 },
            new { Id = 5, Nombre = "Walmart", Ticker = "WMT", TipoActivo = 1, PrecioUnitario = 163.42 },
            new { Id = 6, Nombre = "BONOS ARGENTINA USD 2030 L.A", Ticker = "AL30", TipoActivo = 2, PrecioUnitario = 307.4 },
            new { Id = 7, Nombre = "Bonos Globales Argentina USD Step Up 2030", Ticker = "GD30", TipoActivo = 2, PrecioUnitario = 336.1 },
            new { Id = 8, Nombre = "Delta Pesos Clase A", Ticker = "Delta.Pesos", TipoActivo = 3, PrecioUnitario = 0.0181 },
            new { Id = 9, Nombre = "Fima Premium Clase A", Ticker = "Fima.Premium", TipoActivo = 3, PrecioUnitario = 0.0317 });



        }
    }



}