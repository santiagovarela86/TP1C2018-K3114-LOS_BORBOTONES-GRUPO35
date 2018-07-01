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

        private Usuario usuario;
        public ModificarReserva(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }
    }
}
