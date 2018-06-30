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
            //ABRO EL FORMULARIO DE LOGIN
            using (FormLogin formularioLogin = new FormLogin())
            {
                var resultFormLogin = formularioLogin.ShowDialog();

                //SI EL LOGIN ES EXITOSO
                if (resultFormLogin == DialogResult.OK)
                {
                    Usuario usuarioLogueado = formularioLogin.getUsuarioLogueado();

                    //VALIDO QUE TENGA ROLES HABILITADOS
                    if (usuarioLogueado.getRoles().FindAll(rol => rol.getActivo()).Count == 0)
                    {
                        MessageBox.Show("El usuario con el que intenta iniciar sesión, no tiene roles habilitados, contáctese con el administrador del sistema.", "Error Seleccionando Hotel y Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else 
                    {
                        //ABRO EL FORMULARIO DE SELECCION DE ROL Y HOTEL
                        using (SeleccionRolYHotel formularioSeleccionRolYHotel = new SeleccionRolYHotel(usuarioLogueado))
                        {
                            var resultFormSesion = formularioSeleccionRolYHotel.ShowDialog();

                            //SI EL RESULTADO ES EXITOSO
                            if (resultFormSesion == DialogResult.OK)
                            {
                                Sesion sesion = formularioSeleccionRolYHotel.getSesion();

                                //ABRO EL SUBFORMULARIO DE FUNCIONES ADICIONALES
                                using (FuncionesAdicionales subForm = new FuncionesAdicionales(sesion))
                                {
                                    var resultSubForm = subForm.ShowDialog();
                                }
                            }
                        }
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
