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
        public int IdReserva { get { return this.getIdReserva(); } }
        public Hotel Hotel { get { return this.getHotel(); } }
        public Estadia Estadia { get { return this.getEstadia(); } }
        public Regimen Regimen { get { return this.getRegimen(); } }
        public Cliente Cliente { get { return this.getCliente(); } }
        public decimal CodigoReserva { get { return this.getCodigoReserva(); } }
        public decimal DiasAlojados { get { return this.getDiasAlojados(); } }
        public DateTime FechaCreacion { get { return this.getFechaCreacion(); } }
        public DateTime FechaDesde { get { return this.getFechaDesde(); } }
        public DateTime FechaHasta { get { return this.getFechaHasta(); } }
        public List<EstadoReserva> Estados { get { return this.getEstados(); } }

    }
}
