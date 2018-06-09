using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Modelo;
using FrbaHotel.AbmRol;
using FrbaHotel.AbmUsuario;
using FrbaHotel.AbmHotel;
using FrbaHotel.AbmCliente;

namespace FrbaHotel
{
    public partial class FuncionesAdicionales : Form
    {
        Usuario usuarioLogueado = null;

        public FuncionesAdicionales(Usuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FuncionesAdicionales_Load(object sender, EventArgs e)
        {
            ABMRol.Enabled = false;
            ABMUsuario.Enabled = false;
            ABMCliente.Enabled = false;
            ABMHotel.Enabled = false;
            ABMHabitacion.Enabled = false;
            RegistrarEstadia.Enabled = false;
            RegistrarConsumible.Enabled = false;
            FacturarEstadia.Enabled = false;
            GenerarListadoEstadistico.Enabled = false;
            RegistrarConsumible.Enabled = false;
            
            try
            {
                this.HabilitarFuncionalidades(usuarioLogueado);
            } catch (Exception exc){
                MessageBox.Show(exc.Message, "Error al obtener los roles del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarFuncionalidades(Usuario usuarioLogueado)
        {
            //SE SUPONE QUE PARA SIMPLIFICAR EL USUARIO VA A TENER UN SOLO ROL
            List<Funcionalidad> funcionalidades = usuarioLogueado.getRoles().First().getFuncionalidades();

            ABMRol.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMRol.Name));
            ABMUsuario.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMUsuario.Name));
            ABMCliente.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMCliente.Name));
            ABMHotel.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMHotel.Name));
            ABMHabitacion.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMHabitacion.Name));
            RegistrarEstadia.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(RegistrarEstadia.Name));
            RegistrarConsumible.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(RegistrarConsumible.Name));
            FacturarEstadia.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(FacturarEstadia.Name));
            GenerarListadoEstadistico.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(GenerarListadoEstadistico.Name));
            RegistrarConsumible.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(RegistrarConsumible.Name));
        }

        private void ABMRol_Click(object sender, EventArgs e)
        {
            using (ABMRoles formularioABMRoles = new ABMRoles())
            {
                var resultFormABMRoles = formularioABMRoles.ShowDialog();

                if (resultFormABMRoles == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        private void ABMUsuario_Click(object sender, EventArgs e)
        {
            using (ABMUsuarios formularioABMUsuarios = new ABMUsuarios())
            {
                var resultFormABMUsuarios = formularioABMUsuarios.ShowDialog();

                if (resultFormABMUsuarios == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        private void ABMCliente_Click(object sender, EventArgs e)
        {
            using (ABMClientes formularioABMClientes = new ABMClientes())
            {
                var resultFormABMClientes = formularioABMClientes.ShowDialog();

                if (resultFormABMClientes == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }
    }
}
