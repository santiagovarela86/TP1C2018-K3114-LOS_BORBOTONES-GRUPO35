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
        public String Nombre { get { return this.getIdentidad().getNombre(); } }
        public String Apellido { get { return this.getIdentidad().getApellido(); } }
        public String TipoDoc { get { return this.getIdentidad().getTipoDocumento(); } }
        public String NroDoc { get { return this.getIdentidad().getNumeroDocumento(); } }
        public String Mail { get { return this.getIdentidad().getMail(); } }
        public String Telefono { get { return this.getIdentidad().getTelefono(); } }
        //ACA ASUMO QUE TENGO UNA SOLA DIRECCION EN EL USUARIO
        public String Direccion { get { return this.getIdentidad().getDirecciones().First().getDireccionCompleta(); } }
        public String Nacionalidad { get { return this.getIdentidad().getNacionalidad(); } }
        public String FechaNac { get { return this.getIdentidad().getFechaNacimiento().ToString(); } }
        public Boolean Activo { get { return this.getActivo(); } }

    }
}
