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
    public class NegocioReserva : INegocioReserva
    {
        private readonly IReservaRepository _reservaRepository;
        public NegocioReserva(IReservaRepository reservaRepository )
        {
             _reservaRepository = reservaRepository;
        }
        public async Task<bool> Actualizar(Reserva reserva)
        {
            return await _reservaRepository.Actualizar(reserva);
        }

        public Task<bool> Eliminar(int identidad)
        {
            throw new NotImplementedException();
        }

        public async Task<Reserva> GetReservaByCodigo(string CodigoReserva)
        {
            return await _reservaRepository.GetReservaByCodigo(CodigoReserva);
        }

        public async Task<List<Reserva>> Lista()
        {
             return await _reservaRepository.Lista(); 
        }

        public async Task<bool> Nuevo(Reserva reserva)
        {
            return await _reservaRepository.Nuevo (reserva);
        }

        public async Task<Reserva> ObtenerPorId(int id)
        {
            return await _reservaRepository.ObtenerPorId (id);    
        }
    }
}
