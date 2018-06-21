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
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.AltaCliente_Load(sender, e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //GENERAR ALTA (no pido el estado ya que va como activo al momento de crearlo)

            //traigo los valores
            String nacionalidad = textBox2.Text;
            String nombre = textBox3.Text;
            String apellido = textBox4.Text;
            String nroDoc = textBox5.Text;
            String mail = textBox6.Text;
            String telefono = textBox7.Text;
            String calle = textBox8.Text;
            String localidad = textBox9.Text;
            String paisOrigen = textBox10.Text;
            DateTime fechaNacimiento = dateTime.Value;
            int nroCalle = 0;
            if (textBox12.Text != "")
            {
                nroCalle = int.Parse(textBox12.Text);
            }
            int nroPiso = 0;
            if (textBox13.Text != "")
            {
                nroPiso = int.Parse(textBox13.Text);
            }

            String depto = textBox14.Text;
            String tipoDoc = "";
            String tipoIdentidad = "Cliente";
            int idDir = 0;
            int idIdentidad = 0;
            int idCliente = 0;
            Boolean activo = true;
            List<Reserva> reservas = new List<Reserva>();
            if (comboBoxTipoDoc.SelectedItem != null)
            {
                tipoDoc = (String)comboBoxTipoDoc.SelectedItem;
            }
            //armo direccion (id en 0)
            Direccion adress = new Direccion(idDir, paisOrigen, localidad,
            calle, nroCalle, nroPiso, depto);
            //armo la identidad con la direccion(id en 0)
            Identidad identidad = new Identidad(idIdentidad, tipoIdentidad, nombre, apellido, tipoDoc, nroDoc,
            mail, fechaNacimiento, nacionalidad, telefono, adress);
            // armo el cliente con la identidad (id en 0)
            Cliente cliente = new Cliente(idCliente,identidad, activo,reservas);
            //ahora si ya lo puedo crear
            RepositorioCliente repoCliente = new RepositorioCliente();
            repoCliente.create(cliente);
            

        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            //vacio todos los campos porque es el limpiar
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";

            
            comboBoxTipoDoc.SelectedValue = "";
            dateTime.ResetText();

            List<String> tipoDoc = new List<String>();
            tipoDoc.Add("DNI");
            tipoDoc.Add("Pasaporte");
            tipoDoc.Add("CUIT");
            tipoDoc.Add("LE");
            tipoDoc.Add("LC");
            comboBoxTipoDoc.ValueMember = "Value";
            comboBoxTipoDoc.DisplayMember = "Key";
            comboBoxTipoDoc.DataSource = tipoDoc;
            comboBoxTipoDoc.SelectedValue = "";

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

