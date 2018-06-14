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

        private void buttonBajaHabitacion_Click(object sender, EventArgs e)
        {

            using (BajaHabitacion bajaHabitacion = new BajaHabitacion())
            {
                var resultFormBajaHabitacion = bajaHabitacion.ShowDialog();

                if (resultFormBajaHabitacion == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        //CIERRO LA VENTANA CON ESCAPE
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
