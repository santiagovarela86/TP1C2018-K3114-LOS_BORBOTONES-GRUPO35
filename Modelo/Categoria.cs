using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Categoria
    {
        private int idCategoria = 0;
        private int estrellas = 0;
        private float recargaEstrellas = 0;

        public Categoria(int idCategoria, int estrellas, float recargaEstrellas)
        {
            this.idCategoria = idCategoria;
            this.estrellas = estrellas;
            this.recargaEstrellas = recargaEstrellas;
        }

        public int getIdCategoria()
        {
            return idCategoria;
        }

        public int getEstrellas()
        {
            return estrellas;
        }

        public float getRecargaEstrellas()
        {
            return recargaEstrellas;
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdCategoria { get { return this.getIdCategoria(); } }
        public int Estrellas { get { return this.getEstrellas(); } }
        public float RecargaEstrellas { get { return this.getRecargaEstrellas(); } }
    }
}
