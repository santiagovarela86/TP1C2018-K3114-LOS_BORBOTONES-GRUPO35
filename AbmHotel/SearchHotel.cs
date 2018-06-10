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
            String nombre = nombreText.Text;
            int estrellas = (int)estrellasComboBox.SelectedItem;
            String pais = paisText.Text;
            String ciudad = ciudadText.Text;
            RepositorioHotel repositorioHotel = new RepositorioHotel();

            List<Hotel> hoteles= repositorioHotel.getByQuery(nombre, estrellas, ciudad, pais);
        }



    }

}
