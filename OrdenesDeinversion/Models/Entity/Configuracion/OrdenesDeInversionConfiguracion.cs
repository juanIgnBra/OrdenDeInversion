using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdenesDeinversion.Models.Entity.Dominio;
using System;

namespace OrdenesDeinversion.Models.Entity.Configuracion
{
    public class OrdenesDeInversionConfiguracion : IEntityTypeConfiguration<OrdenesDeInversion>
    {
        public void Configure(EntityTypeBuilder<OrdenesDeInversion> builder)
        {
            builder.Property(m => m.NombreDelActivo).IsRequired().HasColumnType("varchar(32)");
            builder.Property(m => m.MontoTotal).HasColumnType("decimal(18,2)");
            builder.Property(m => m.Precio).HasColumnType("decimal(18,2)");
            builder.Property(m => m.Operacion).HasColumnType("char(2)");
      
        }
    }
}
