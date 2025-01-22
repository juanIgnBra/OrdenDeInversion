using System.ComponentModel.DataAnnotations;

namespace OrdenesDeinversion.Models.Entity.Dominio
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
