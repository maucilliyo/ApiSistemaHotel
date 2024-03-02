using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Interfaces;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly INegocioFactura _negocioFactura;
        public FacturaController(INegocioFactura negocioFactura)
        {
            _negocioFactura = negocioFactura;
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            return await _negocioFactura.Lista();
        }

        [HttpGet("ObtenerPorId{idFactura}")]
        public async Task<ActionResult<Factura>> GetHabitaciones(int idFactura)
        {
            var factura = await _negocioFactura.ObtenerPorId(idFactura);

            if (factura == null) 
            { 
                return NotFound("Factura no encontrada"); 
            }

            return Ok(factura);
        }

        [HttpPost("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Factura factura)
        {

            // Verificar si el objeto usuario es nulo
            if (factura == null)
            {
                return BadRequest("Los datos de la factura son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioFactura.Nuevo(factura);

            if (response != null)
            {
                return Ok("Usuario Factura creada exitosamente");
            }
            else
            {
                return BadRequest("No se pudo crear la factura");
            }
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Factura factura)
        {

            // Verificar si el objeto usuario es nulo
            if (factura == null)
            {
                return BadRequest("Los datos de la Factura son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioFactura.Actualizar(factura);

            if (response != null)
            {
                return Ok("Factura actualizada con exito");
            }
            else
            {
                return BadRequest("No se pudo actualizar la factura");
            }
        }

        [HttpDelete("Eliminar{idFactura}")]
        public async Task<IActionResult> Eliminar(int idFactura)
        {
            var habitacion = await _negocioFactura.Eliminar(idFactura);
            if (!habitacion)
            {
                return NotFound("Factura no encontrada");
            }
            return Ok("Factura eliminada");
        }
    }
}
