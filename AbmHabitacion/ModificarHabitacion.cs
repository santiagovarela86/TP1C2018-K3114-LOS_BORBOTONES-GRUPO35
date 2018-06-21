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

namespace FrbaHotel.AbmHabitacion
{
    public partial class ModificarHabitacion : Form
    {
        private Habitacion habitacion;
        public ModificarHabitacion(Habitacion habitacion)
        {


            this.habitacion = habitacion;
            InitializeComponent();

            RepositorioHotel repositorioHotel = new RepositorioHotel();

            comboBoxHotel.DataSource = repositorioHotel.getAll();
            comboBoxHotel.DisplayMember = "Nombre";
            comboBoxHotel.ValueMember = "Nombre";

            comboBoxUbicacion.DataSource = new[] { "Vista al exterior", "Interior" };
            initFields();
        }

        private void initFields()
        {
            this.textNumero.Text = habitacion.getNumero().ToString();
            this.checkBoxActiva.Checked = habitacion.getActiva();
            this.textPiso.Text = habitacion.getPiso().ToString();
            this.comboBoxUbicacion.SelectedItem = habitacion.getUbicacion();
            this.comboBoxHotel.SelectedValue = habitacion.getHotel().getNombre();
        }

        private void buttonModificarHabitacion_Click(object sender, EventArgs e)
        {
            RepositorioHabitacion repoHabitacion = new RepositorioHabitacion();

            Habitacion habitacionAModificar= new Habitacion(habitacion.getIdHabitacion(),habitacion.getTipoHabitacion(),this.checkBoxActiva.Checked,Int32.Parse(textNumero.Text),Int32.Parse(textPiso.Text),(String)comboBoxUbicacion.SelectedItem,(Hotel)comboBoxHotel.SelectedItem);

            try
            {
                repoHabitacion.update(habitacionAModificar);
                MessageBox.Show("Habitacion modificada", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");

            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
            }
        }
    }
}
