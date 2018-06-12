using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class ABMHabitacion : Form
    {
        public ABMHabitacion()
        {
            InitializeComponent();
        }

        private void buttonCrearHabitacion_Click(object sender, EventArgs e)
        {
            using (CrearHabitacion crearHabitacion = new CrearHabitacion())
            {
                var resultFormCrearHabitacion = crearHabitacion.ShowDialog();

                if (resultFormCrearHabitacion == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }
    }
}
