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
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ConexionSql _conexionSql;
        public FacturaRepository(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }

        public async Task<bool> Actualizar(Factura entidad)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_FacturaModificar",
                                            new
                                            {
                                                entidad.IdFactura,
                                                entidad.IdReserva,
                                                entidad.CodigoReserva,
                                                entidad.CantidadPersonas,
                                                entidad.PrecioTotal,
                                                entidad.FechaFactura,
                                                entidad.Detalle
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public Task<bool> Eliminar(int identidad)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Factura>> Lista()
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<Factura>("SP_FacturasGetByID",
                                                     commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<bool> Nuevo(Factura entidad)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_FacturaNueva",
                                            new
                                            { 
                                                entidad.IdReserva,
                                                entidad.CodigoReserva,
                                                entidad.CantidadPersonas,
                                                entidad.PrecioTotal,
                                                entidad.FechaFactura,
                                                entidad.Detalle
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }

        public async Task<Factura> ObtenerPorId(int idFactura)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<Factura>("SP_FacturasGetByID", new { idFactura },
                                                     commandType: CommandType.StoredProcedure);

                return response.FirstOrDefault();
            }
        }
    }
}
