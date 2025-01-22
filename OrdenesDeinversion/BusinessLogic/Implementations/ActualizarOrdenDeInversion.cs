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

                if (request.IdDeLaCuenta != 0)
                    ordenesDeInversion.IdDeLaCuenta = request.IdDeLaCuenta;

                if (request.Cantidad != 0)
                    ordenesDeInversion.Cantidad = request.Cantidad;

                ordenesDeInversion.Estado = (int)EstadoEnum.EJECUTADA;

                if (!string.IsNullOrEmpty(request.NombreDelActivo))
                    ordenesDeInversion.NombreDelActivo = request.NombreDelActivo;

                if (!string.IsNullOrEmpty(request.Operacion))
                    ordenesDeInversion.Operacion = request.Operacion;

                if (request.Precio != 0)
                    ordenesDeInversion.Precio = request.Precio;


                if (request.Precio != 0 && request.Cantidad != 0)
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
