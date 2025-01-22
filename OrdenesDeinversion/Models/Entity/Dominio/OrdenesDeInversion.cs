using System.ComponentModel.DataAnnotations;

namespace OrdenesDeinversion.Models.Entity.Dominio
{
    public class OrdenesDeInversion
    {

        [Key]
        public int? IdDeLaOrden { get; set; }
        public int? IdDeLaCuenta { get; set; }
        public string? NombreDelActivo { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public string? Operacion { get; set; }
        public int? Estado { get; set; }
        public decimal? MontoTotal { get; set; }


    }
}
