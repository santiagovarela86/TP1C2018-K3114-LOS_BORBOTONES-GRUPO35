using FrbaHotel.Modelo;
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

        private Reserva reserva;
        private Usuario usuario;
        public ModificarReserva(Reserva reserva, Usuario usuario)
        {
            this.reserva = reserva;
            this.usuario = usuario;
            InitializeComponent();

            this.labelHotelActual.Text = "Hotel reservado : " + reserva.getHotel().getNombre();
            this.labelRegimenActual.Text = "Regimen reservado : " + reserva.getRegimen().getDescripcion();

        }

    }
}
