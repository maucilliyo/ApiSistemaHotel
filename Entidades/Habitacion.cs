using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public int NumeroHabitacion { get; set; }
        public bool Disponible { get; set; }
        public int NumeroPiso { get; set; }
        public int IdTipoHabitacion { get; set; }
    }
}
