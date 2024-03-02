using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;
using WebApiHotel.Helpers;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly INegocioReserva _negocioReserva;
        public ReservaController(INegocioReserva negocioReserva)
        {
            _negocioReserva = negocioReserva;
        }

        [HttpPost("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Reserva reserva)
        {

            // Verificar si el objeto usuario es nulo
            if (reserva == null)
            {
                return BadRequest("Los datos del reserva son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            reserva.CodigoReserva = Commons.GenerarCodigoAleatorio();
            var response = await _negocioReserva.Nuevo(reserva);

            if (response != null)
            {
                return Ok(reserva.CodigoReserva);
            }
            else
            {
                return BadRequest("No se pudo crear la reserva");
            }
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Reserva reserva)
        {

            // Verificar si el objeto usuario es nulo
            if (reserva == null)
            {
                return BadRequest("Los datos del reserva son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario

            var response = await _negocioReserva.Actualizar(reserva);

            if (response != null)
            {
                return Ok("reserva actualizada exitosamente");
            }
            else
            {
                return BadRequest("No se pudo actualizadar la reserva");
            }
        }

        [HttpGet("OntenerPorId{id}")]
        public async Task<ActionResult<Reserva>> GetById(int id)
        {
            return await _negocioReserva.ObtenerPorId(id);  
        }
        [HttpGet("OntenerPorCodigo{CodigoReserva}")]
        public async Task<ActionResult<Reserva>> GetById(string CodigoReserva)
        {
            return await _negocioReserva.GetReservaByCodigo(CodigoReserva);
        }
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _negocioReserva.Lista();
        }
    }
}
