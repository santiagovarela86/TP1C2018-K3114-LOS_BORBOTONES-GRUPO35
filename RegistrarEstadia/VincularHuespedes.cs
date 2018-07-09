﻿using FrbaHotel.AbmCliente;
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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class VincularHuespedes : Form
    {
        List<Cliente> clientesElegidos =new List<Cliente>() ;
        private int codReserva = 0;

        public VincularHuespedes(int reserva)
        {
            InitializeComponent();
            this.codReserva = reserva;
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<Cliente>();
            dataGridView2.DataSource = new List<Cliente>();

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
            //this.botonReservar.Enabled = false;


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
                dataGridView2.DataSource = new List<Cliente>();    
                //la agrego al datagrid 2
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    clientesElegidos.Add(item.DataBoundItem as Cliente);
                }
                //MEJORA DE PERFORMANCE DEL DGV
                dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.DataSource = clientesElegidos;
                dataGridView2.RowHeadersVisible = true;
                //ESTO LO TENGO QUE HACER PARA QUE NO APAREZCA SIEMPRE SELECCIONADO EL PRIMER ITEM
                dataGridView2.CurrentCell = null;
                dataGridView2.ClearSelection();
                //vuelvo a cargar la lista
                this.buttonBuscar_click(sender, e);
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarBusquedaYResultados();
        }

        private void botonReservar_Click(object sender, EventArgs e)
        {

            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            
            try
            {
                repoEstadia.vincularHuespedes(codReserva, clientesElegidos);
                //MessageBox.Show("Check in realizado exitosamente \n Codigo de reserva: " + codReserva, "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");
                MessageBox.Show("Huespedes vinculados correctamente a la reserva. ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Gestion de Datos TP 2018 1C - LOS_BORBOTONES", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
