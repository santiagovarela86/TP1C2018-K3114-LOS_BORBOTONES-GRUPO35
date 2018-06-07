using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FrbaHotel.Repositorios;
using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;

namespace FrbaHotel.Login
{
    public partial class FormLogin : Form
    {
        private Usuario usuarioLogueado = null;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void BotonLoginClick(object sender, EventArgs e)
        {
            RepositorioUsuario repoUsuario = new RepositorioUsuario();

            try
            {
                //CREDENCIALES CORRECTAS
                usuarioLogueado = repoUsuario.AutenticarUsuario(txtUsername.Text, txtPassword.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (ErrorDeAutenticacionException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UsuarioBloqueadoException exc1)
            {
                MessageBox.Show(exc1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Usuario getUsuarioLogueado()
        {
            return this.usuarioLogueado;
        }
    }
}
