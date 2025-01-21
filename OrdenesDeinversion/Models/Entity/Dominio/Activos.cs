using System.ComponentModel.DataAnnotations;

namespace OrdenesDeinversion.Models.Entity.Dominio
{
    public class Activos
    {
        [Key]
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Nombre { get; set; }
        public int TipoActivo { get; set; }
        public double PrecioUnitario { get; set; }
    }
}
