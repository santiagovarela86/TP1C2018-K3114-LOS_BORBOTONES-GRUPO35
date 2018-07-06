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
        private Sesion sesion = null;

        public SearchHotel(Sesion sesion)
        {
            InitializeComponent();

            this.sesion = sesion;
            RepositorioCategoria repoCategoria = new RepositorioCategoria();
            this.estrellasComboBox.DataSource = repoCategoria.getAll();
            this.estrellasComboBox.ValueMember = "Estrellas";
            limpiarBusquedaYResultados();
        }

        private void button_buscarHoteles(object sender, EventArgs e)
        {
            buscarHoteles();
        }

        private void buscarHoteles() {
            String nombre = validateStringFields(nombreText.Text);
            int? estrellas = null;
            if (estrellasComboBox.SelectedItem != null) { estrellas = ((Categoria)estrellasComboBox.SelectedItem).getEstrellas(); };
            String pais = validateStringFields(paisText.Text);
            String ciudad = validateStringFields(ciudadText.Text);
            RepositorioHotel repositorioHotel = new RepositorioHotel();

            this.modificarButton.Enabled = false;

            List<Hotel> hoteles = repositorioHotel.getByQuery(nombre, estrellas, ciudad, pais);
            registroHoteles.DataSource = hoteles;

            //ESTO LO TENGO QUE HACER PARA QUE NO APAREZCA SIEMPRE SELECCIONADO EL PRIMER ITEM
            registroHoteles.CurrentCell = null;
            registroHoteles.ClearSelection();
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
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            Hotel hotelAModificar = (Hotel) registroHoteles.CurrentRow.DataBoundItem;

            //SI EL USUARIO TRABAJA EN EL HOTEL SELECCIONADO PARA TRABAJAR
            if (this.sesion.getUsuario().getHoteles().Exists(hotel => hotel.getIdHotel().Equals(hotelAModificar.getIdHotel())))
            {
                using (ModificacionHotel form = new ModificacionHotel(hotelAModificar))
                {
                    var result = form.ShowDialog();
                    this.buscarHoteles();
                }
            }
            else
            {
                MessageBox.Show("Usuario sin permisos para modificar el Hotel seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void altaButton_Click(object sender, EventArgs e)
        {
            using (CreateHotel form = new CreateHotel())
            {
                var result = form.ShowDialog();
                this.buscarHoteles();
            }
        }

    }

}
