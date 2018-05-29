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
        private int idHotel = 0; //ALMACENAMOS MEJOR EL HOTEL DIRECTAMENTE?
        private int codigoRegimen = 0; //QUE DIFERENCIA HAY CON EL ID REGIMEN?
        private String descripcion = "";
        private float precio = 0;
        private String estado = "";

        public Regimen(int idRegimen, int idHotel, int codigoRegimen, String descripcion, float precio, String estado)
        {
            this.idRegimen = idRegimen;
            this.idHotel = idHotel;
            this.codigoRegimen = codigoRegimen;
            this.descripcion = descripcion;
            this.precio = precio;
            this.estado = estado;
        }

        public int getIdRegimen() {
            return this.idRegimen;
        }

        public int getIdHotel()
        {
            return this.idHotel;
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
        private int IdRegimen { get { return this.getIdRegimen(); } }
        private int IdHotel { get { return this.getIdHotel(); } }
        private int CodigoRegimen { get { return this.getCodigoRegimen(); } }
        private String Descripcion { get { return this.getDescripcion(); } }
        private float Precio { get { return this.getPrecio(); } }
        private String Estado { get { return this.getEstado(); } }
    }
}
