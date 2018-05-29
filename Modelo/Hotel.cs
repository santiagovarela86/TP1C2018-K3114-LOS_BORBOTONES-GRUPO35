using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Hotel
    {
        private int idHotel = 0;
        private int idCategoria = 0;
        private int idDireccion = 0;
        private String nombre = "";
        private String mail = "";
        private String telefono = "";
        private List<Reserva> reservas = new List<Reserva>();
        private List<Regimen> regimenes = new List<Regimen>();
        private List<Habitacion> habitaciones = new List<Habitacion>();
        private List<CierreTemporal> cierresTemporales = new List<CierreTemporal>();

        public Hotel(int idHotel, int idCategoria, int idDireccion, String nombre, String mail, String telefono,
            List<Reserva> reservas, List<Regimen> regimenes, List<Habitacion> habitaciones, List<CierreTemporal> cierresTemporales)
        {
            this.idHotel = idHotel;
            this.idCategoria = idCategoria;
            this.idDireccion = idDireccion;
            this.nombre = nombre;
            this.mail = mail;
            this.telefono = telefono;
            this.reservas = reservas;
            this.regimenes = regimenes;
            this.habitaciones = habitaciones;
            this.cierresTemporales = cierresTemporales;
        }

        public int getIdHotel(){
            return this.idHotel;
        }

        public int getIdCategoria(){
            return this.idCategoria;
        }

        public int getIdDireccion(){
            return this.idDireccion;
        }

        public String getNombre(){
            return this.nombre;
        }

        public String getMail(){
            return this.mail;
        }

        public String getTelefono(){
            return this.telefono;
        }

        public List<Reserva> getReservas(){
            return this.reservas;
        }

        public List<Regimen> getRegimenes(){
            return this.regimenes;
        }

        public List<Habitacion> getHabitaciones()
        {
            return this.habitaciones;
        }

        public List<CierreTemporal> getCierresTemporales(){
            return this.cierresTemporales;
        }

        public Boolean esNuevo()
        {
            return idHotel.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        private int IdHotel { get { return this.getIdHotel(); } }
        private int IdCategoria { get { return this.getIdCategoria(); } }
        private int IdDireccion { get { return this.getIdDireccion(); } }
        private String Nombre { get { return this.getNombre(); } }
        private String Mail { get { return this.getMail(); } }
        private String Telefono { get { return this.getTelefono(); } }
        private List<Reserva> Reservas { get { return this.getReservas(); } }
        private List<Regimen> Regimenes { get { return this.getRegimenes(); } }
        private List<Habitacion> Habitaciones { get { return this.getHabitaciones(); } }
        private List<CierreTemporal> CierresTemporales { get { return this.getCierresTemporales(); } }
    }
}
