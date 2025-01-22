using System.ComponentModel.DataAnnotations;

namespace OrdenesDeinversion.Models.Negocio
{
    public class OrdenParameters  
    {

        public int? IdDeLaCuenta { get; set; }
 
        public string? NombreDelActivo { get; set; }

        public int? Cantidad { get; set; }
   
        public decimal? Precio { get; set; }

        public string? Operacion { get; set; }

        public string? Ticker { get; set; }

    }
}
