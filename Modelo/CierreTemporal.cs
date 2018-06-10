using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class CierreTemporal
    {
        private int idCierreTemporal = 0;
        private DateTime fechaInicio = new DateTime();
        private DateTime fechaFin = new DateTime();
        private String descripcion = "";
        private int idHotel = 0;

        public CierreTemporal(int idCierreTemporal, DateTime fechaInicio, DateTime fechaFin, String descripcion, int idHotel)
        {
            this.idCierreTemporal = idCierreTemporal;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.descripcion = descripcion;
            this.idHotel = idHotel;
        }

        public int getIdCierreTemporal()
        {
            return idCierreTemporal;
        }

        public DateTime getFechaInicio()
        {
            return fechaInicio;
        }

        public DateTime getFechaFin()
        {
            return fechaFin;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public int getIdHotel()
        {
            return this.idHotel;
        }

        public void setIdHotel(int idHotel)
        {
            this.idHotel = idHotel;
        }

        public Boolean esNuevo()
        {
            return idCierreTemporal.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdCierreTemporal { get { return this.getIdCierreTemporal(); } }
        public DateTime FechaInicio { get { return this.getFechaInicio(); } }
        public DateTime FechaFin { get { return this.getFechaFin(); } }
        public String Descripcion { get { return this.getDescripcion(); } }
        public int IdHotel { get { return this.getIdHotel(); } }
    }
}
