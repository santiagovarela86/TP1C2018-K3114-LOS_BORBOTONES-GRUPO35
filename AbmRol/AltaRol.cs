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
using FrbaHotel.Repositorios;
using System.Diagnostics;

namespace FrbaHotel.AbmRol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AltaRol_Load(sender, e);
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();
            dataGridView1.DataSource = repositorioFuncionalidad.getAll();
            dataGridView1.ClearSelection();
            textBox1.Text = "";
            checkBox1.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
