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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class Consumibles : Form
    {
        public Consumibles()
        {
            InitializeComponent();
        }
        private void ListadoConsumibles_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBoxTipoDoc.SelectedValue = "";
            dataGridView1.DataSource = new List<Consumible>();
            
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
            this.ListadoConsumibles_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idEstadia = 0;
            if (textBox1.Text != "")
            {
                idEstadia = int.Parse(textBox1.Text);
            }

            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String mail = textBox5.Text;
            String nroDoc = textBox4.Text;
            String tipoDoc = "";
            RepositorioConsumibles repositorioConsumibles = new RepositorioConsumibles();

            if (comboBoxTipoDoc.SelectedItem != null)
            {
                tipoDoc = (String)comboBoxTipoDoc.SelectedItem;
            }

            List<Consumible> consumibles = repositorioConsumibles.getByQuery(idEstadia,nombre, apellido, tipoDoc, nroDoc, mail);

            
            dataGridView1.DataSource = consumibles;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //aca va el alta, tiene que poder editar antes de guardarlo tener en cuenta eso ya que despues no hay baja ni mod.
            using (AltaConsumible form = new AltaConsumible())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    
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
