using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class BitacoraAccionesRepository
    {
        private readonly ConexionMogo _conexionMogo;
        public BitacoraAccionesRepository(ConexionMogo conexionMogo)
        {
            _conexionMogo = conexionMogo;
        }
        public bool AgregarRegistro(BitacoraAcciones  bitacoraAcciones)
        {
            bool resultado = false;
            try
            {
                _conexionMogo.EstablecerConexion();
                var coleccion = _conexionMogo.basedatos.GetCollection<BitacoraAcciones>("Accion");
                coleccion.InsertOne(bitacoraAcciones);
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
            return resultado;
        }
    }
}
