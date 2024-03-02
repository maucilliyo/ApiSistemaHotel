using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSqlController : ControllerBase
    {
        private readonly N_TestConexion _nTestConexion;

        public TestSqlController(N_TestConexion nTestConexion)
        {
            _nTestConexion = nTestConexion;
        }

        [HttpGet]
        public IActionResult Test()
        {
            bool resultado = _nTestConexion.TestConexion();
            if (resultado)
            {
                return Ok("La conexión fue exitosa.");
            }
            else
            {
                return StatusCode(500, "Error al probar la conexión.");
            }
        }
    }
}
