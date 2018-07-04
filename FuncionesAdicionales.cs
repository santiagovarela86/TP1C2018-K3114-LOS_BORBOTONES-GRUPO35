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
using FrbaHotel.AbmHabitacion;
using FrbaHotel.RegistrarEstadia;
using FrbaHotel.FacturarEstadia;
using FrbaHotel.RegistrarConsumible;

namespace FrbaHotel
{
    public partial class FuncionesAdicionales : Form
    {
        Sesion sesion = null;

        public FuncionesAdicionales(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        public Usuario getUsuarioLogueado()
        {
            return this.sesion.getUsuario();
        }

        public Rol getRolElegido()
        {
            return this.sesion.getRol();
        }

        public Hotel getHotelElegido()
        {
            return this.sesion.getHotel();
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
            //RegistrarConsumible.Enabled = false;

            labelHotel.Text = "Hotel: " + this.getHotelElegido().getNombre();
            labelRol.Text = "Rol: " + this.getRolElegido().getNombre();
            
            try
            {
                this.HabilitarFuncionalidades(this.getUsuarioLogueado());
            } catch (Exception exc){
                MessageBox.Show(exc.Message, "Error al obtener los roles del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarFuncionalidades(Usuario usuarioLogueado)
        {
            List<Funcionalidad> funcionalidades = this.getRolElegido().getFuncionalidades();

            ABMRol.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMRol.Name));
            ABMUsuario.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMUsuario.Name));
            ABMCliente.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMCliente.Name));
            ABMHotel.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMHotel.Name));
            ABMHabitacion.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(ABMHabitacion.Name));
            RegistrarEstadia.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(RegistrarEstadia.Name));
            RegistrarConsumible.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(RegistrarConsumible.Name));
            FacturarEstadia.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(FacturarEstadia.Name));
            GenerarListadoEstadistico.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(GenerarListadoEstadistico.Name));
            //RegistrarConsumible.Enabled = funcionalidades.Exists(f => f.getDescripcion().Equals(RegistrarConsumible.Name));
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
            using (ABMUsuarios formularioABMUsuarios = new ABMUsuarios(this.getHotelElegido()))
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

        private void ABMHotel_Click(object sender, EventArgs e)
        {
            using (SearchHotel formularioABMHotel = new SearchHotel())
            {
                var resultFormABMHotel = formularioABMHotel.ShowDialog();

                if (resultFormABMHotel == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        private void ABMHabitacion_Click(object sender, EventArgs e)
        {
            using (ABMHabitacion formularioABMHabitacion = new ABMHabitacion())
            {
                var resultFormABMHabitacion = formularioABMHabitacion.ShowDialog();

                if (resultFormABMHabitacion == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }
        private void RegistrarEstadia_Click(object sender, EventArgs e)
        {
            using (RegistrarEstadias formularioRegistrarEstadia = new RegistrarEstadias(this.getUsuarioLogueado()))
            {
                var resultFormRegistrarEstadia = formularioRegistrarEstadia.ShowDialog();

                if (resultFormRegistrarEstadia == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }
        private void FacturarEstadia_Click(object sender, EventArgs e)
        {
            using (FacturarEstadias formularioFacturarEstadia = new FacturarEstadias())
            {
                var resultFormFacturarEstadia = formularioFacturarEstadia.ShowDialog();

                if (resultFormFacturarEstadia == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }
        private void RegistrarConsumible_Click(object sender, EventArgs e)
        {
            using (AltaConsumible formularioRegistrarConsumible = new AltaConsumible())
            {
                var resultFormRegistrarConsumible = formularioRegistrarConsumible.ShowDialog();

                if (resultFormRegistrarConsumible == DialogResult.OK)
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
