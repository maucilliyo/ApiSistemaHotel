using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TestConexion
    {
        private readonly ConexionSql _conexionSql;
        public TestConexion(ConexionSql conexionSql )
        {
            _conexionSql = conexionSql;          
        }
        //TEST PARA PROBAR LA CONEXION SQL
        public bool Test()
        {
            try
            {
                var conn = _conexionSql.GetConnection();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
