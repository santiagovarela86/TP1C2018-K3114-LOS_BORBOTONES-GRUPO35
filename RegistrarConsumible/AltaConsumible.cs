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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class AltaConsumible : Form
    {
        public AltaConsumible()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AltaConsumible_Load(sender, e);
        }

        private void AltaConsumible_Load(object sender, EventArgs e)
        {
            RepositorioConsumibles repositorioConsumible = new RepositorioConsumibles();
            dataGridView1.DataSource = repositorioConsumible.getAll();
            dataGridView1.ClearSelection();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //valido si es un nuevo consumible o eligio uno ya existente para registrar a cierta estadia
            int codigo = 0;
            String descripcion = "";
            float precio = 0;
            int idEstadia2=0;
            Consumible consumible = null;
            int idConsumible = 0;

            if (textBox5.Text != "")
            {
                idEstadia2 = int.Parse(textBox5.Text);
            }
            if (textBox2.Text != "")
            {
                codigo = int.Parse(textBox2.Text);
            }
            if (textBox4.Text != "")
            {
                precio = float.Parse(textBox4.Text);
            }
            descripcion=textBox3.Text;
            //traigo el consumible elegido (solo dejo traer uno)
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
               consumible = item.DataBoundItem as Consumible;
            }
            RepositorioConsumibles repoConsumible = new RepositorioConsumibles();

            if (descripcion == "" | codigo == 0 | precio == 0)
            {
                //pregunto si estan los otros 2 de usar consumible ya existente o doy warning de datos
                if (idEstadia2 == 0 | consumible == null)
                {
                    //warning ya que algo esta mal en los datos
                    MessageBox.Show("Faltan datos para registrar el consumible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //sumar el consumible elegido a la estadia marcada
                    consumible.setIdEstadia(idEstadia2);
                    //metodo registrar que no crea el consumible solo lo suma
                    idConsumible = repoConsumible.registrar(consumible);
                    if (idConsumible == consumible.getIdConsumible())
                    {
                        MessageBox.Show("Consumible Registrado correctamente en la estadia", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.AltaConsumible_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el consumible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.AltaConsumible_Load(sender, e);
                    }
                }
            }
            else
            {
                //crear nuevo consumible para la estadia marcada
                Consumible nuevoConsumible = new Consumible(idConsumible,codigo,descripcion,precio);
                idConsumible= repoConsumible.create(nuevoConsumible);
                if (idConsumible!=0)
                    {
                        MessageBox.Show("Consumible dado de alta", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.AltaConsumible_Load(sender, e);
                    }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

