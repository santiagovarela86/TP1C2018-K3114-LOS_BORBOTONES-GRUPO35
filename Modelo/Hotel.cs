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
        private Categoria categoria = null;
        private Direccion direccion = null;
        private String nombre = "";
        private String mail = "";
        private String telefono = "";
        private DateTime fechaInicioActividades = new DateTime();
        private List<Reserva> reservas = new List<Reserva>();
        private List<Regimen> regimenes = new List<Regimen>();
        private List<Habitacion> habitaciones = new List<Habitacion>();
        private List<CierreTemporal> cierresTemporales = new List<CierreTemporal>();

        public Hotel(int idHotel, Categoria categoria, Direccion direccion, String nombre, String mail, String telefono, DateTime fechaInicioActividades,
            List<Reserva> reservas, List<Regimen> regimenes, List<Habitacion> habitaciones, List<CierreTemporal> cierresTemporales)
        {
            this.idHotel = idHotel;
            this.categoria = categoria;
            this.direccion = direccion;
            this.nombre = nombre;
            this.mail = mail;
            this.telefono = telefono;
            this.fechaInicioActividades = fechaInicioActividades;
            this.reservas = reservas;
            this.regimenes = regimenes;
            this.habitaciones = habitaciones;
            this.cierresTemporales = cierresTemporales;
        }

        public int getIdHotel()
        {
            return this.idHotel;
        }

        public void setIdHotel(int idHotel)
        {
            this.idHotel = idHotel;
        }

        public Categoria getCategoria()
        {
            return this.categoria;
        }

        public Direccion getDireccion()
        {
            return this.direccion;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public String getMail()
        {
            return this.mail;
        }

        public String getTelefono()
        {
            return this.telefono;
        }

        public DateTime getFechaInicioActividades()
        {
            return this.fechaInicioActividades;
        }

        public List<Reserva> getReservas()
        {
            return this.reservas;
        }

        public List<Regimen> getRegimenes()
        {
            return this.regimenes;
        }

        public List<Habitacion> getHabitaciones()
        {
            return this.habitaciones;
        }

        public List<CierreTemporal> getCierresTemporales()
        {
            return this.cierresTemporales;
        }

        public Boolean esNuevo()
        {
            return idHotel.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdHotel { get { return this.getIdHotel(); } }
        public String Nombre { get { return this.getNombre(); } }
        public String Mail { get { return this.getMail(); } }
        public String Telefono { get { return this.getTelefono(); } }
        public String Direccion { get { return this.getDireccion().getDireccionCorta(); } }
        public String Ciudad { get { return this.getDireccion().getCiudad(); } }
        public String Pais { get { return this.getDireccion().getPais(); } }
        public int Estrellas { get { return this.getCategoria().Estrellas; } }
        //ACA HAY QUE HACER UN METODO QUE CONCATENE LA LISTA DE REGIMENES Y LOS MUESTRE SEPARADOS POR COMA... EJ: ("Media pensión, All inclusive, ...)
        //public String Regimenes { get { return this.getRegimenesString(); } }
        public DateTime FechaInicioActividades { get { return this.getFechaInicioActividades(); } }

    }
}