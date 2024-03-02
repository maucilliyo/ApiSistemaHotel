using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private readonly UsuariosRepository _usuariosRepository;
        private readonly INegocioUsuario _negocioUsuarios;
        public UsuarioController(INegocioUsuario negocioUsuarios)
        {
            _negocioUsuarios = negocioUsuarios;
        }
        [HttpPost("Autentificar")]

        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var reponse = await _negocioUsuarios.IsAuthenticated(request.Usuario, request.Password);

            if (reponse == null)
                return NotFound("El usuario no existe");
            // Por simplicidad, aquí simplemente devolvemos un mensaje de éxito

            return Ok(reponse);
        }
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _negocioUsuarios.Lista();
        }

        [HttpPost("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Usuario usuario)
        {

            // Verificar si el objeto usuario es nulo
            if (usuario == null)
            {
                return BadRequest("Los datos del usuario son nulos");
            }
            // Si todos los campos requeridos están presentes, intenta crear el usuario
            var response = await _negocioUsuarios.Nuevo(usuario);

            if (response != null)
            {
                return Ok("Usuario creado exitosamente");
            }
            else
            {
                return BadRequest("No se pudo crear el usuario");
            }
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Usuario usuario)
        {
            // Verificar si el objeto usuario es nulo
            if (usuario == null)
            {
                return BadRequest("Los datos del usuario son nulos");
            }

            var response = await _negocioUsuarios.Actualizar(usuario);

            if (response != null)
            {
                return Ok("Usuario actualizado exitosamente");
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }

        [HttpDelete("Eliminar{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _negocioUsuarios.Eliminar(id);

            if (!usuario)
            {
                return NotFound(); // Usuario no encontrado
            }
            return Ok("Usuario Eliminado"); // Eliminación exitosa
        }
    }
}
