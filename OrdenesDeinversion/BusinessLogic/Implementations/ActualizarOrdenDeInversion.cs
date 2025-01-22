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

                if(string.IsNullOrEmpty(request.Ticker))
                    throw new Exception("Se debe ingresar un Ticker");

                var activos = await servicioActivosFinanciero.VerificarServicioFinanciero(request.Ticker);
                if (activos == null)
                {
                    throw new Exception("No existen activos por el ticker ingresado");
                }

                if (request.IdDeLaCuenta != null)
                    ordenesDeInversion.IdDeLaCuenta = request.IdDeLaCuenta;

                if (request.Cantidad != null)
                    ordenesDeInversion.Cantidad = request.Cantidad;

                ordenesDeInversion.Estado = (int)EstadoEnum.EJECUTADA;

                if (!string.IsNullOrEmpty(request.NombreDelActivo))
                    ordenesDeInversion.NombreDelActivo = request.NombreDelActivo;

                if (!string.IsNullOrEmpty(request.Operacion))
                    ordenesDeInversion.Operacion = request.Operacion;

                if (request.Precio != null)
                    ordenesDeInversion.Precio = request.Precio;


                if (request.Precio != null && request.Cantidad != null)
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
