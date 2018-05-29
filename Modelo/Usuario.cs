using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Usuario
    {
        private int idUsuario = 0;
        private int idIdentidad = 0; //ALMACENAMOS MEJOR LA IDENTIDAD DIRECTAMENTE?
        private String username = "";
        private String password = "";
        private int intentosFallidosLogin = 0;
        private Boolean activo = false;        
        private List<Rol> roles = new List<Rol>();
        private List<Hotel> hoteles = new List<Hotel>();

        public Usuario(int idUsuario, int idIdentidad, String username, String password, int intentosFallidosLogin, Boolean activo, List<Rol> roles, List<Hotel> hoteles)
        {
            this.idUsuario = idUsuario;
            this.idIdentidad = idIdentidad;
            this.username = username;
            this.password = password;
            this.intentosFallidosLogin = intentosFallidosLogin;
            this.activo = activo;
            this.roles = roles;
            this.hoteles = hoteles;
        }

        public int getIdUsuario()
        {
            return this.idUsuario;
        }

        public int getIdIdentidad()
        {
            return this.idIdentidad;
        }

        public String getUsername()
        {
            return this.username;
        }

        public String getPassword()
        {
            return this.password;
        }

        public int getIntentosFallidosLogin()
        {
            return this.intentosFallidosLogin;
        }

        public Boolean getActivo()
        {
            return this.activo;
        }

        public List<Rol> getRoles()
        {
            return this.roles;
        }

        public List<Hotel> getHoteles()
        {
            return this.hoteles;
        }

        public Boolean esNuevo()
        {
            return idUsuario.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdUsuario { get { return this.getIdUsuario(); } }
        public int IdIdentidad { get { return this.getIdIdentidad(); } }
        public String Username { get { return this.getUsername(); } }
        public String Password { get { return this.getPassword(); } }
        public int IntentosFallidosLogin { get { return this.getIntentosFallidosLogin(); } }
        public Boolean Activo { get { return this.getActivo(); } }
        public List<Rol> Roles { get { return this.getRoles(); } }
        public List<Hotel> Hoteles { get { return this.getHoteles(); } }
    }
}
