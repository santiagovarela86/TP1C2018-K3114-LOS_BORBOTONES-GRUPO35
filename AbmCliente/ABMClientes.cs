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

namespace FrbaHotel.AbmCliente
{
    public partial class ABMClientes : Form
    {
        public ABMClientes()
        {
            InitializeComponent();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBoxEstados.SelectedValue = "";
            comboBoxTipoDoc.SelectedValue = "";
            dataGridView1.DataSource = new List<Cliente>();
            this.button4.Enabled = false;
            this.button5.Enabled = false;

            dataGridView1.DataSource = new List<Cliente>();

            List<KeyValuePair<String, Boolean>> estados = new List<KeyValuePair<String, Boolean>>();
            estados.Add(new KeyValuePair<String, Boolean>("Habilitado", true));
            estados.Add(new KeyValuePair<String, Boolean>("Inhabilitado", false));
            comboBoxEstados.ValueMember = "Value";
            comboBoxEstados.DisplayMember = "Key";
            comboBoxEstados.DataSource = estados;
            comboBoxEstados.SelectedValue = "";

            List<String> tipoDoc = new List<String>();
            tipoDoc.Add("DNI");
            tipoDoc.Add("CUIT");
            tipoDoc.Add("LE");
            tipoDoc.Add("LC");
            comboBoxTipoDoc.ValueMember = "Value";
            comboBoxTipoDoc.DisplayMember = "Key";
            comboBoxTipoDoc.DataSource = tipoDoc;
            comboBoxTipoDoc.SelectedValue = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoClientes_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nombre = textBox1.Text;
            String apellido = textBox2.Text;
            String mail = textBox3.Text;
            String nroDoc = textBox4.Text;
            KeyValuePair<String, Boolean> estado = new KeyValuePair<String, Boolean>();
            String tipoDoc = "";
            RepositorioCliente repositorioClientes = new RepositorioCliente();

            if (comboBoxEstados.SelectedItem != null)
            {
                estado = (KeyValuePair<String, Boolean>)comboBoxEstados.SelectedItem;
            }

            if (comboBoxTipoDoc.SelectedItem != null)
            {
                tipoDoc = (String)comboBoxTipoDoc.SelectedItem;
            }

            List<Cliente> clientes = repositorioClientes.getByQuery(nombre,apellido,tipoDoc,nroDoc,estado,mail);

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DataSource = clientes;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //aca va el alta
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //aca va la modificacion
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //aca va la baja
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.button4.Enabled = true;
            this.button5.Enabled = true;
        }

    }
}
