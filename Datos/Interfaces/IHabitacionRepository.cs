using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IHabitacionRepository:IBaseRepository<Habitacion>
    {
        Task<List<Habitacion>> ListaDisponibles(DateTime fechaEntrada,DateTime fechaSalida);
    }
}
