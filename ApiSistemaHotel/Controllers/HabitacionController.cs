using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly INegocioHabitacion _negocioHabitacion;
        public HabitacionController(INegocioHabitacion negocioHabitacion)
        {
            _negocioHabitacion = negocioHabitacion;
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitaciones()
        {
            return await _negocioHabitacion.Lista();
        }

        [HttpGet("ListaLibres")]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitacionesLibres([Required] DateTime fechaEntrada, [Required] DateTime fechaSalida)
        {
            return await _negocioHabitacion.ListaDisponibles( fechaEntrada,fechaSalida);
        }


        [HttpGet("ObtenerPorId{idHabitacion}")]
        public async Task<ActionResult<Habitacion>> GetHabitaciones(int idHabitacion)
        {
            return await _negocioHabitacion.ObtenerPorId(idHabitacion);
        }

        [HttpPost("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Habitacion habitacion)
        {

            // Verificar si el objeto usuario es nulo
            if (habitacion == null)
            {
                return BadRequest("Los datos de la habitacion son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioHabitacion.Nuevo(habitacion);

            if (response != null)
            {
                return Ok("Habitacion creada con exito");
            }
            else
            {
                return BadRequest("No se pudo crear la Habitacion");
            }
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Habitacion habitacion)
        {

            // Verificar si el objeto usuario es nulo
            if (habitacion == null)
            {
                return BadRequest("Los datos de la Habitacion son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioHabitacion.Actualizar(habitacion);

            if (response != null)
            {
                return Ok("Habitacion actualizada con exito");
            }
            else
            {
                return BadRequest("No se pudo actualizar la Habitacion");
            }
        }

        [HttpDelete("Eliminar{idHabitacion}")]
        public async Task<IActionResult> Eliminar(int idHabitacion)
        {
            var habitacion = await _negocioHabitacion.Eliminar(idHabitacion);
            if (!habitacion)
            {
                return NotFound("Habitacion no encontrada");
            }
            return Ok("Habitacion eliminada");
        }

    }
}
