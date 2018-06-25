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

namespace FrbaHotel.AbmReserva
{
    public partial class GenerarReserva : Form
    {
        public GenerarReserva()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            RepositorioTipoHabitacion repoTipoHabitacion = new RepositorioTipoHabitacion();
            RepositorioHotel repoHotel = new RepositorioHotel();

            comboBoxTipoHabitacion.DisplayMember = "Descripcion";
            comboBoxTipoHabitacion.ValueMember = "Descripcion";
            comboBoxTipoHabitacion.DataSource = repoTipoHabitacion.getAll();

            comboBoxHotel.DisplayMember = "Nombre";
            comboBoxHotel.ValueMember = "Nombre";
            comboBoxHotel.DataSource = repoHotel.getAll();
        }

        private void eventHandlerHotelComboBox(object sender, EventArgs e)
        {

            if (this.comboBoxHotel.SelectedItem == null)
            {
                this.comboBoxRegimen.Enabled = false;
                this.comboBoxRegimen.DataSource = new List<Hotel>();
            }
            else
            {
                Hotel hotel = (Hotel)this.comboBoxHotel.SelectedItem;
                this.comboBoxRegimen.DataSource = hotel.getRegimenes();
                this.comboBoxRegimen.Enabled = true;
                this.comboBoxRegimen.DisplayMember = "Descripcion";
                this.comboBoxRegimen.ValueMember = "Descripcion";
                this.comboBoxRegimen.SelectedIndex = -1;
                this.comboBoxRegimen.SelectedValue = "";


            }
        }

        private void bajaHotel_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = (DateTime)Utils.validateFields(calendarioDesde.SelectionStart,"Fecha Desde");
            DateTime fechaFin = (DateTime)Utils.validateFields(calendarioHasta.SelectionStart, "Fecah Hasta") ;
            Hotel hotelSeleccionado = (Hotel)Utils.validateFields(comboBoxHotel.SelectedItem,"Hotel");
            TipoHabitacion tipoHabitacionSeleccionada = (TipoHabitacion)Utils.validateFields(comboBoxTipoHabitacion.SelectedItem, "Tipo Habitacion");
            Regimen regimenSeleccionado = (Regimen) comboBoxRegimen.SelectedItem;
            RepositorioHabitacion repoHabitacion= new RepositorioHabitacion();
            List<HabitacionDisponibleSearchDTO> habitacionesDisponibles= repoHabitacion.getHabitacionesDisponibles(fechaInicio,fechaFin,hotelSeleccionado,tipoHabitacionSeleccionada,regimenSeleccionado);
            habitacionesDisponiblesGrid.DataSource = habitacionesDisponibles;
        }


    }

    
}
