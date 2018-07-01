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
    public partial class CancelarReserva : Form
    {

        private Reserva reserva;
        private Usuario usuario;

        public CancelarReserva(Reserva reserva, Usuario usuario)
        {
            this.reserva = reserva;
            this.usuario = usuario;
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            try
            {
                String motivo = textMotivo.Text;
                RepositorioReserva repoReserva = new RepositorioReserva();
                repoReserva.cancelarReserva(reserva, usuario, motivo);
                MessageBox.Show("Reserva cancelada exitosamente", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
            }
            catch (RequestInvalidoException exception)
            {
                MessageBox.Show(exception.Message, "Verifique los datos ingresados");
            }
        }
    }
}
