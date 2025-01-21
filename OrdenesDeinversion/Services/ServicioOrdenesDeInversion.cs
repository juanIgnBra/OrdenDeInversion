using OrdenesDeinversion.DAL;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;
using OrdenesDeinversion.Services.Entity;

namespace OrdenesDeinversion.Services
{
    public class ServicioOrdenesDeInversion : Service<OrdenesDeInversion>, IServicioOrdenesDeInversion
    {
        private readonly ILogger<ServicioOrdenesDeInversion> _logger;
        public ServicioOrdenesDeInversion(ILogger<ServicioOrdenesDeInversion> logger, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._logger = logger;
        }
        public async Task PostEjecutarOperacion(OrdenParameters requestSAP, decimal? total)
        {
            try
            {
                OrdenesDeInversion ordenParameters = new OrdenesDeInversion()
                {
                    Cantidad = requestSAP.Cantidad,
                    IdDeLaCuenta = requestSAP.IdDeLaCuenta,
                    NombreDelActivo = requestSAP.NombreDelActivo,
                    Operacion = requestSAP.Operacion,
                    Precio = requestSAP.Precio,
                    Estado = (int)EstadoEnum.ENPROCESO,
                    MontoTotal = total
                };
                await base.CreateAsync(ordenParameters);
            }
            catch (Exception ex)
            {
                _logger.LogError("error servicio: PostEjecutarOperacion. " + "mensaje error: " + ex.Message);
                throw;
            }
        }

        public async Task<OrdenesDeInversion?> GetOrdenDeInversion(int id)
        {
            OrdenesDeInversion? ordenesDeInversion = new OrdenesDeInversion();
            try
            {
                ordenesDeInversion = await base.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("error servicio: GetOrdenDeInversion. " + "mensaje error: " + ex.Message);
                throw;
            }
            return ordenesDeInversion;
        }

        public async Task<int?> ActualizarOrdenDeInversion(OrdenesDeInversion ordenesDeInversion)
        {
            int result = 0;
            try
            {
                result = await base.UpdateAsync(ordenesDeInversion);
            }
            catch (Exception ex)
            {
                _logger.LogError("error servicio: ActualizarOrdenDeInversion. " + "mensaje error: " + ex.Message);
                throw;
            }
            return result;
        }

        public async Task<int?> EliminarOrdenDeInversion(int id)
        {
            int result = 0;
            try
            {
                result = await base.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("error servicio: EliminarOrdenDeInversion. " + "mensaje error: " + ex.Message);
                throw;
            }
            return result;
        }

    }
}
