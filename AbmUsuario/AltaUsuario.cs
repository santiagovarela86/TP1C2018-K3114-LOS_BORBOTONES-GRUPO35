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
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.AltaUsuario_Load(sender, e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //GENERAR ALTA (no pido el estado ya que va como activo al momento de crearlo)

            //traigo los valores
            String username = textBox1.Text;
            String password = textBox2.Text;
            String nombre = textBox3.Text;
            String apellido = textBox4.Text;
            String nroDoc = textBox5.Text;
            String mail = textBox6.Text;
            String telefono = textBox7.Text;
            String calle = textBox8.Text;
            String localidad = textBox15.Text;
            String pais = textBox16.Text;
            String nacionalidad = textBox17.Text;
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
            String tipoIdentidad = "Usuario";
            int idDir = 0;
            int idIdentidad = 0;
            int idUsuario = 0;
            int intentosFallidosLogin = 0;
            Boolean activo = true;
            if (comboBoxTipoDoc.SelectedItem != null)
            {
                tipoDoc = (String)comboBoxTipoDoc.SelectedItem;
            }
            //traigo los roles elegidos
            List<Rol> roles = new List<Rol>();
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    roles.Add(item.DataBoundItem as Rol);
                }
            //traigo los hoteles elegidos
            List<Hotel> hoteles = new List<Hotel>();
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                hoteles.Add(item.DataBoundItem as Hotel);
            }

            //armo direccion (id en 0)
            Direccion adress = new Direccion(idDir,pais, localidad,
            calle, nroCalle, nroPiso, depto);
            //armo la identidad con la direccion(id en 0)
            Identidad identidad =new Identidad(idIdentidad,tipoIdentidad,nombre, apellido,tipoDoc,nroDoc,
            mail,fechaNacimiento,nacionalidad,telefono, adress);
            // armo el usuario con la identidad (id en 0)
            Usuario user = new Usuario(idUsuario, identidad, username,password,intentosFallidosLogin, activo,roles,hoteles);
            //ahora si ya lo puedo crear
            RepositorioUsuario repoUser = new RepositorioUsuario();
            repoUser.create(user);
            //validar que el username sea unico y encriptar clave
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            //vacio todos los campos porque es el limpiar
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
       
            
            //cargo rol
            RepositorioRol repositorioRol = new RepositorioRol();
            dataGridView1.DataSource = repositorioRol.getAll();
            dataGridView1.ClearSelection();
            
            //cargo hotel
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            dataGridView2.DataSource = repositorioHotel.getAll();
            dataGridView2.ClearSelection();
            
            comboBoxTipoDoc.SelectedValue = "";
            dateTime.ResetText();

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
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
