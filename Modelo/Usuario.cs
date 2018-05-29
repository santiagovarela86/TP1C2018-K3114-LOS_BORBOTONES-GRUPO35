using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    class Usuario
    {
        private int idUsuario = 0;
        private String username = "";
        private String password = "";
        private int intentosFallidosLogin = 0;
        private Boolean activo = true;
        private int idIdentidad = 0;
        private List<Rol> rol = new List<Rol>();
        private List<Hotel> hotel = new List<Hotel>();


        public int getIdUsuario()
        {
            return this.idUsuario;
        }

        public String getUsername()
        {
            return this.username;
        }
        public int getIntentosFallidosLogin()
        {
            return this.intentosFallidosLogin;
        }

        public String getPassword()
        {
            return this.password;
        }
        public int getIdIdentidad()
        {
            return this.idIdentidad;
        }
        public List<Rol> getRoles()
        {
            return this.rol;
        }
        public List<Hotel> getHoteles()
        {
            return this.hotel;
        }

    }
}
