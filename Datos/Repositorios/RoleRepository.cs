using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ConexionSql _conexionSql;

        public RoleRepository(ConexionSql conexionSql )
        {
            _conexionSql = conexionSql; 
        }
        public Task<bool> Actualizar(Role entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int identidad)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> Lista()
        {
            throw new NotImplementedException();
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
