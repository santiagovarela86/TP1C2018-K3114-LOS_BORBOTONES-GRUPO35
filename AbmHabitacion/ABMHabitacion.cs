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

            List<Hotel> hoteles= new List<Hotel>();
            hoteles.Add(new Hotel());
            hoteles.AddRange(repositorioHotel.getAll());
            comboBoxHotel.DataSource = hoteles;
            comboBoxHotel.SelectedIndex = -1;
            comboBoxHotel.DisplayMember = "Nombre";

            List<TipoHabitacion> tipoHabitaciones = new List<TipoHabitacion>();
            tipoHabitaciones.Add(new TipoHabitacion());
            tipoHabitaciones.AddRange(repositorioTipoHab.getAll());

            comboBoxTipoHabitacion.DataSource = tipoHabitaciones;
            comboBoxTipoHabitacion.DisplayMember = "Descripcion";
            comboBoxUbicacion.DataSource = new[] { "","Vista al exterior", "Interior" };
            

            checkBoxActiva.Checked = false;
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

            using (BajaHabitacion bajaHabitacion = new BajaHabitacion())
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
            String ubicacion = (String)validateStringFields((String)comboBoxUbicacion.SelectedItem);
            TipoHabitacion tipoHabitacion = (TipoHabitacion)comboBoxTipoHabitacion.SelectedItem;
            RepositorioHabitacion repositorioHabitacion = new RepositorioHabitacion();
            bool activa = checkBoxActiva.Checked;
            registroHabitaciones.DataSource= repositorioHabitacion.getByQuery(numero, piso, hotel, ubicacion, tipoHabitacion, activa);
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
       

    }
}
