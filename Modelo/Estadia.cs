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
        private Usuario usuarioCheckIn = null;
        private Usuario usuarioCheckOut = null;
        private DateTime fechaEntrada = new DateTime();
        private DateTime fechaSalida = new DateTime();
        private Boolean facturada = false;

        public Estadia(int idEstadia, Usuario usuarioCheckIn, Usuario usuarioCheckOut,
            DateTime fechaEntrada, DateTime fechaSalida, Boolean facturada)
        {
            this.idEstadia = idEstadia;
            this.usuarioCheckIn = usuarioCheckIn;
            this.usuarioCheckOut = usuarioCheckOut;
            this.fechaEntrada = fechaEntrada;
            this.fechaSalida = fechaSalida;
            this.facturada = facturada;
        }

        public int getIdEstadia()
        {
            return this.idEstadia;
        }

        public Usuario getUsuarioCheckIn()
        {
            return this.usuarioCheckIn;
        }

        public Usuario getUsuarioCheckOut()
        {
            return this.usuarioCheckOut;
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

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdEstadia { get { return this.getIdEstadia(); } }
        public Usuario UsuarioCheckIn { get { return this.getUsuarioCheckIn(); } }
        public Usuario UsuarioCheckOut { get { return this.getUsuarioCheckOut(); } }
        public DateTime FechaEntrada { get { return this.getFechaEntrada(); } }
        public DateTime FechaSalida { get { return this.getFechaSalida(); } }
        public Boolean Facturada { get { return this.getFacturada(); } }        
    }
}
