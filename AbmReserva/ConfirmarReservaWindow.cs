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
    public partial class ConfirmarReservaWindow : Form
    {

        private List<HabitacionDisponibleSearchDTO> habitaciones;
        private DateTime fechaInicio;
        private  DateTime fechaFin;
        private int diasDeEstadia;
        public ConfirmarReservaWindow(List<HabitacionDisponibleSearchDTO> habitaciones, DateTime fechaInicio, DateTime fechaFin)
        {
            this.habitaciones = habitaciones;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.diasDeEstadia = (fechaFin - fechaInicio).Days;
            InitializeComponent();
            init();
        }


        private void init() {

            decimal precioTotal = 0;
            foreach (HabitacionDisponibleSearchDTO habitacion in habitaciones)
            {
                decimal precioHabitacion = (diasDeEstadia * habitacion.PrecioPorNoche);
                precioTotal += precioHabitacion;
                this.labelTipoHabitacion.Text += "Habitacion numero " + habitacion.Numero + " de tipo " + habitacion.getHabitacion().getTipoHabitacion().getDescripcion() + " con el regimen " + habitacion.Regimen + ". Cantidad de dias: " + diasDeEstadia + " por la suma de " + precioHabitacion + "\n";

            }
            this.labelTipoHabitacion.Text += " en el hotel " + habitaciones[0].Hotel + " por la suma de " + precioTotal + "USD\n";
            this.labelTipoHabitacion.Text += "¿Desea realizar la reserva?";
        }

    }
}
