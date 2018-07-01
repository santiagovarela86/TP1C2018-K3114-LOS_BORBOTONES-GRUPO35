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
        Usuario usuario;

      
        public GenerarReserva(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            init();
        }


        private void limpiarFiltros() {
            calendarioDesde.Value = DateTime.Now.Date;
            calendarioHasta.Value = DateTime.Now.Date.AddDays(1);
           
            init();
            limpiarGrids();


            this.reservarHabitacionButton.Enabled = false;

        }

        private void limpiarGrids() {
            this.regimenesDisponiblesGrid.DataSource = null;
            this.regimenesDisponiblesGrid.Rows.Clear();

            this.habitacionesDisponiblesGrid.DataSource = null;
            this.habitacionesDisponiblesGrid.Rows.Clear();
        }

        private void init()
        {
            calendarioDesde.Value = DateTime.Now.Date;
            calendarioHasta.Value = DateTime.Now.Date.AddDays(1);
            RepositorioTipoHabitacion repoTipoHabitacion = new RepositorioTipoHabitacion();
            RepositorioHotel repoHotel = new RepositorioHotel();

            comboBoxTipoHabitacion.DisplayMember = "Descripcion";
            comboBoxTipoHabitacion.ValueMember = "Descripcion";
            comboBoxTipoHabitacion.DataSource = repoTipoHabitacion.getAll();

            comboBoxHotel.DisplayMember = "Nombre";
            comboBoxHotel.ValueMember = "Nombre";
            comboBoxHotel.DataSource = repoHotel.getAll();

            comboBoxTipoHabitacion.SelectedValue = "";
            comboBoxTipoHabitacion.SelectedIndex = -1;
        }

        private void eventHandlerHotelComboBox(object sender, EventArgs e)
        {

            this.regimenesDisponiblesGrid.DataSource = null;
            this.regimenesDisponiblesGrid.Rows.Clear();

            this.habitacionesDisponiblesGrid.DataSource = null;
            this.habitacionesDisponiblesGrid.Rows.Clear();

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


        private void buscarHabitaciones(Regimen regimenParam)
        {
            this.reservarHabitacionButton.Enabled = false;

            DateTime fechaInicio = (DateTime)Utils.validateFields(calendarioDesde.Value, "Fecha Desde");
            DateTime fechaFin = (DateTime)Utils.validateFields(calendarioHasta.Value, "Fecah Hasta");
            if(Utils.validateTimeRanges(fechaInicio, fechaFin)){
            
            Hotel hotelSeleccionado = (Hotel)Utils.validateFields(comboBoxHotel.SelectedItem, "Hotel");
            TipoHabitacion tipoHabitacionSeleccionada = null;
            if (comboBoxTipoHabitacion.SelectedItem != null)
            {
                 tipoHabitacionSeleccionada = (TipoHabitacion)comboBoxTipoHabitacion.SelectedItem;
            }
                Regimen regimenSeleccionado = null;

                regimenSeleccionado = (Regimen)comboBoxRegimen.SelectedItem;

                regimenSeleccionado = regimenParam;
          
            RepositorioHabitacion repoHabitacion = new RepositorioHabitacion();
            List<HabitacionDisponibleSearchDTO> habitacionesDisponibles = repoHabitacion.getHabitacionesDisponibles(fechaInicio, fechaFin, hotelSeleccionado, tipoHabitacionSeleccionada, regimenSeleccionado);



            this.habitacionesDisponiblesGrid.DataSource = habitacionesDisponibles;
            this.habitacionesDisponiblesGrid.CurrentCell = null;
            this.habitacionesDisponiblesGrid.ClearSelection();
            if (this.habitacionesDisponiblesGrid.Rows.Count > 0)
            {
                this.habitacionesDisponiblesGrid.Rows[0].Cells[0].Selected = false;
                this.habitacionesDisponiblesGrid.Rows[0].Selected = false;
            }

            RepositorioRegimen repoRegimen = new RepositorioRegimen();

            this.regimenesDisponiblesGrid.DataSource = repoRegimen.getByIdHotel(hotelSeleccionado.getIdHotel());
          
          

            if (regimenSeleccionado == null)
            {
                limpiarRegimenesDataGrid();

            }
            else
            {
                limpiarRegimenesDataGrid();
                foreach (DataGridViewRow item in this.regimenesDisponiblesGrid.Rows)
                {
                    Regimen regimen = item.DataBoundItem as Regimen;
                    if (regimen.getIdRegimen() == regimenSeleccionado.getIdRegimen())
                    {
                        item.Selected = true;

                    }
                }
            }
            }
        }

        private void limpiarRegimenesDataGrid()
        {
            this.regimenesDisponiblesGrid.Enabled = true;
            this.regimenesDisponiblesGrid.CurrentCell = null;
            this.regimenesDisponiblesGrid.ClearSelection();
            if (this.regimenesDisponiblesGrid.Rows.Count > 0)
            {
                this.regimenesDisponiblesGrid.Rows[0].Cells[0].Selected = false;
                this.regimenesDisponiblesGrid.Rows[0].Selected = false;
            }
        }
        private void buscarHabitaciones_Click(object sender, EventArgs e)
        {
            this.buscarHabitaciones((Regimen)comboBoxRegimen.SelectedItem);

        }

        private void habitaciones_cellClick(object sender, EventArgs e)
        {
            Regimen regimen = null;
            foreach (DataGridViewRow item in this.regimenesDisponiblesGrid.SelectedRows)
            {
                regimen = item.DataBoundItem as Regimen;
            }
            if (regimen != null)
            {
                this.reservarHabitacionButton.Enabled = true;
            }
        }

        private void reservarHabitacion(object sender, EventArgs e)
        {

            DateTime fechaInicio = calendarioDesde.Value;
            DateTime fechaFin = calendarioHasta.Value;
            List<HabitacionDisponibleSearchDTO> habitacionesAReservar = new List<HabitacionDisponibleSearchDTO>();

            foreach (DataGridViewRow item in this.habitacionesDisponiblesGrid.SelectedRows)
            {
                habitacionesAReservar.Add(item.DataBoundItem as HabitacionDisponibleSearchDTO);
            }

            using (ConfirmarReservaWindow form = new ConfirmarReservaWindow(habitacionesAReservar, fechaInicio, fechaFin,usuario))
            {
                var result = form.ShowDialog();
                this.buscarHabitaciones((Regimen)comboBoxRegimen.SelectedItem);
            }
        }

        private void regimenesDisponiblesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Regimen regimenSelected = null;
            foreach (DataGridViewRow item in this.regimenesDisponiblesGrid.SelectedRows)
            {
                regimenSelected = item.DataBoundItem as Regimen;
            }


            this.buscarHabitaciones(regimenSelected);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void habitaciones_cellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }


   

    
}
