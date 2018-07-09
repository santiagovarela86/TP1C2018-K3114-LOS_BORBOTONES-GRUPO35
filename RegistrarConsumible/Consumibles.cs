using FrbaHotel.Commons;
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
        int idEstadia = 0;
        private Sesion sesion = null;
        public Consumibles(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }
        private void ListadoConsumibles_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = new List<Consumible>();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoConsumibles_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                RepositorioReserva repoReserva = new RepositorioReserva();
                RepositorioEstadia repoEstadia = new RepositorioEstadia();
                String estado = "";

                idEstadia = int.Parse(textBox1.Text);
                //hago el get estado para ver si no termino de ponerle el Reserva Con Consumibles (RCC)
                Reserva reserva= repoReserva.getIdByIdEstadia(idEstadia);
                estado = repoEstadia.getEstado((int)reserva.getCodigoReserva());
                if (estado.Equals("RCI") | estado.Equals("RCE"))
                {
                    RepositorioConsumibles repositorioConsumibles = new RepositorioConsumibles();
                    List<Consumible> consumibles = repositorioConsumibles.getByQuery(idEstadia);
                    dataGridView1.DataSource = consumibles;
                    dataGridView1.ClearSelection();
                }
                else
                    MessageBox.Show("La estadia debe estar con ingreso o con egreso para registrar consumibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show("Ingresar ID estadia por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //aca va el alta del consumible.
            if (textBox1.Text != "")
            {
                using (AltaConsumible form = new AltaConsumible(idEstadia))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                            
                    }
                }
                this.button2_Click(sender, e);
            }
            else
                MessageBox.Show("Ingresar ID estadia por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //pongo el estado en RCC (reserva con consumible) ya queda sin chance de modificar.
            RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();
            RepositorioReserva repoReserva = new RepositorioReserva();
            DateTime date = Utils.getSystemDatetimeNow();

            int idEstadoReserva = 0;
            Reserva reserva = repoReserva.getIdByIdEstadia(idEstadia);
            String desc = "Reserva Con Consumible";
            String tipoEstado = "RCC";
            EstadoReserva estadoReserva = new EstadoReserva(idEstadoReserva, this.sesion.getUsuario(), reserva, tipoEstado, date, desc);
            repoEstadoReserva.update(estadoReserva);
            MessageBox.Show("Consumibles registrados.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea quitar este consumible?", "Baja Logica", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                RepositorioConsumibles repoConsumible = new RepositorioConsumibles();
                Consumible consumible = (Consumible)dataGridView1.CurrentRow.DataBoundItem;

                repoConsumible.baja(consumible,idEstadia);

                //CUANDO DOY DE BAJA EL CONSUMIBLE VUELVO A CARGAR LA LISTA
                this.button2_Click(sender, e);
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
        //ESTO LO PONGO PARA QUE EL NUMERO DE CALLE SOLO PUEDA SER UN NUMERO
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
