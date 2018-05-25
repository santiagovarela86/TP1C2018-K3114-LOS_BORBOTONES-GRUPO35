using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Funcionalidad
    {
        private int idFuncionalidad;
        private String descripcion;

        public Funcionalidad(int idFuncionalidad, String descripcion)
        {
            this.idFuncionalidad = idFuncionalidad;
            this.descripcion = descripcion;
        }

        public int getIdFuncionalidad()
        {
            return this.idFuncionalidad;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        //Estos metodos/propiedades/atributos(???) extra los necesito para popular los combo Box
        public int idFuncionalidadI { get { return idFuncionalidad; } }
        public String descripcionI { get { return descripcion; } }

    }
}
