using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    class Rol
    {
        private int id;
        private String nombre;
        private Boolean activo;
        private List<Funcionalidad> funcionalidades;

        public Rol(int id, String nombre, Boolean activo, List<Funcionalidad> funcionalidades)
        {
            this.id = id;
            this.nombre = nombre;
            this.activo = activo;
            this.funcionalidades = funcionalidades;
        }

    }
}
