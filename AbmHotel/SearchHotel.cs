using System;

using System.Windows.Forms;
using System.Drawing;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Modelo;

namespace FrbaHotel.AbmHotel
{
    public partial class SearchHotel : Form

    {

        public SearchHotel()
        {
            InitializeComponent();
            estrellasComboBox.Items.Add(1);
            estrellasComboBox.Items.Add(2);
            estrellasComboBox.Items.Add(3);
            estrellasComboBox.Items.Add(4);
            estrellasComboBox.Items.Add(5);
        }


        private void button_buscarHoteles(object sender, EventArgs e)
        {
            String nombre =validateStringFields(nombreText.Text);

            int? estrellas = null;
            if (estrellasComboBox.SelectedItem != null) { estrellas = (int)estrellasComboBox.SelectedItem; };
            String pais = validateStringFields(paisText.Text);
            String ciudad = validateStringFields(ciudadText.Text);
            RepositorioHotel repositorioHotel = new RepositorioHotel();

            List<Hotel> hoteles= repositorioHotel.getByQuery(nombre, estrellas, ciudad, pais);
            registroHoteles.DataSource = hoteles;
        }

        private String validateStringFields(String field)
        {
            return field == "" ? null : field;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.limpiarBusquedaYResultados();
        }

        private void limpiarBusquedaYResultados()
        {
            registroHoteles.DataSource = new List<Hotel>();
            nombreText.Text = "";
            paisText.Text = "";
            ciudadText.Text = "";
            estrellasComboBox.SelectedValue = "";
            estrellasComboBox.SelectedIndex = -1;
            this.modificarButton.Enabled = false;
            this.cierreTemporalButton.Enabled = false;
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

        private void registroHoteles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null) return;
            if (dgv.CurrentRow.Selected)
            {
                this.modificarButton.Enabled = true;
                this.cierreTemporalButton.Enabled = true;
            }
        }

    }

}
