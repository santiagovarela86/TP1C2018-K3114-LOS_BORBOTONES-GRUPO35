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

namespace FrbaHotel.AbmHabitacion
{
    public partial class BajaHabitacion : Form
    {

        private Habitacion habitacionBaja;
        public BajaHabitacion(Habitacion habitacion)
        {
            this.habitacionBaja = habitacion;
            InitializeComponent();
            habitacionLabel.Text = "Habitacion Nº" + habitacionBaja.getNumero() + ". Piso: " + habitacionBaja.getPiso() + ". Hotel: " + habitacionBaja.getHotel().getNombre(); 

            checkBoxActiva.Checked = false;

        }

        private void buttonActivarDesactivarHabitacion_Click(object sender, EventArgs e)
        {
            RepositorioHabitacion repositorioHabitacion = new RepositorioHabitacion();
            bool activa=checkBoxActiva.Checked;
            habitacionBaja.setActiva(activa);
            repositorioHabitacion.bajaLogica(habitacionBaja);

            MessageBox.Show("Habitacion " + (activa?"Activada":"Desactivada"), "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");

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
