using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private INegocioRole _negocioRole;
        public RoleController(INegocioRole negocioRole)
        {
            _negocioRole = negocioRole;
        }
        [HttpGet("Lista")]

        public async Task<IActionResult> Lista()
        {

            var response = await _negocioRole.Lista();

            if (response.Count() == 0)
            {
                return BadRequest("Nop hay datos para mostrar");
            }

            return Ok(response);
        }

    }
}
