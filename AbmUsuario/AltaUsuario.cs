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
            //GENERAR ALTA
            //Validar username que sea unico

            //encriptar clave
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
            textBox9.Text = "";
            checkBox1.Checked = false;
            //cargo rol
            RepositorioRol repositorioRol = new RepositorioRol();
            dataGridView1.DataSource = repositorioRol.getAll();
            dataGridView1.ClearSelection();
            
            //cargo hotel
            /*RepositorioHotel repositorioHotel = new RepositorioHotel();
            dataGridView2.DataSource = repositorioHotel.getAll();
            dataGridView2.ClearSelection();
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
