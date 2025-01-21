using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;

namespace OrdenesDeinversion.Helper
{
    public static class ReglasDeNegocio
    {
        const decimal COMISIONESACCION = 0.006M;
        const decimal COMISIONESBONO = 0.002M;
        const decimal IMPUESTOS = 0.21m;

        public static decimal? CalcularTotalSegunTipoActivo(Activos? activos, OrdenParameters request)
        {

            switch (activos?.TipoActivo)
            {
                case (int)TipoDeActivosEnum.FCI:
                    return (decimal)activos.PrecioUnitario * request.Cantidad;

                case (int)TipoDeActivosEnum.ACCION:
                    decimal totalSinComisiones = request.Precio * request.Cantidad;
                    decimal comisiones = totalSinComisiones * COMISIONESACCION;
                    decimal impuestos = comisiones * IMPUESTOS;
                    decimal totalConComisionesEImpuestos = totalSinComisiones + comisiones + impuestos;
                    return totalConComisionesEImpuestos;
                case (int)TipoDeActivosEnum.BONO:
                    // Variables para el precio y la cantidad recibidos
                    decimal precio = request.Precio;
                    int cantidad = request.Cantidad;

                    // Calcular el monto total sin comisiones
                    decimal totalSinComisionesBono = precio * cantidad;

                    // Calcular las comisiones (0.2% sobre el total)
                    decimal comisionesBono = totalSinComisionesBono * COMISIONESBONO;

                    // Calcular los impuestos (21% de las comisiones)
                    decimal impuestosBono = comisionesBono * IMPUESTOS;

                    // Calcular el monto final con comisiones e impuestos
                    decimal totalConComisionesEImpuestosBono = totalSinComisionesBono + comisionesBono + impuestosBono;

                    return totalConComisionesEImpuestosBono;
                default:
                    return null;

            }

        }



    }
}
