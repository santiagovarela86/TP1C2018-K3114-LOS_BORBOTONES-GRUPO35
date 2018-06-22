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

namespace FrbaHotel.AbmUsuario
{
    public partial class ABMUsuarios : Form
    {
        public ABMUsuarios()
        {
            InitializeComponent();
        }
        private void ListadoUsuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<Usuario>();
            List<KeyValuePair<String, Boolean>> estados = new List<KeyValuePair<String, Boolean>>();
            estados.Add(new KeyValuePair<String, Boolean>("Habilitado", true));
            estados.Add(new KeyValuePair<String, Boolean>("Inhabilitado", false));
            comboBoxEstados.ValueMember = "Value";
            comboBoxEstados.DisplayMember = "Key";
            comboBoxEstados.DataSource = estados;
            comboBoxEstados.SelectedValue = "";

            RepositorioRol repositorioRol = new RepositorioRol();
            comboBoxRoles.ValueMember = "idRol";
            comboBoxRoles.DisplayMember = "Nombre";
            comboBoxRoles.DataSource = repositorioRol.getAll();
            comboBoxRoles.SelectedValue = "";

            RepositorioHotel repositorioHotel = new RepositorioHotel();
            comboBoxHoteles.ValueMember = "idHotel";
            comboBoxHoteles.DisplayMember = "Nombre";
            comboBoxHoteles.DataSource = repositorioHotel.getAll();
            comboBoxHoteles.SelectedValue = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.limpiarBusquedaYResultados();
        }

        private void limpiarBusquedaYResultados()
        {
            textBox1.Text = "";
            comboBoxEstados.SelectedValue = "";
            comboBoxRoles.SelectedValue = "";
            comboBoxHoteles.SelectedValue = "";
            dataGridView1.DataSource = new List<Usuario>();
            this.button4.Enabled = false;
            this.button5.Enabled = false;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            KeyValuePair<String, Boolean> estado = new KeyValuePair<String, Boolean>();
            Rol rol = null;
            Hotel hotel = null;

            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();

            if (comboBoxEstados.SelectedItem != null)
            {
                estado = (KeyValuePair<String, Boolean>)comboBoxEstados.SelectedItem;
            }

            if (comboBoxRoles.SelectedItem != null)
            {
                rol = (Rol)comboBoxRoles.SelectedItem;
            }
            if (comboBoxHoteles.SelectedItem != null)
            {
                hotel = (Hotel)comboBoxHoteles.SelectedItem;
            }

            List<Usuario> usuarios = repositorioUsuario.getByQuery(username, estado, hotel,rol);

            dataGridView1.DataSource = usuarios;
            //ESTO LO TENGO QUE HACER PARA QUE NO APAREZCA SIEMPRE SELECCIONADO EL PRIMER ITEM
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            //PONGO ESTO ACA PARA QUE DESPUES DE DAR DE ALTA, MODIFICAR O DAR DE BAJA
            //Y SE VUELVA A CARGAR LA LISTA, NO SE PUEDA MODIFICAR O DAR DE BAJA
            //UN ROL NULL...
            this.button4.Enabled = false;
            this.button5.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (AltaUsuario form = new AltaUsuario())
            {
                var result = form.ShowDialog();

                //AL CERRAR LA VENTANA DESPUES DE DAR DE ALTA UN NUEVO ROL VUELVO A CARGAR LA LISTA
                this.buscar_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario) dataGridView1.CurrentRow.DataBoundItem;

            using (ModificacionUsuario form = new ModificacionUsuario(usuario))
            {
                var result = form.ShowDialog();

                //AL CERRAR LA VENTANA DESPUES DE DAR DE ALTA UN NUEVO ROL VUELVO A CARGAR LA LISTA
                this.buscar_Click(sender, e);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null) return;
            if (dgv.CurrentRow.Selected)
            {
                this.button4.Enabled = true;
                this.button5.Enabled = true;
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
