using FrbaHotel.Commons;
using FrbaHotel.Excepciones;
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

namespace FrbaHotel.AbmReserva
{
    public partial class ModificarReserva : Form
    {

        private Usuario usuario;
        public ModificarReserva(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }



        private void onlyNumeric(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoReserva = Utils.validateIntField(textCodigoReserva.Text, "Codigo de Reserva");
                RepositorioReserva repoReserva = new RepositorioReserva();
                Reserva reserva = repoReserva.getReservaByCodigoReserva(codigoReserva);

                if (reserva != null)
                {
                    List<Reserva> reservas = new List<Reserva>();
                    reservas.Add(reserva);
                    dataGridReserva.DataSource = reservas;

                    DateTime fechaAhora = DateTime.Now;
                    DateTime fechaInicio = reserva.getFechaDesde();
                    if (((fechaInicio - fechaAhora).TotalDays > 1) && (fechaInicio > fechaAhora))
                    {
                        this.buttonModificar.Enabled = true;
                        this.buttonCancelar.Enabled = true;
                    }
                }
            }catch(RequestInvalidoException exception){
                MessageBox.Show(exception.Message, "Verifique los datos ingresados");

                }


        }
    }


}
