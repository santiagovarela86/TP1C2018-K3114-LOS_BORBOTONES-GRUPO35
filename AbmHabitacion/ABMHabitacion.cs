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
    public partial class ABMHabitacion : Form
    {
        public ABMHabitacion()
        {
            InitializeComponent();

            RepositorioHotel repositorioHotel = new RepositorioHotel();
            RepositorioTipoHabitacion repositorioTipoHab = new RepositorioTipoHabitacion();


            comboBoxHotel.DataSource = repositorioHotel.getAll();
            comboBoxHotel.SelectedIndex = -1;
            comboBoxHotel.ValueMember = "Nombre";


            comboBoxTipoHabitacion.DataSource = repositorioTipoHab.getAll();
            comboBoxTipoHabitacion.ValueMember = "Descripcion";            

            limpiarBusquedaYResultados();
        }

        private void buttonCrearHabitacion_Click(object sender, EventArgs e)
        {
            using (CrearHabitacion crearHabitacion = new CrearHabitacion())
            {
                var resultFormCrearHabitacion = crearHabitacion.ShowDialog();

                if (resultFormCrearHabitacion == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        private void buttonBajaHabitacion_Click(object sender, EventArgs e)
        {
            Habitacion habitacion = (Habitacion)registroHabitaciones.CurrentRow.DataBoundItem;
            using (BajaHabitacion bajaHabitacion = new BajaHabitacion(habitacion))
            {
                var resultFormBajaHabitacion = bajaHabitacion.ShowDialog();

                if (resultFormBajaHabitacion == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        private void buttonBbuscarHoteles_Click(object sender, EventArgs e)
        {
            String numero = validateStringFields(textNumero.Text);
            String piso = validateStringFields(textPiso.Text);
            Hotel hotel = (Hotel)comboBoxHotel.SelectedItem;
            TipoHabitacion tipoHabitacion = (TipoHabitacion)comboBoxTipoHabitacion.SelectedItem;
            RepositorioHabitacion repositorioHabitacion = new RepositorioHabitacion();
            bool activa = checkBoxActiva.Checked;
            registroHabitaciones.DataSource= repositorioHabitacion.getByQuery(numero, piso, hotel, tipoHabitacion, activa);
        }

        private String validateStringFields(String field)
        {
            return field == "" ? null : field;
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

        private void registroHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;

            if (dgv == null) return;
            if (dgv.CurrentRow.Selected)
            {
                this.buttonModificarHabitacion.Enabled = true;
                this.buttonBajaHabitacion.Enabled = true;
            }
        }

        private void buttonModificarHabitacion_Click(object sender, EventArgs e)
        {
            Habitacion habitacion = (Habitacion)registroHabitaciones.CurrentRow.DataBoundItem;
            using (ModificarHabitacion modificarHabitacion = new ModificarHabitacion(habitacion))
            {
                var resultFormModificarHabitacion = modificarHabitacion.ShowDialog();

                if (resultFormModificarHabitacion == DialogResult.OK)
                {
                    //Hago algo con el return value
                }
            }
        }

        private void limpiarBusquedaYResultados(object sender, EventArgs e) {
            this.limpiarBusquedaYResultados();
        }
        private void limpiarBusquedaYResultados()
        {
            registroHabitaciones.DataSource = new List<Habitacion>();
            textNumero.Text = "";
            textPiso.Text = "";
            comboBoxTipoHabitacion.SelectedValue = "";
            comboBoxTipoHabitacion.SelectedIndex = -1;
            checkBoxActiva.Checked = false;

            comboBoxHotel.SelectedValue = "";
            comboBoxHotel.SelectedIndex = -1;
        }

        
    }

}
