using OrdenesDeinversion.Models.Negocio;

namespace OrdenesDeinversion.BusinessLogic.Contracts
{
    public interface IEjecutarOrdenDeInversion
    {
        Task PostEjecutarOperacion(OrdenParameters request);
    }
}
