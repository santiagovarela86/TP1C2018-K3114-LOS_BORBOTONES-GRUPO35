using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Estadia
    {
        private int idEstadia = 0;
        private DateTime fechaEntrada = new DateTime();
        private DateTime fechaSalida = new DateTime();
        private Boolean facturada = false;
        private Usuario usuarioCheckIn = null;
        private Usuario usuarioCheckOut = null;

        public Estadia(int idEstadia, DateTime fechaEntrada, DateTime fechaSalida, Boolean facturada,
            Usuario usuarioCheckIn, Usuario usuarioCheckOut)
        {
            this.idEstadia = idEstadia;
            this.fechaEntrada = fechaEntrada;
            this.fechaSalida = fechaSalida;
            this.facturada = facturada;
            this.usuarioCheckIn = usuarioCheckIn;
            this.usuarioCheckOut = usuarioCheckOut;
        }

        public int getIdEstadia()
        {
            return this.idEstadia;
        }

        public DateTime getFechaEntrada()
        {
            return this.fechaEntrada;
        }

        public DateTime getFechaSalida()
        {
            return this.fechaSalida;
        }

        public Boolean getFacturada()
        {
            return this.facturada;
        }

        public Usuario getUsuarioCheckIn()
        {
            return this.usuarioCheckIn;
        }

        public Usuario getUsuarioCheckOut()
        {
            return this.usuarioCheckOut;
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdEstadia { get { return this.getIdEstadia(); } }
        public DateTime FechaEntrada { get { return this.getFechaEntrada(); } }
        public DateTime FechaSalida { get { return this.getFechaSalida(); } }
        public Boolean Facturada { get { return this.getFacturada(); } }
        public Usuario UsuarioCheckIn { get { return this.getUsuarioCheckIn(); } }
        public Usuario UsuarioCheckOut { get { return this.getUsuarioCheckOut(); } }
        
    }
}
