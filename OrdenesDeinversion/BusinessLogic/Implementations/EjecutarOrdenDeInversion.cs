using Microsoft.Identity.Client;
using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.Helper;
using OrdenesDeinversion.Models.Negocio;
using OrdenesDeinversion.Services;

namespace OrdenesDeinversion.BusinessLogic.Implementations
{
    public class EjecutarOrdenDeInversion : IEjecutarOrdenDeInversion
    {
        private readonly IServicioOrdenesDeInversion servicioEjecutarOperacion;
        private readonly IServicioActivosFinanciero servicioActivosFinanciero;
        public EjecutarOrdenDeInversion(IServicioOrdenesDeInversion servicioEjecutarOperacion, IServicioActivosFinanciero servicioActivosFinanciero)
        {
            this.servicioEjecutarOperacion = servicioEjecutarOperacion;
            this.servicioActivosFinanciero = servicioActivosFinanciero;
        }

        public async Task PostEjecutarOperacion(OrdenParameters request)
        {
            try
            {
                var activos = await servicioActivosFinanciero.VerificarServicioFinanciero(request.Ticker);
                if (activos == null)
                {
                    throw new Exception("No existen activos por el ticker ingresado");
                }

                decimal? total = ReglasDeNegocio.CalcularTotalSegunTipoActivo(activos, request);

                if (total == null)
                {
                    throw new Exception("No se pudo calcular el total");
                }

                await servicioEjecutarOperacion.PostEjecutarOperacion(request, total);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
