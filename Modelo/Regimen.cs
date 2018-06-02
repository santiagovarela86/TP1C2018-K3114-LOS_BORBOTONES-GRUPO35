using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Regimen
    {
        private int idRegimen = 0;
        private Hotel hotel = null;
        private int codigoRegimen = 0; //QUE DIFERENCIA HAY CON EL ID REGIMEN?
        private String descripcion = "";
        private float precio = 0;
        private String estado = "";

        public Regimen(int idRegimen, Hotel hotel, int codigoRegimen, String descripcion, float precio, String estado)
        {
            this.idRegimen = idRegimen;
            this.hotel = hotel;
            this.codigoRegimen = codigoRegimen;
            this.descripcion = descripcion;
            this.precio = precio;
            this.estado = estado;
        }

        public int getIdRegimen()
        {
            return this.idRegimen;
        }

        public Hotel getHotel()
        {
            return this.hotel;
        }

        public int getCodigoRegimen()
        {
            return this.codigoRegimen;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        public float getPrecio()
        {
            return this.precio;
        }

        public String getEstado()
        {
            return this.estado;
        }

        public Boolean esNuevo()
        {
            return idRegimen.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdRegimen { get { return this.getIdRegimen(); } }
        public Hotel Hotel { get { return this.getHotel(); } }
        public int CodigoRegimen { get { return this.getCodigoRegimen(); } }
        public String Descripcion { get { return this.getDescripcion(); } }
        public float Precio { get { return this.getPrecio(); } }
        public String Estado { get { return this.getEstado(); } }
    }
}
