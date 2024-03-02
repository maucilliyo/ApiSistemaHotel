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
    public class NegocioFactura : INegocioFactura
    {
        private readonly IFacturaRepository _facturaRepository;

        public NegocioFactura(IFacturaRepository  facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<bool> Actualizar(Factura entidad)
        {
           return await _facturaRepository.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int identidad)
        {
            return await _facturaRepository.Eliminar(identidad);
        }

        public async Task<List<Factura>> Lista()
        {
            return await _facturaRepository.Lista();
        }

        public async Task<bool> Nuevo(Factura entidad)
        {
            return await _facturaRepository.Nuevo(entidad);    
        }

        public async Task<Factura> ObtenerPorId(int id)
        {
           return await _facturaRepository.ObtenerPorId(id);  
        }
    }
}
