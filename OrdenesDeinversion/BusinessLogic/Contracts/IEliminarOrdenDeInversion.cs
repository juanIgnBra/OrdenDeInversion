using OrdenesDeinversion.Models.Negocio;

namespace OrdenesDeinversion.BusinessLogic.Contracts
{
    public interface IEliminarOrdenDeInversion
    {
        Task<int?> EliminarOperacion(int id);
    }
}
