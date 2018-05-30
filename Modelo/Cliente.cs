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
        private Identidad identidad = null;
        private Boolean activo = false;
        private List<Reserva> reservas = new List<Reserva>();

        public Cliente(int idCliente, Identidad identidad, Boolean activo, List<Reserva> reservas)
        {
            this.idCliente = idCliente;
            this.identidad = identidad;
            this.activo = activo;
            this.reservas = reservas;
        }

        public int getIdCliente()
        {
            return idCliente;
        }

        public Identidad getIdentidad()
        {
            return identidad;
        }

        public Boolean getActivo()
        {
            return activo;
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
        public Identidad Identidad { get { return this.getIdentidad(); } }
        public Boolean Activo { get { return this.getActivo(); } }
        public List<Reserva> Reservas { get { return this.getReservas(); } }
    }
}
