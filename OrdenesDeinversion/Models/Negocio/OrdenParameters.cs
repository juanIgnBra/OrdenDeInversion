using System.ComponentModel.DataAnnotations;

namespace OrdenesDeinversion.Models.Negocio
{
    public class OrdenParameters
    {
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
        [Required]
        public string Ticker { get; set; }

    }
}
