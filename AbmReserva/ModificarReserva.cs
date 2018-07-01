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
            List<Habitacion> habitaciones = reserva.getHabitaciones();
            Regimen regimen=reserva.getRegimen();
            this.labelHotelActual.Text = "Hotel reservado : " + reserva.getHotel().getNombre();
            this.labelRegimenActual.Text = "Regimen reservado : " + regimen.getDescripcion();
            
            this.dataGridView1.DataSource=buildHabitacionesReservadas(habitaciones,regimen);
        }


        private List<HabitacionDisponibleSearchDTO> buildHabitacionesReservadas(List<Habitacion> habitaciones,Regimen regimen){
            List<HabitacionDisponibleSearchDTO> habitacionesReservadas = new List<HabitacionDisponibleSearchDTO>();
            foreach(Habitacion hab in habitaciones){
            habitacionesReservadas.Add(new HabitacionDisponibleSearchDTO(hab,regimen));
            }
            return habitacionesReservadas;
        }

    }
}
