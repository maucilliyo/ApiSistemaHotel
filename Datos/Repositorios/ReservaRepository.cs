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
    public class ReservaRepository : IReservaRepository
    {
        private readonly ConexionSql _conexionSql;
        public ReservaRepository(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }
        public async Task<bool> Actualizar(Reserva reserva)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_ReservaModificar",
                                            new
                                            {
                                                reserva.IdReserva,
                                                reserva.CodigoReserva,
                                                reserva.EstadoReservacion,
                                                reserva.IdHabitacion,
                                                reserva.FechaEntrada,
                                                reserva.FechaSalida,
                                                reserva.NombreCliente
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public Task<bool> Eliminar(int idReserva)
        {
            throw new NotImplementedException();
        }

        public async Task<Reserva> GetReservaByCodigo(string CodigoReserva)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<Reserva>("Sp_ReservaGetByCodigo", 
                                                                new { CodigoReserva },
                                                                commandType: CommandType.StoredProcedure);

                return response.FirstOrDefault();
            }
        }

        public async Task<List<Reserva>> Lista()
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var usuarios = await conn.QueryAsync<Reserva>("SP_ReservaLista", 
                                                              commandType: CommandType.StoredProcedure);

                return usuarios.ToList();
            }
        }

        public async Task<bool> Nuevo(Reserva reserva)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_ReservaNueva",
                                            new
                                            {
                                                reserva.CodigoReserva,
                                                reserva.EstadoReservacion,
                                                reserva.IdHabitacion,
                                                reserva.FechaEntrada,
                                                reserva.FechaSalida,
                                                reserva.NombreCliente
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public async Task<Reserva> ObtenerPorId(int idReserva)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response =  await conn.QueryAsync<Reserva>("Sp_ReservaGetById", new { idReserva}, 
                                                     commandType:CommandType.StoredProcedure);

                return response.FirstOrDefault();
            }
        }
    }
}
