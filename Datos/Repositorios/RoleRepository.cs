﻿using Dapper;
using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RoleRepository:IRoleRepository
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

        public async Task<List<Role>> Lista()
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var respose = await conn.QueryAsync<Role>("SP_RoleLista", 
                                                           commandType:CommandType.StoredProcedure);
                return respose.ToList();
            }
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
