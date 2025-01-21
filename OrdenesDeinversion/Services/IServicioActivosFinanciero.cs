using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;

namespace OrdenesDeinversion.Services
{
    public interface IServicioActivosFinanciero
    {
        Task<Activos?> VerificarServicioFinanciero(string ticker);
    }
}
