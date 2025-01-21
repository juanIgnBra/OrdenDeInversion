namespace OrdenesDeinversion.BusinessLogic.Contracts
{
    public interface IConsultarOrdenDeInversion
    {
        Task<Models.Entity.Dominio.OrdenesDeInversion?> GetOperacion(int id);
    }
}
