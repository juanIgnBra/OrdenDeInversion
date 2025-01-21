using OrdenesDeinversion.Models.Negocio;

namespace OrdenesDeinversion.BusinessLogic.Contracts
{
    public interface IActualizarOrdenDeInversion
    {
        Task<int?> ActualizarOperacion(OrdenParameters request, int id);
    }
}
