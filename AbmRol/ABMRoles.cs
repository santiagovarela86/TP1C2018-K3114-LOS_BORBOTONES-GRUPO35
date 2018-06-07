using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Repositorios;
using FrbaHotel.Modelo;

namespace FrbaHotel.AbmRol
{
    public partial class ABMRoles : Form
    {
        public ABMRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBoxEstados.SelectedValue = "";
            comboBoxFuncionalidades.SelectedValue = "";
            dataGridView1.DataSource = new List<Rol>();
            this.button4.Enabled = false;
            this.button5.Enabled = false;
            
            dataGridView1.DataSource = new List<Rol>();

            List<KeyValuePair<String, Boolean>> estados = new List<KeyValuePair<String, Boolean>>();
            estados.Add(new KeyValuePair<String, Boolean>("Habilitado", true));
            estados.Add(new KeyValuePair<String, Boolean>("Inhabilitado", false));
            comboBoxEstados.ValueMember = "Value";
            comboBoxEstados.DisplayMember = "Key";
            comboBoxEstados.DataSource = estados;
            comboBoxEstados.SelectedValue = "";

            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();
            comboBoxFuncionalidades.ValueMember = "idFuncionalidad";
            comboBoxFuncionalidades.DisplayMember = "descripcion";
            comboBoxFuncionalidades.DataSource = repositorioFuncionalidad.getAll();
            comboBoxFuncionalidades.SelectedValue = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoRoles_Load(sender, e);
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            String nombreRol = textBox1.Text;
            KeyValuePair<String, Boolean> estado = new KeyValuePair<String, Boolean>();
            Funcionalidad funcionalidad = null;
            RepositorioRol repositorioRoles = new RepositorioRol();

            if (comboBoxEstados.SelectedItem != null)
            {
                estado = (KeyValuePair<String, Boolean>)comboBoxEstados.SelectedItem;
            }

            if (comboBoxFuncionalidades.SelectedItem != null)
            {
                funcionalidad = (Funcionalidad)comboBoxFuncionalidades.SelectedItem;
            }

            List<Rol> roles = repositorioRoles.getByQuery(nombreRol, estado, funcionalidad);

            dataGridView1.DataSource = roles;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (AltaRol form = new AltaRol())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    //this.txtSomething.Text = val;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rol rol = (Rol) dataGridView1.CurrentRow.DataBoundItem;

            using (ModificacionRol form = new ModificacionRol(rol))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    //this.txtSomething.Text = val;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.button4.Enabled = true;
            this.button5.Enabled = true;
        }
    }
}
