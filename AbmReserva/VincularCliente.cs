using FrbaHotel.AbmCliente;
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
    public partial class VincularCliente : Form
    {
        private List<HabitacionDisponibleSearchDTO> habitaciones;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int diasDeEstadia;
        private Usuario usuario;
        public VincularCliente(List<HabitacionDisponibleSearchDTO> habitaciones, DateTime fechaInicio, DateTime fechaFin, int diasDeEstadia, Usuario usuario)
        {
            this.habitaciones = habitaciones;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.diasDeEstadia = diasDeEstadia;
            this.usuario = usuario;
            InitializeComponent();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<Cliente>();


            RepositorioIdentidad repoIdentidad = new RepositorioIdentidad();
            comboBoxTipoDoc.ValueMember = "Value";
            comboBoxTipoDoc.DisplayMember = "Key";
            comboBoxTipoDoc.DataSource = repoIdentidad.getAllTiposDocsClientes();
            comboBoxTipoDoc.SelectedValue = "";
        }

        private void limpiarBusquedaYResultados()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            comboBoxTipoDoc.SelectedValue = "";
            dataGridView1.DataSource = new List<Cliente>();
            this.botonReservar.Enabled = false;


            //ESTO ES PARA QUE ME ACTUALICE LA LISTA DE DOCUMENTOS POSIBLES
            RepositorioIdentidad repoIdentidad = new RepositorioIdentidad();
            comboBoxTipoDoc.DataSource = repoIdentidad.getAllTiposDocsClientes();
            comboBoxTipoDoc.SelectedValue = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.limpiarBusquedaYResultados();
        }

        private void buttonBuscar_click(object sender, EventArgs e)
        {

            String mail = textBox3.Text;
            String nroDoc = textBox4.Text;
            KeyValuePair<String, Boolean> estado = new KeyValuePair<String, Boolean>();
            String tipoDoc = "";
            RepositorioCliente repositorioClientes = new RepositorioCliente();


            if (comboBoxTipoDoc.SelectedItem != null)
            {
                tipoDoc = (String)comboBoxTipoDoc.SelectedItem;
            }

            List<Cliente> clientes = repositorioClientes.getByQuery("", "", tipoDoc, nroDoc, estado, mail);

            //MEJORA DE PERFORMANCE DEL DGV
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = clientes;
            dataGridView1.RowHeadersVisible = true;
            //ESTO LO TENGO QUE HACER PARA QUE NO APAREZCA SIEMPRE SELECCIONADO EL PRIMER ITEM
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            //PONGO ESTO ACA PARA QUE DESPUES DE DAR DE ALTA, MODIFICAR O DAR DE BAJA
            //Y SE VUELVA A CARGAR LA LISTA, NO SE PUEDA MODIFICAR O DAR DE BAJA
            //UN ROL NULL...
            this.botonReservar.Enabled = false;

            //ESTO ES PARA QUE ME ACTUALICE LA LISTA DE DOCUMENTOS POSIBLES
            RepositorioIdentidad repoIdentidad = new RepositorioIdentidad();
            comboBoxTipoDoc.DataSource = repoIdentidad.getAllTiposDocsClientes();
            comboBoxTipoDoc.SelectedValue = "";
        }

        private void buttonAlta_click(object sender, EventArgs e)
        {
            //aca va el alta
            using (AltaCliente form = new AltaCliente())
            {
                var result = form.ShowDialog();

                //AL CERRAR LA VENTANA DESPUES DE DAR DE ALTA UN NUEVO ROL VUELVO A CARGAR LA LISTA
                this.buttonBuscar_click(sender, e);
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null) return;
            if (dgv.CurrentRow.Selected)
            {
                this.botonReservar.Enabled = true;
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarBusquedaYResultados();
        }

        private void botonReservar_Click(object sender, EventArgs e)
        {

            List<Habitacion> habitacionesParaReservar = new List<Habitacion>();
            Regimen regimen=null;
            Cliente cliente = null;
            foreach (HabitacionDisponibleSearchDTO dto in habitaciones) {
                habitacionesParaReservar.Add(dto.getHabitacion());
                regimen = dto.getRegimen();
            }

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                cliente = (item.DataBoundItem as Cliente);
            }

            if (!cliente.getActivo()) {
                MessageBox.Show("El cliente no tiene permitido generar reservas. Seleccione otro cliente para confirmar su reserva por favor", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
                return;
            }
            RepositorioReserva repoReserva = new RepositorioReserva();
            Reserva reserva = new Reserva(habitacionesParaReservar, regimen, cliente, fechaInicio, fechaFin, diasDeEstadia,usuario);
            try
            {
                repoReserva.create(reserva);
                MessageBox.Show("Reserva creada exitosamente \n Codigo de reserva: " + reserva.getCodigoReserva(), "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");

            }
        }

       

       
    }
}
