using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionMogo
    {
        private readonly IConfiguration _iconfiguracion;
        //Aqui se conservará el string de conexión con MongoDB
        private string strConexionMongoDB = "";
        //Objetos para conexión
        private MongoClient instancia;

        //Espeficar el nombre de la colección por manipular
        private const string NombreBD = "BitacoraAcciones";
        public ConexionMogo(IConfiguration iconfiguracion)
        {
            try
            {
                _iconfiguracion = iconfiguracion;
                strConexionMongoDB = _iconfiguracion.GetConnectionString("ConexionMongoDB");
                EstablecerConexion();
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (instancia != null)
                    instancia = null;
                if (basedatos != null)
                    basedatos = null;
            }
        }
        
        public IMongoDatabase basedatos;
        public bool EstablecerConexion()
        {
            bool ConexionCorrecta = false;

            //Aqui se inicializa la instancia de BD
            instancia = new MongoClient(strConexionMongoDB);

            //Aqui se inicializara la colección
            basedatos = instancia.GetDatabase(NombreBD);

            //Verificar conexion 
            ConexionCorrecta = basedatos.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);

            return ConexionCorrecta;
        }
    }
}
