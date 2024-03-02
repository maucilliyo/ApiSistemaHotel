using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Datos
{
    public class ConexionSql
    {
        private readonly IConfiguration _iConfiguracion;
        public ConexionSql(IConfiguration iConfiguracion)
        {
            _iConfiguracion = iConfiguracion;
        }
        public SqlConnection GetConnection()
        {
            // Cadena de conexión
            string connectionString = _iConfiguracion.GetConnectionString("ConexionSQL");

            SqlConnection connection = new SqlConnection
            {
                ConnectionString = connectionString
            };

            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                else
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ERROR DE CONEXION CON EL SERVIDOR " + ex);
            }
            return connection;
        }
    }
}
