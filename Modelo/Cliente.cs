using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Cliente
    {
        private int idCliente = 0;
        private Boolean activo = false;
        private Identidad identidad = null;
        private List<Reserva> reservas = new List<Reserva>();

        public Cliente(int idCliente, Boolean activo, Identidad identidad, List<Reserva> reservas)
        {
            this.idCliente = idCliente;
            this.activo = activo;
            this.identidad = identidad;
            this.reservas = reservas;
        }

        public int getIdCliente()
        {
            return idCliente;
        }

        public Boolean getActivo()
        {
            return activo;
        }

        public Identidad getIdentidad()
        {
            return identidad;
        }

        public List<Reserva> getReservas()
        {
            return reservas;
        }

        public Boolean esNuevo()
        {
            return idCliente.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdCliente { get { return this.getIdCliente(); } }
        public Boolean Activo { get { return this.getActivo(); } }
        public Identidad Identidad { get { return this.getIdentidad(); } }
        public List<Reserva> Reservas { get { return this.getReservas(); } }
    }
}
