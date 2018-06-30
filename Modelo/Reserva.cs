using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Reserva
    {
        private int idReserva = 0;
        private Hotel hotel = null;
        private Estadia estadia = null;
        private Regimen regimen = null;
        private Cliente cliente = null;
        private decimal codigoReserva = 0;
        private decimal diasAlojados = 0;
        private DateTime fechaCreacion = new DateTime();
        private DateTime fechaDesde = new DateTime();
        private DateTime fechaHasta = new DateTime();
        private List<EstadoReserva> estados = new List<EstadoReserva>();

        public Reserva(int idReserva, Hotel hotel, Estadia estadia, Regimen regimen, Cliente cliente, decimal codigoReserva,
            decimal diasAlojados, DateTime fechaCreacion, DateTime fechaDesde, DateTime fechaHasta, List<EstadoReserva> estados)
        {
            this.idReserva = idReserva;
            this.hotel = hotel;
            this.estadia = estadia;
            this.regimen = regimen;
            this.cliente = cliente;
            this.codigoReserva = codigoReserva;
            this.diasAlojados = diasAlojados;
            this.fechaCreacion = fechaCreacion;
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.estados = estados;
        }

        public int getIdReserva()
        {
            return this.idReserva;
        }

        public Hotel getHotel()
        {
            return this.hotel;
        }

        public Estadia getEstadia()
        {
            return this.estadia;
        }

        public Regimen getRegimen()
        {
            return this.regimen;
        }

        public Cliente getCliente()
        {
            return this.cliente;
        }

        public decimal getCodigoReserva()
        {
            return this.codigoReserva;
        }

        public decimal getDiasAlojados()
        {
            return this.diasAlojados;
        }

        public DateTime getFechaCreacion()
        {
            return this.fechaCreacion;
        }

        public DateTime getFechaDesde()
        {
            return this.fechaDesde;
        }

        public DateTime getFechaHasta()
        {
            return this.fechaHasta;
        }

        public List<EstadoReserva> getEstados()
        {
            return this.estados;
        }

        public Boolean esNuevo()
        {
            return idReserva.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public decimal CodigoReserva { get { return this.getCodigoReserva(); } }
        public String FechaCreacion { get { return this.getFechaCreacion().ToString(); } }
        public String FechaDesde { get { return this.getFechaDesde().ToString(); } }
        public String FechaHasta { get { return this.getFechaHasta().ToString(); } }
        //public String Cliente { get { return this.getCliente().getIdentidad().getNombreCompleto(); } }       

    }
}
