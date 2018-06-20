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

            RepositorioCategoria repoCategoria = new RepositorioCategoria();
            this.estrellasComboBox.DataSource = repoCategoria.getAll();
        }


        private void button_buscarHoteles(object sender, EventArgs e)
        {
            String nombre =validateStringFields(nombreText.Text);

            int? estrellas = null;
            if (estrellasComboBox.SelectedItem != null) { estrellas = ((Categoria)estrellasComboBox.SelectedItem).getEstrellas(); };
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

        private void modificarButton_Click(object sender, EventArgs e)
        {
            Hotel hotel = (Hotel)registroHoteles.CurrentRow.DataBoundItem;

            using (ModificacionHotel form = new ModificacionHotel(hotel))
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

        private void registroHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null) return;
            if (dgv.CurrentRow.Selected)
            {
                this.modificarButton.Enabled = true;
                this.cierreTemporalButton.Enabled = true;
            }
        }

        private void altaButton_Click(object sender, EventArgs e)
        {
            using (CreateHotel form = new CreateHotel())
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

    }

}
