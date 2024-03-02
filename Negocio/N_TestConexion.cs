using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class N_TestConexion
    {
        private readonly TestConexion _TestConexion;

        public N_TestConexion(TestConexion testConexion)
        {
            _TestConexion = testConexion;
        }
        public bool TestConexion()
        {
            return _TestConexion.Test();
        }

    }
}
