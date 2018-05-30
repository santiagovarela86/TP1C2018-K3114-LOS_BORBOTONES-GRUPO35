using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class TipoHabitacion
    {
        private int idTipoHabitacion = 0;
        private int codigo = 0;
        private float porcentual = 0;
        private String descripcion = "";

        public TipoHabitacion(int idTipoHabitacion, int codigo, float porcentual, String descripcion)
        {
            this.idTipoHabitacion = idTipoHabitacion;
            this.codigo = codigo;
            this.porcentual = porcentual;
            this.descripcion = descripcion;
        }

        public int getIdTipoHabitacion()
        {
            return this.idTipoHabitacion;
        }

        public int getCodigo()
        {
            return this.codigo;
        }

        public float getPorcentual()
        {
            return this.porcentual;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdTipoHabitacion { get { return this.getIdTipoHabitacion(); } }
        public int Codigo { get { return this.getCodigo(); } }
        public float Porcentual { get { return this.getPorcentual(); } }
        public String Descripcion { get { return this.getDescripcion(); } }

    }
}
