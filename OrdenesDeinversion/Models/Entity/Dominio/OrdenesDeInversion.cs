using System.ComponentModel.DataAnnotations;

namespace OrdenesDeinversion.Models.Entity.Dominio
{
    public class OrdenesDeInversion
    {

        [Key]
        public int IdDeLaOrden { get; set; }
        [Required]
        public int IdDeLaCuenta { get; set; }
        [Required]
        public string NombreDelActivo { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Operacion { get; set; }
        public int? Estado { get; set; }
        public decimal? MontoTotal { get; set; }


    }
}
