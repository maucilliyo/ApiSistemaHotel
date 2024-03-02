using Dapper;
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
    public class TipoHabitacionRepository : ITipoHabitacionRepository
    {
        private readonly ConexionSql _conexionSql;
        public TipoHabitacionRepository(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }

        public async Task<bool> Actualizar(TipoHabitacion entidad)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_TipoHabitacionModificar",
                                            new
                                            {
                                                entidad.IDTipoHabitacion,
                                                entidad.Tipo
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public async Task<bool> Eliminar(int idTipoHabitacion)
        {
            using (var conn = _conexionSql.GetConnection())
            {

                return await conn.ExecuteAsync("SP_TipoHabitacionEliminar",
                                                new { idTipoHabitacion },
                                                commandType:CommandType.StoredProcedure) > 0; 
            
            }
        }

        public async Task<List<TipoHabitacion>> Lista()
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<TipoHabitacion>("SP_TipoHabitacionLista", 
                                                                      commandType:CommandType.StoredProcedure);
                
                return response.ToList();
            }
        }

        public async Task<bool> Nuevo(TipoHabitacion entidad)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_TipoHabitacionNueva",
                                            new
                                            { 
                                                entidad.Tipo
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public async Task<TipoHabitacion> ObtenerPorId(int idTipoHabitacion)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<TipoHabitacion>("SP_TipoHabitacionGetByID",
                                                                      new { idTipoHabitacion },
                                                                      commandType: CommandType.StoredProcedure);

                return response.FirstOrDefault();
            }
        }
    }
}
