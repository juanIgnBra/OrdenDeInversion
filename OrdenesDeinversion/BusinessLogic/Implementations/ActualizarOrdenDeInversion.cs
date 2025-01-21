using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.Helper;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;
using OrdenesDeinversion.Services;
using System;

namespace OrdenesDeinversion.BusinessLogic.Implementations
{
    public class ActualizarOrdenDeInversion : IActualizarOrdenDeInversion
    {
        private readonly IServicioOrdenesDeInversion servicioOrdenesDeInversion;
        private readonly IServicioActivosFinanciero servicioActivosFinanciero;
        public ActualizarOrdenDeInversion(IServicioOrdenesDeInversion servicioOrdenesDeInversion, IServicioActivosFinanciero servicioActivosFinanciero)
        {
            this.servicioOrdenesDeInversion = servicioOrdenesDeInversion;
            this.servicioActivosFinanciero = servicioActivosFinanciero;
        }

        public async Task<int?> ActualizarOperacion(OrdenParameters request, int id)
        {
            try
            {
                OrdenesDeInversion? ordenesDeInversion = await servicioOrdenesDeInversion.GetOrdenDeInversion(id);
                if (ordenesDeInversion == null)
                {
                    throw new Exception("No existen orden de inversion");
                }

                var activos = await servicioActivosFinanciero.VerificarServicioFinanciero(request.Ticker);
                if (activos == null)
                {
                    throw new Exception("No existen activos por el ticker ingresado");
                }

                ordenesDeInversion.IdDeLaCuenta = request.IdDeLaCuenta;
                ordenesDeInversion.Cantidad = request.Cantidad;
                ordenesDeInversion.Estado = (int)EstadoEnum.EJECUTADA;
                ordenesDeInversion.NombreDelActivo = request.NombreDelActivo;
                ordenesDeInversion.Operacion = request.Operacion;
                ordenesDeInversion.Precio = request.Precio;
                ordenesDeInversion.MontoTotal = ReglasDeNegocio.CalcularTotalSegunTipoActivo(activos, request);

                return await servicioOrdenesDeInversion.ActualizarOrdenDeInversion(ordenesDeInversion);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
