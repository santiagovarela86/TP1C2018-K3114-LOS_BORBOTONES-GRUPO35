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
    public partial class AltaConsumible : Form
    {
        int idEstadia = 0;
        public AltaConsumible(int estadia)
        {
            InitializeComponent();
            this.idEstadia = estadia;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AltaConsumible_Load(sender, e);
        }

        private void AltaConsumible_Load(object sender, EventArgs e)
        {
            RepositorioConsumibles repositorioConsumible = new RepositorioConsumibles();
            dataGridView1.DataSource = repositorioConsumible.getAll().OrderBy(c => c.getDescripcion()).ToList();
            dataGridView1.ClearSelection();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Consumible consumible = null;
            int idConsumible = 0;

            //traigo el consumible elegido (solo dejo traer uno)
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
               consumible = item.DataBoundItem as Consumible;
            }
            RepositorioConsumibles repoConsumible = new RepositorioConsumibles();

                 //sumar el consumible elegido a la estadia marcada
                 consumible.setIdEstadia(idEstadia);
                 //metodo registrar que no crea el consumible solo lo suma
                 idConsumible = repoConsumible.registrar(consumible);
                    if (idConsumible == consumible.getIdConsumible())
                    {
                        MessageBox.Show("Consumible Registrado correctamente en la estadia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.AltaConsumible_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el consumible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.AltaConsumible_Load(sender, e);
                    }
            
            }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

