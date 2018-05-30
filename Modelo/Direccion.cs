using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Direccion
    {
        private int idDireccion = 0;
        private int idIdentidad = 0; //ALMACENAMOS MEJOR LA IDENTIDAD DIRECTAMENTE?
        private String pais = "";
        private String ciudad = "";
        private String calle = "";
        private int numeroCalle = 0;
        private int piso = 0;
        private String departamento = "";

        public Direccion(int idDireccion, int idIdentidad, String pais, String ciudad,
            String calle, int numeroCalle, int piso, String departamento)
        {
            this.idDireccion = idDireccion;
            this.idIdentidad = idIdentidad;
            this.pais = pais;
            this.ciudad = ciudad;
            this.calle = calle;
            this.numeroCalle = numeroCalle;
            this.piso = piso;
            this.departamento = departamento;
        }

        public int getIdDireccion()
        {
            return this.idDireccion;
        }

        public int getIdIdentidad()
        {
            return this.idIdentidad;
        }

        public String getPais()
        {
            return this.pais;
        }

        public String getCiudad()
        {
            return this.ciudad;
        }

        public String getCalle()
        {
            return this.calle;
        }

        public int getNumeroCalle()
        {
            return this.numeroCalle;
        }

        public int getPiso()
        {
            return this.piso;
        }

        public String getDepartamento()
        {
            return this.departamento;
        }

        public Boolean esNuevo()
        {
            return idDireccion.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        private int IdDireccion { get { return this.getIdDireccion(); } }
        private int IdIdentidad { get { return this.getIdIdentidad(); } }
        private String Pais { get { return this.getPais(); } }
        private String Ciudad { get { return this.getCiudad(); } }
        private String Calle { get { return this.getCalle(); } }
        private int NumeroCalle { get { return this.getNumeroCalle(); } }
        private int Piso { get { return this.getPiso(); } }
        private String Departamento { get { return this.getDepartamento(); } }
    }
}
