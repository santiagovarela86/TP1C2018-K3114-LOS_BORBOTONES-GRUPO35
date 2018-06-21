﻿using FrbaHotel.Modelo;
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

namespace FrbaHotel.AbmCliente
{
    public partial class ABMClientes : Form
    {
        public ABMClientes()
        {
            InitializeComponent();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<Cliente>();
            List<KeyValuePair<String, Boolean>> estados = new List<KeyValuePair<String, Boolean>>();
            estados.Add(new KeyValuePair<String, Boolean>("Habilitado", true));
            estados.Add(new KeyValuePair<String, Boolean>("Inhabilitado", false));
            comboBoxEstados.ValueMember = "Value";
            comboBoxEstados.DisplayMember = "Key";
            comboBoxEstados.DataSource = estados;
            comboBoxEstados.SelectedValue = "";

            RepositorioIdentidad repoIdentidad = new RepositorioIdentidad();
            comboBoxTipoDoc.ValueMember = "Value";
            comboBoxTipoDoc.DisplayMember = "Key";
            comboBoxTipoDoc.DataSource = repoIdentidad.getAllTiposDocsClientes();
            comboBoxTipoDoc.SelectedValue = "";
        }

        private void limpiarBusquedaYResultados()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBoxEstados.SelectedValue = "";
            comboBoxTipoDoc.SelectedValue = "";
            dataGridView1.DataSource = new List<Cliente>();
            this.button4.Enabled = false;
            this.button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.limpiarBusquedaYResultados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nombre = textBox1.Text;
            String apellido = textBox2.Text;
            String mail = textBox3.Text;
            String nroDoc = textBox4.Text;
            KeyValuePair<String, Boolean> estado = new KeyValuePair<String, Boolean>();
            String tipoDoc = "";
            RepositorioCliente repositorioClientes = new RepositorioCliente();

            if (comboBoxEstados.SelectedItem != null)
            {
                estado = (KeyValuePair<String, Boolean>)comboBoxEstados.SelectedItem;
            }

            if (comboBoxTipoDoc.SelectedItem != null)
            {
                tipoDoc = (String)comboBoxTipoDoc.SelectedItem;
            }

            List<Cliente> clientes = repositorioClientes.getByQuery(nombre,apellido,tipoDoc,nroDoc,estado,mail);

            //MEJORA DE PERFORMANCE DEL DGV
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = clientes;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //aca va el alta
            using (AltaCliente form = new AltaCliente())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //string val = form.ReturnValue1;            //values preserved after close
                    //string dateString = form.ReturnValue2;
                    //Do something here with these values

                    //for example
                    //this.txtSomething.Text = val;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //aca va la modificacion
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //aca va la baja
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
                this.button4.Enabled = true;
                this.button5.Enabled = true;
            }
        }
    }
}
