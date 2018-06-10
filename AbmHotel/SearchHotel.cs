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


    }

}
