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
    public class NegocioTipoHabitacion : INegocioTipoHabitacion
    {
        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;

        public NegocioTipoHabitacion(ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _tipoHabitacionRepository = tipoHabitacionRepository;
        }

        public async Task<bool> Actualizar(TipoHabitacion entidad)
        {
            return await _tipoHabitacionRepository.Actualizar(entidad);   
        }

        public async Task<bool> Eliminar(int identidad)
        {
            return await _tipoHabitacionRepository.Eliminar(identidad);
        }

        public async Task<List<TipoHabitacion>> Lista()
        {
             return await _tipoHabitacionRepository.Lista();
        }

        public async Task<bool> Nuevo(TipoHabitacion entidad)
        {
            return await _tipoHabitacionRepository.Nuevo(entidad);
        }

        public async Task<TipoHabitacion> ObtenerPorId(int id)
        {
            return await _tipoHabitacionRepository.ObtenerPorId(id);
        }
    }
}
