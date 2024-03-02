using Datos.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabitacionController : ControllerBase
    {
        private readonly INegocioTipoHabitacion _negocioTipoHabitacion;
        public TipoHabitacionController(INegocioTipoHabitacion negocioTipoHabitacion)
        {
            _negocioTipoHabitacion = negocioTipoHabitacion;
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetTiposHabitacion()
        {
            return await _negocioTipoHabitacion.Lista();
        }

        [HttpGet("ObtenerPorId{idTipoHabitacion}")]
        public async Task<ActionResult<TipoHabitacion>> GetHabitaciones(int idTipoHabitacion)
        {
            return await _negocioTipoHabitacion.ObtenerPorId(idTipoHabitacion);
        }

        [HttpPost("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] TipoHabitacion  tipoHabitacion)
        {

            // Verificar si el objeto usuario es nulo
            if (tipoHabitacion == null)
            {
                return BadRequest("Los datos de la habitacion son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioTipoHabitacion.Nuevo(tipoHabitacion);

            if (response != null)
            {
                return Ok("Tipo de Habitacion creada con exito");
            }
            else
            {
                return BadRequest("No se pudo crear el Tipo de Habitacion");
            }
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] TipoHabitacion tipoHabitacion)
        {

            // Verificar si el objeto usuario es nulo
            if (tipoHabitacion == null)
            {
                return BadRequest("Los datos de tipo de habitacion son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioTipoHabitacion.Actualizar(tipoHabitacion);

            if (response != null)
            {
                return Ok("Tipo de Habitacion actualizada con exito");
            }
            else
            {
                return BadRequest("No se pudo actualizar el Tipo de Habitacion");
            }
        }

        [HttpDelete("Eliminar{idTipoHabitacion}")]
        public async Task<IActionResult> Eliminar(int idTipoHabitacion)
        {
            var habitacion = await _negocioTipoHabitacion.Eliminar(idTipoHabitacion);
            if (!habitacion)
            {
                return NotFound("el tipo de habitacion no se encontro");
            }
            return Ok("el tipo de habitacion fue eliminada");
        }
    }
}
