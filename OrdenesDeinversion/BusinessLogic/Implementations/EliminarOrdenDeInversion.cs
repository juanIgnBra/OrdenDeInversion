using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.Helper;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;
using OrdenesDeinversion.Services;

namespace OrdenesDeinversion.BusinessLogic.Implementations
{
    public class EliminarOrdenDeInversion : IEliminarOrdenDeInversion
    {
        private readonly IServicioOrdenesDeInversion servicioOrdenesDeInversion;

        public EliminarOrdenDeInversion(IServicioOrdenesDeInversion servicioOrdenesDeInversion)
        {
            this.servicioOrdenesDeInversion = servicioOrdenesDeInversion;
        }

        public async Task<int?> EliminarOperacion(int id)
        {
            try
            {
                OrdenesDeInversion? ordenesDeInversion = await servicioOrdenesDeInversion.GetOrdenDeInversion(id);
                if (ordenesDeInversion == null)
                {
                    throw new Exception("No existen orden de inversion");
                }
                return await servicioOrdenesDeInversion.EliminarOrdenDeInversion(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
