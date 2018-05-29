using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Hotel
    {
        private int idHotel = 0;
        private int idCategoria = 0;
        private int idDireccion = 0;
        private String nombre = "";
        private String mail = "";
        private String telefono = "";
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public Rol(int idRol, String nombre, Boolean activo, List<Funcionalidad> funcionalidades)
        {
            this.idRol = idRol;
            this.nombre = nombre;
            this.activo = activo;
            this.funcionalidades = funcionalidades;
        }
    }
}
