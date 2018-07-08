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
    public partial class EditarReserva : Form
    {

        private Usuario usuario;
        private Sesion sesion;
        public EditarReserva(Sesion sesion)
        {
            this.sesion = sesion;
            this.usuario = sesion != null ? sesion.getUsuario() : null;
            InitializeComponent();
        }

        public EditarReserva(Usuario usuario)
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

                    if (sesion != null && reserva.getHotel().getIdHotel() != sesion.getHotel().getIdHotel())
                    {
                        MessageBox.Show("La reserva buscada no corresponde al hotel " + sesion.getHotel().getNombre(), "Editar reserva");
                        return;
                    }

                    List<EstadoReserva> estadosDeLaReserva = reserva.getEstados();
                    List<String> estadosNoModificables = new List<String>(new String[] { "RCC", "RCR", "RCNS", "RCE", "RCI", "RF" });
                    bool noPuedeModificar = estadosDeLaReserva.Exists(estado => estadosNoModificables.Exists(estadoNoModificable => estadoNoModificable.Equals(estado.getTipoEstado())));

                    if (noPuedeModificar)
                    { 
                        MessageBox.Show("No puede modificar la reserva por que la misma ha alcanzado un estado final", "Editar reserva");
                        return;
                    }


                    DateTime fechaAhora = DateTime.Now;
                    DateTime fechaInicio = reserva.getFechaDesde();


                    if (((fechaInicio - fechaAhora).TotalDays > 1) && (fechaInicio > fechaAhora))
                    {
                        this.buttonModificar.Enabled = true;
                        this.buttonCancelar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ha pasado el plazo maximo de 24 para modificar/cancelar su reserva.", "Editar reserva");
                        return;
                    }



                    List<Reserva> reservas = new List<Reserva>();
                    reservas.Add(reserva);
                    dataGridReserva.DataSource = reservas;

                }else{
                    MessageBox.Show("No se ha encontrado la reserva.", "Editar reserva");
                }
            }catch(RequestInvalidoException exception){
                MessageBox.Show(exception.Message, "Verifique los datos ingresados");
                }


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Reserva reserva=null;
            foreach (DataGridViewRow item in this.dataGridReserva.SelectedRows)
            {
                reserva = item.DataBoundItem as Reserva;
            }
            using (CancelarReserva form = new CancelarReserva(reserva, usuario))
            {
                var result = form.ShowDialog();
                this.Close();
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Reserva reserva = null;
            foreach (DataGridViewRow item in this.dataGridReserva.SelectedRows)
            {
                reserva = item.DataBoundItem as Reserva;
            }

            using (ModificarReserva form = new ModificarReserva(reserva,usuario))
            {
                var result = form.ShowDialog();
                this.Close();
            }
        }
        
    }


}
