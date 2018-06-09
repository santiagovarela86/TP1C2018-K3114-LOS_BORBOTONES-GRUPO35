using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrbaHotel.ModelBuilder
{
    public class HabitacionBuilder
    {
        public static Habitacion buildHabitacion(TipoHabitacion tipoHabitacion, int idHotel)
        {
            return new Habitacion(0, tipoHabitacion, true, 1, 1, "TEST: ZONA 1",idHotel);
        }
    }
}
