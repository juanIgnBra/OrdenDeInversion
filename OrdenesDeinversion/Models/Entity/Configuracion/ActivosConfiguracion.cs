using OrdenesDeinversion.Models.Entity.Dominio;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace OrdenesDeinversion.Models.Entity.Configuracion
{
    public class ActivosConfiguracion : IEntityTypeConfiguration<Activos>
    {
        public void Configure(EntityTypeBuilder<Activos> builder)
        {
            builder.Property(m => m.Nombre).IsRequired().HasColumnType("varchar(max)");
            builder.Property(m => m.Ticker).HasColumnType("varchar(max)");
            builder.Property(m => m.PrecioUnitario).HasColumnType("float");
        }
    }
}
