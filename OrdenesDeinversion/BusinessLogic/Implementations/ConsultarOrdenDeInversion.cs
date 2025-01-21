using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Services;

namespace OrdenesDeinversion.BusinessLogic.Implementations
{
    public class ConsultarOrdenDeInversion : IConsultarOrdenDeInversion
    {
        private readonly IServicioOrdenesDeInversion servicioOrdenesDeInversion;

        public ConsultarOrdenDeInversion(IServicioOrdenesDeInversion servicioOrdenesDeInversion)
        {
            this.servicioOrdenesDeInversion = servicioOrdenesDeInversion;
        }

        public Task<OrdenesDeInversion?> GetOperacion(int id)
        {
            try
            {
                return this.servicioOrdenesDeInversion.GetOrdenDeInversion(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
