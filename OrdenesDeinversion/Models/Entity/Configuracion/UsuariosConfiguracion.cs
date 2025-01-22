using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdenesDeinversion.Models.Entity.Dominio;

namespace OrdenesDeinversion.Models.Entity.Configuracion
{
    public class UsuariosConfiguracion : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
                builder.Property(m => m.Password).IsRequired().HasColumnType("varchar(max)");
                builder.Property(m => m.Username).HasColumnType("varchar(max)");    
        }
    }
}
