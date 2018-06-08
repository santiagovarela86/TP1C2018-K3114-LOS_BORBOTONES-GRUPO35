using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel.request
{
    public class BajaTemporal
    {
        private int idHotel;
        private DateTime fechaDesde;
        private DateTime fechaHasta;

        public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
        public DateTime FechaHasta { get => fechaHasta; set => fechaHasta = value; }
        public int IdHotel { get => idHotel; set => idHotel = value; }
    }
}
