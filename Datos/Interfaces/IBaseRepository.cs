using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> Lista();
        Task<bool> Nuevo(T entidad);
        Task<bool> Actualizar(T entidad);
        Task<bool> Eliminar(int identidad);
        Task<T> ObtenerPorId(int id);
    }
}
