using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using OrdenesDeinversion.Helper;
using OrdenesDeinversion.Models.Negocio;
using OrdenesDeinversion.BusinessLogic.Contracts;
using System.ComponentModel.DataAnnotations;
using OrdenesDeinversion.Models.Error;

namespace OrdenesDeinversion.Controllers
{
    [ApiController]
    [Route("v1")]
    public class PrincipalController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEjecutarOrdenDeInversion ejecutarOrdenDeInversion;
        private readonly IActualizarOrdenDeInversion actualizarOrdenDeInversion;
        private readonly IEliminarOrdenDeInversion eliminarOrdenDeInversion;
        private readonly IConsultarOrdenDeInversion consultarOrdenDeInversion;
        public PrincipalController(ILogger<PrincipalController> logger, IEjecutarOrdenDeInversion ejecutarOrdenDeInversion, IActualizarOrdenDeInversion actualizarOrdenDeInversion, IEliminarOrdenDeInversion eliminarOrdenDeInversion, IConsultarOrdenDeInversion consultarOrdenDeInversion)
        {
            this._logger = logger;
            this.ejecutarOrdenDeInversion = ejecutarOrdenDeInversion;
            this.actualizarOrdenDeInversion = actualizarOrdenDeInversion;
            this.eliminarOrdenDeInversion = eliminarOrdenDeInversion;
            this.consultarOrdenDeInversion = consultarOrdenDeInversion;
        }


        [Authorize]
        [HttpPost, Route("CrearOrdenDeInversion")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CrearOrdenDeInversion(OrdenParameters request)
        {
            try
            {
                await ejecutarOrdenDeInversion.PostEjecutarOperacion(request);
                return Ok("OK");
            }
            catch (Exception ex)
            {
               _logger.LogError($"CrearOrdenDeInversion_error : {JsonConvert.SerializeObject(ex)}".Sanitize());
                return StatusCode(500, new Error() { statusCode = 500, Detail = ex.Message, Message = ex?.StackTrace });
            }
        }
        [Authorize]
        [HttpPut, Route("ActualizarOrdenDeInversion")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ActualizarOrdenDeInversion(OrdenParameters request, [Required] int id)
        {
            try
            {
                await actualizarOrdenDeInversion.ActualizarOperacion(request, id);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ActualizarOrdenDeInversion_error : {JsonConvert.SerializeObject(ex)}".Sanitize());
                return StatusCode(500, new Error() { statusCode = 500, Detail = ex.StackTrace, Message = ex?.Message });
            }
        }
        [Authorize]
        [HttpDelete, Route("DeleteOrdenDeInversion")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrdenDeInversion([Required] int id)
        {
            try
            {
                await eliminarOrdenDeInversion.EliminarOperacion(id);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteOrdenDeInversion_error : {JsonConvert.SerializeObject(ex)}".Sanitize());
                return StatusCode(500, new Error() { statusCode = 500, Detail = ex.StackTrace, Message = ex?.Message });
            }
        }
        [Authorize]
        [HttpGet, Route("GetOrdenDeInversion")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrdenDeInversion([Required] int id)
        {
            try
            {
                var ordenDeInversion = await consultarOrdenDeInversion.GetOperacion(id);

                if (ordenDeInversion != null)
                    return Ok(ordenDeInversion);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetOrdenDeInversion_error : {JsonConvert.SerializeObject(ex)}".Sanitize());
                return StatusCode(500, new Error() { statusCode = 500, Detail = ex.StackTrace, Message = ex?.Message });
            }
        }

    }
}
