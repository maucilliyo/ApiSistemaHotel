using Datos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioHabitacion : INegocioHabitacion
    {
        private readonly IHabitacionRepository _habitacionRepositoy;
        public NegocioHabitacion(IHabitacionRepository habitacionRepositoy)
        {
            _habitacionRepositoy = habitacionRepositoy;
        }
        public async Task<bool> Actualizar(Habitacion entidad)
        {
          return await _habitacionRepositoy.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int identidad)
        {
            return await _habitacionRepositoy.Eliminar(identidad);
        }

        public async Task<List<Habitacion>> Lista()
        {
            return await _habitacionRepositoy.Lista();
        }

        public async Task<bool> Nuevo(Habitacion entidad)
        {
            return await _habitacionRepositoy.Nuevo(entidad);
        }

        public async Task<Habitacion> ObtenerPorId(int id)
        {
            return await _habitacionRepositoy.ObtenerPorId(id);    
        }
    }
}
