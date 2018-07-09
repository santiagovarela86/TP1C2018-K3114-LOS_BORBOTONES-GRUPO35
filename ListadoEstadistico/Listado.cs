﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ListadoEstadistico
{
    public partial class Listado : Form
    {
        SqlDataAdapter sAdapter;
        DataTable dTable;
        public Listado()
        {
            InitializeComponent();
            trimestre.Items.Add("1");
            trimestre.Items.Add("2");
            trimestre.Items.Add("3");
            trimestre.Items.Add("4");

            int i = 0;
            for (i = 2009; i <= 2018; i++)
                anio.Items.Add(i);

            tipoListado.Items.Insert(0, "Hotel con mas reservas canceladas");
            tipoListado.Items.Insert(1, "Hotel con mas consumibles  facturados");
            tipoListado.Items.Insert(2, "Hotel con mas dias fuera de servicio");
            tipoListado.Items.Insert(3, "Cliente con mas puntos");
            tipoListado.Items.Insert(4, "Habitaciones mas ocupadas");

        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(anio.Text))
            {
                MessageBox.Show("Debe seleccionar un año.", "Listado estadistico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(trimestre.Text))
            {
                MessageBox.Show("Debe seleccionar un trimestre.", "Listado estadistico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tipoListado.Text))
            {
                MessageBox.Show("Debe seleccionar el tipo de listado.","Listado estadistico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String tipoSeleccionado = "";
            switch (tipoListado.SelectedIndex)
            {
                case 0:
                    tipoSeleccionado = "EXEC LOS_BORBOTONES.lista_hoteles_maxResCancel " + trimestre.Text + ", " + anio.Text;
                    break;
                case 1:
                    tipoSeleccionado = "EXEC LOS_BORBOTONES.lista_hoteles_maxConFacturados " + trimestre.Text + ", " + anio.Text;
                    break;
                case 2:
                    tipoSeleccionado = "EXEC LOS_BORBOTONES.lista_Hotel_DiasFueraServ " + trimestre.Text + ", " + anio.Text;
                    break;
                case 3:
                    tipoSeleccionado = "EXEC LOS_BORBOTONES.listaMaximosPuntajes " + (trimestre.Text) + ", " + anio.Text;
                    break;
                case 4:
                    tipoSeleccionado = "EXEC LOS_BORBOTONES.listaHabitacionesVecesOcupada " + (trimestre.Text) + "," + anio.Text;
                    break;
            }

            sAdapter = FrbaHotel.HomeListado.Base.dameDataAdapter(tipoSeleccionado);
            dTable = FrbaHotel.HomeListado.Base.dameDataTable(sAdapter);
           
            BindingSource bSource = new BindingSource();
          
            bSource.DataSource = dTable;
          
            dataGridView1.DataSource = bSource;
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            this.trimestre.SelectedValue = "";
            this.trimestre.SelectedIndex = -1;
            this.anio.SelectedValue = "";
            this.anio.SelectedIndex = -1;
            this.tipoListado.SelectedValue = "";
            this.tipoListado.SelectedIndex = -1;
        }
    }
}