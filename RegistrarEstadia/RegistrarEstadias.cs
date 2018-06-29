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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class RegistrarEstadias : Form
    {
        public RegistrarEstadias()
        {
            InitializeComponent();
        }
        private void ListadoRegistrarEstadia_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoRegistrarEstadia_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CHECK IN
            int codReserva = 0;
            String username = "";
            DateTime date = DateTime.Today;
            int estadoValidez = 0;
            DateTime dateTest = new DateTime(2017, 1, 1);
            RepositorioReserva repositorioReserva = new RepositorioReserva();
            if (textBox1.Text != "" | textBox2.Text != "")
            {
                codReserva = int.Parse(textBox1.Text);
                username = textBox2.Text;
                //traigo la fecha veo si es valido, si corresponde al hotel del usuario
                estadoValidez = repositorioReserva.GetReservaValida(codReserva, date, username);
                if (estadoValidez==1)
                { 
                    //es valida ya se dio de alta la reserva(con usuario y fecha)
                    //Traigo otra pantalla para los huespedes
                    MessageBox.Show("La reserva es valida", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    /*using (AltaFacturaEstadia form = new AltaFacturaEstadia())
                      {
                          var result = form.ShowDialog();

                          if (result == DialogResult.OK)
                          {

                          }
                      }*/
                }
                else if (estadoValidez == 2)
                {
                    MessageBox.Show("La reserva ingresada difiere de la Fecha de Check In, generar otra nueva ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

                }
                else if (estadoValidez == 3)
                {
                    MessageBox.Show("La reserva ingresada no corresponde al hotel al que el usuario tiene permisos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (estadoValidez == 4)
                {
                    MessageBox.Show("No se pudo dar de alta la estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresar codigo de reserva y username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //CHECK OUT
            int codReserva = 0;
            String username = "";
            int idEstadia = 0;
            //si se va antes de la fecha de salida tengo que poner bien los dias porque dsp en la factura se hace algo con esto
            DateTime date = DateTime.Today;
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioReserva repoReserva = new RepositorioReserva();
            if (textBox1.Text != "" | textBox2.Text != "")
            {
                codReserva = int.Parse(textBox1.Text);
                //ESTO SE VA AL TRAER ID DIRECTO DEL LOGIN
                username = textBox2.Text;
                Usuario user = null;
                RepositorioUsuario repoUser =new RepositorioUsuario();
                user = repoUser.getByUsername(username);
                //consigo del codigo de reserva el idEstadia
                idEstadia = repoReserva.getIdEstadiaByCodReserva(codReserva);

                Estadia estadia = new Estadia(idEstadia,user,date);
                repoEstadia.update(estadia);
                //hago update de EstadoReserva
                RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();
                int idEstadoReserva=0;
                Reserva reserva =repoReserva.getIdByIdEstadia(estadia.getIdEstadia());
                String desc="Reserva Con Egreso";
                String tipoEstado="RCE";
                EstadoReserva estadoReserva=new EstadoReserva(idEstadoReserva, user, reserva, tipoEstado, date, desc);
                repoEstadoReserva.update(estadoReserva);

                MessageBox.Show("Check out correcto, proceder a facturar Estadia", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            //llamo a facturar estadia para que sea mas happy path
            /*using (AltaFacturaEstadia form = new AltaFacturaEstadia())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                }
            }*/
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


