using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmReserva
{
    public partial class RecepcionABMReserva : Form
    {

        private Sesion sesion;
        public RecepcionABMReserva(Sesion sesion)
        {
            this.sesion = sesion;
            InitializeComponent();
        }


        private void generarReserva_click(object sender, EventArgs e)
        {

            using (GenerarReserva generarReserva = new GenerarReserva(sesion))
            {
                var resultFormLogin = generarReserva.ShowDialog();


            }
        }

        private void modificarReserva_click(object sender, EventArgs e)
        {
            using (EditarReserva modificarReserva = new EditarReserva(sesion))
            {
                var resultFormLogin = modificarReserva.ShowDialog();


            }
        }

    }

    
}
