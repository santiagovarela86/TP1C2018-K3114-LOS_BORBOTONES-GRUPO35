using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Rol
    {
        private int idRol;
        private String nombre;
        private Boolean activo;
        private List<Funcionalidad> funcionalidades;

        public Rol(int idRol, String nombre, Boolean activo, List<Funcionalidad> funcionalidades)
        {
            this.idRol = idRol;
            this.nombre = nombre;
            this.activo = activo;
            this.funcionalidades = funcionalidades;
        }

        public int getIdRol()
        {
            return this.idRol;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public Boolean getActivo()
        {
            return this.activo;
        }

        public List<Funcionalidad> getFuncionalidades()
        {
            return this.funcionalidades;
        }

    }
}
