using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Login;

namespace FrbaHotel
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FormLogin form = new FormLogin())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //ABRO EL SUBFORMULARIO DE FUNCIONES ADICIONALES
                    using (FuncionesAdicionales subForm = new FuncionesAdicionales())
                    {
                        var resultSubForm = subForm.ShowDialog();
                    }

                }
            }
        }
    }
}
