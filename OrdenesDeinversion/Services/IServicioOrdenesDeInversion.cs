using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;

namespace OrdenesDeinversion.Services
{
    public interface IServicioOrdenesDeInversion
    {
        Task PostEjecutarOperacion(OrdenParameters requestSAP, decimal? total);
        Task<OrdenesDeInversion?> GetOrdenDeInversion(int id);
        Task<int?> ActualizarOrdenDeInversion(OrdenesDeInversion ordenesDeInversion);
        Task<int?> EliminarOrdenDeInversion(int id);
    }
}
