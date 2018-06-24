using FrbaHotel.Commons;
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

            try
            {
                int idHabitacion = Utils.validateIntField(habitacion.getIdHabitacion().ToString(), "ID Habitacion");
            TipoHabitacion tipoHabitacion = (TipoHabitacion)Utils.validateFields(habitacion.getTipoHabitacion(),"Tipo Habitacion");
            bool activa = this.checkBoxActiva.Checked;
            int numero = Utils.validateIntField(textNumero.Text, "Numero");
            int piso = Utils.validateIntField(textPiso.Text, "Piso");
            String ubicacion =Utils.validateStringFields((String)comboBoxUbicacion.SelectedItem,"Ubicacion");
            Hotel hotel= (Hotel)Utils.validateFields(comboBoxHotel.SelectedItem,"Hotel");

            Habitacion habitacionAModificar = new Habitacion(idHabitacion, tipoHabitacion,
                activa, numero, piso, ubicacion, hotel);

                repoHabitacion.update(habitacionAModificar);
                MessageBox.Show("Habitacion modificada", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
                habitacion = habitacionAModificar;
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
            }
        }
    }
}
