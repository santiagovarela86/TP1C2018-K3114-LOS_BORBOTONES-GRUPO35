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

namespace FrbaHotel.FacturarEstadia
{
    public partial class FacturarEstadias : Form
    {
        public FacturarEstadias()
        {
            InitializeComponent();
        }
        private void ListadoFacturarEstadia_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = new List<Estadia>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoFacturarEstadia_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idEstadia = 0;
            RepositorioEstadia repositorioEstadias = new RepositorioEstadia();
            if (textBox1.Text != "")
            {
                idEstadia = int.Parse(textBox1.Text);
                
                Estadia estadia = repositorioEstadias.getById(idEstadia);

                dataGridView1.DataSource = estadia;
                dataGridView1.ClearSelection();
            }else
            {
                List<Estadia> estadias = repositorioEstadias.getAll();
                dataGridView1.DataSource = estadias;
                dataGridView1.ClearSelection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //aca va el alta, tiene que poder editar antes de guardarlo tener en cuenta eso ya que despues no hay baja ni mod.
            /*using (AltaFacturaEstadia form = new AltaFacturaEstadia())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                }
            }*/
        }

    }
}

