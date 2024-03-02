using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;

namespace Negocio
{
    public class NegocioUsuario: INegocioUsuario
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public NegocioUsuario(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        public async Task<Usuario> IsAuthenticated(string NombreUsuario, string password)
        {
            return await _usuariosRepository.IsAuthenticated(NombreUsuario, password);
        }
        public async Task<bool> Nuevo(Usuario usuario)
        {
            return await _usuariosRepository.Nuevo(usuario);
        }
        public async Task<bool> Actualizar(Usuario usuario)
        {
            return await _usuariosRepository.Actualizar(usuario);
        }
        public async Task<bool> Eliminar(int idUsuario)
        {
            return await _usuariosRepository.Eliminar(idUsuario);
        }
        public async Task<List<Usuario>> Lista()
        {
            return await _usuariosRepository.Lista();
        }
        public Task<Usuario> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
