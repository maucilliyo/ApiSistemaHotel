using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioRole : INegocioRole
    {
        private readonly IRoleRepository _roleRepository;
        public NegocioRole(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;   
        }
        public Task<bool> Actualizar(Role entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int identidad)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> Lista()
        {
            return await _roleRepository.Lista();
        }

        public Task<bool> Nuevo(Role entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Role> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
