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
using FrbaHotel.Modelo;

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
            using (FormLogin formularioLogin = new FormLogin())
            {
                var resultFormLogin = formularioLogin.ShowDialog();

                if (resultFormLogin == DialogResult.OK)
                {
                    Usuario usuarioLogueado = formularioLogin.getUsuarioLogueado();

                    //ABRO EL SUBFORMULARIO DE FUNCIONES ADICIONALES
                    using (FuncionesAdicionales subForm = new FuncionesAdicionales(usuarioLogueado))
                    {
                        var resultSubForm = subForm.ShowDialog();
                    }

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
