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
        private int idHotel = 0; //ALMACENAMOS MEJOR EL HOTEL DIRECTAMENTE?
        private int idEstadia = 0; //ALMACENAMOS MEJOR LA ESTADIA DIRECTAMENTE?
        private int idRegimen = 0; //ALMACENAMOS MEJOR EL REGIMEN DIRECTAMENTE?
        private int idCliente = 0; //ALMACENAMOS MEJOR EL CLIENTE DIRECTAMENTE?
        private int codigoReserva = 0;
        private int diasAlojados = 0;
        private DateTime fechaCreacion = new DateTime();
        private DateTime fechaDesde = new DateTime();
        private DateTime fechaHasta = new DateTime();        
        private List<EstadoReserva> estados = new List<EstadoReserva>();

        public Reserva(int idReserva, int idHotel, int idEstadia, int idRegimen, int idCliente, int codigoReserva,
            int diasAlojados, DateTime fechaCreacion, DateTime fechaDesde, DateTime fechaHasta, List<EstadoReserva> estados)
        {
            this.idReserva = idReserva;
            this.idHotel = idHotel;
            this.idEstadia = idEstadia;
            this.idRegimen = idRegimen;
            this.idCliente = idCliente;
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

        public int getIdHotel()
        {
            return this.idHotel;
        }

        public int getIdEstadia()
        {
            return this.idEstadia;
        }

        public int getIdRegimen()
        {
            return this.idRegimen;
        }

        public int getIdCliente()
        {
            return this.idCliente;
        }

        public int getCodigoReserva()
        {
            return this.codigoReserva;
        }

        public int getDiasAlojados()
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
        private int IdReserva { get { return this.getIdReserva(); } }
        private int IdHotel { get { return this.getIdHotel(); } }
        private int IdEstadia { get { return this.getIdEstadia(); } }
        private int IdRegimen { get { return this.getIdRegimen(); } }
        private int IdCliente { get { return this.getIdCliente(); } }
        private int CodigoReserva { get { return this.getCodigoReserva(); } }
        private int DiasAlojados { get { return this.getDiasAlojados(); } }
        private DateTime FechaCreacion { get { return this.getFechaCreacion(); } }
        private DateTime FechaDesde { get { return this.getFechaDesde(); } }
        private DateTime FechaHasta { get { return this.getFechaHasta(); } }
        private List<EstadoReserva> Estados { get { return this.getEstados(); } }

    }
}
