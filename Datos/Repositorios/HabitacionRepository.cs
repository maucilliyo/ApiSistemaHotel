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
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly ConexionSql _conexionSql;
        public HabitacionRepository(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }
        public async Task<bool> Actualizar(Habitacion habitacion)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_HabitacionModificar",
                                            new
                                            {
                                                habitacion.IdHabitacion,
                                                habitacion.NumeroHabitacion,
                                                habitacion.Disponible,
                                                habitacion.NumeroPiso,
                                                habitacion.IdTipoHabitacion
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public async Task<bool> Eliminar(int identidad)
        {
            using (var conn = _conexionSql.GetConnection())
            {

                return await conn.ExecuteAsync("SP_HabitacionEliminar", commandType:CommandType.StoredProcedure) > 0;
            }
        }

        public async Task<List<Habitacion>> Lista()
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var usuarios = await conn.QueryAsync<Habitacion>("SP_HabitacionLista",
                                                              commandType: CommandType.StoredProcedure);

                return usuarios.ToList();
            }
        }

        public async Task<bool> Nuevo(Habitacion habitacion)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_HabitacionNueva",
                                            new
                                            {
                                                habitacion.NumeroHabitacion,
                                                habitacion.Disponible,
                                                habitacion.NumeroPiso,
                                                habitacion.IdTipoHabitacion
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public async Task<Habitacion> ObtenerPorId(int IdHabitacion)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<Habitacion>("HabitacionGetByID", new { IdHabitacion },
                                                     commandType: CommandType.StoredProcedure);

                return response.FirstOrDefault();
            }
        }
    }
}
