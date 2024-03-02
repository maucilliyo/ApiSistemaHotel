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
    public class UsuariosRepository: IUsuariosRepository
    {
        private readonly BitacoraAccionesRepository _bitacoraAccionesRepository;
        private readonly ConexionSql _conexionSql;
        public UsuariosRepository(BitacoraAccionesRepository bitacoraAccionesRepository, ConexionSql conexionSql)
        {
            _bitacoraAccionesRepository = bitacoraAccionesRepository;
            _conexionSql = conexionSql;
        }
        public async Task<Usuario> IsAuthenticated(string NombreUsuario, string password)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var response = await conn.QueryAsync<Usuario>("SP_usuarioValido", new { NombreUsuario, password },
                                                            commandType: CommandType.StoredProcedure);

                //bitacora
                if (response.Count() == 0)
                {
                    BitacoraAcciones bitacoraAcciones = new()
                    {
                        Accion = "error de inicio de sesion: itento fallido",
                        Usuario = "no identificado",
                        Fecha = DateTime.Now,
                        Tabla = "Usuarios"
                    };

                    _bitacoraAccionesRepository.AgregarRegistro(bitacoraAcciones);
                }
                else
                {
                    BitacoraAcciones bitacoraAcciones = new()
                    {
                        Accion = "Inicio de sesion",
                        Usuario = response.FirstOrDefault().IdUsuario.ToString(),
                        Fecha = DateTime.Now,
                        Tabla = "Usuarios"
                    };

                    _bitacoraAccionesRepository.AgregarRegistro(bitacoraAcciones);
                }


                //retorna el usuario si es valido
                return response.FirstOrDefault();
            }
        }
        public async Task<bool> Nuevo(Usuario usuario)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_UsuarioNuevo",
                                            new
                                            {
                                                usuario.NombreUsuario,
                                                usuario.Nombre,
                                                usuario.Apellido,
                                                usuario.Celular,
                                                usuario.Activo,
                                                usuario.IdRol,
                                                usuario.Password
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones
        }
        public async Task<bool> Actualizar(Usuario usuario)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_UsuarioModificar",
                                            new
                                            {
                                                usuario.IdUsuario,
                                                usuario.NombreUsuario,
                                                usuario.Nombre,
                                                usuario.Apellido,
                                                usuario.Celular,
                                                usuario.Activo,
                                                usuario.IdRol,
                                                usuario.Password
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
            //implementar acciones

        }
        public async Task<bool> Eliminar(int idUsuario)
        {
            using (var conn = _conexionSql.GetConnection())
            {
                return await conn.ExecuteAsync("SP_UsuariosEliminar",
                                            new
                                            {
                                                idUsuario
                                            },
                                            commandType: CommandType.StoredProcedure) > 0;
            }
        }
        public async Task<List<Usuario>> Lista()
        {
            using (var conn = _conexionSql.GetConnection())
            {
                var usuarios = await conn.QueryAsync<Usuario>("SP_UsuarioLista",  commandType: CommandType.StoredProcedure);

                return usuarios.ToList();

            }
        }
        public Task<Usuario> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
