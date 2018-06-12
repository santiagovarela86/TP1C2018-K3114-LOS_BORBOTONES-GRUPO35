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
    public partial class CrearHabitacion : Form
    {
        public CrearHabitacion()
        {
            InitializeComponent();
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            RepositorioTipoHabitacion repositorioTipoHab = new RepositorioTipoHabitacion();

            comboBoxHotel.DataSource = repositorioHotel.getAll();
            comboBoxHotel.DisplayMember = "Nombre";


            comboBoxTipoHabitacion.DataSource = repositorioTipoHab.getAll();
            comboBoxTipoHabitacion.DisplayMember = "Descripcion";

            comboBoxUbicacion.DataSource = new[] { "Vista al exterior", "Interior" };


            checkBoxActiva.Checked = false;
        }

        private void buttonCrearHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = Int32.Parse(validateStringFields(textNumero.Text, "Numero"));
                int piso =  Int32.Parse(validateStringFields(textPiso.Text, "Piso"));
                Hotel hotel = (Hotel)validateFields(comboBoxHotel.SelectedItem, "Hotel");
                String ubicacion = (String)validateFields(comboBoxUbicacion.SelectedItem, "Ubicacion");
                TipoHabitacion tipoHabitacion = (TipoHabitacion)validateFields(comboBoxTipoHabitacion.SelectedItem, "Tipo");
                String descripcion = (String)validateStringFields(textDescripcion.Text, "Descripcion");
                RepositorioHabitacion repositorioHabitacion = new RepositorioHabitacion();
                bool activa= checkBoxActiva.Checked;
                Habitacion habitacion = new Habitacion(0, tipoHabitacion, activa, numero, piso, ubicacion, hotel);
                repositorioHabitacion.create(habitacion);
                MessageBox.Show("Habitacion creada", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");

            }
            catch (RequestInvalidoException exception)
            {
                MessageBox.Show(exception.Message,"Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
            }
        }

      
        private Object validateFields(Object field,String fieldName){
            if (field == null)
            {
                throw new RequestInvalidoException(fieldName + "no puede ser nulo");
            }
            return field;
        }

        private String validateStringFields(String field, String fieldName)
        {
            if (field == null)
            {
                throw new RequestInvalidoException(fieldName + "no puede ser nulo");
            }
            return field;
        }

     
    }
}
