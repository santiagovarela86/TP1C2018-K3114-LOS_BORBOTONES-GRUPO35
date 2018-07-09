﻿using FrbaHotel.Commons;
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
    public partial class RegistrarEstadias : Form
    {
        private Sesion sesion = null;

        public RegistrarEstadias(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }
        private void ListadoRegistrarEstadia_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoRegistrarEstadia_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CHECK IN
            int codReserva = 0;
            DateTime date = Utils.getSystemDatetimeNow();
            int estadoValidez = 0;
            //DateTime dateTest = new DateTime(2017, 1, 1);
            RepositorioReserva repositorioReserva = new RepositorioReserva();
            if (textBox1.Text != "" )
            {
                codReserva = int.Parse(textBox1.Text);
                
                //traigo la fecha veo si es valido, si corresponde al hotel del usuario
                estadoValidez = repositorioReserva.GetReservaValida(codReserva, date, this.sesion.getUsuario());
                if (estadoValidez!=2 && estadoValidez!=3 && estadoValidez!=4 && estadoValidez!=0)
                { 
                    //es valida ya se dio de alta la reserva(con usuario y fecha)
                    //Traigo otra pantalla para los huespedes
                    //MessageBox.Show("La reserva es valida, numero de Estadia: ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Check in realizado exitosamente \nNumero de Estadia: " + estadoValidez, "Gestion de Datos TP 2018 1C - LOS_BORBOTONES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result1 = MessageBox.Show("¿Hay mas huespedes ademas del cliente que reservo?", "Vinculacion huespedes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result1 == System.Windows.Forms.DialogResult.Yes)
                    {    
                    using (VincularHuespedes form = new VincularHuespedes(codReserva))
                      {
                          var result = form.ShowDialog();

                          if (result == DialogResult.OK)
                          {

                          }
                      }
                }
                }
                else if (estadoValidez == 2)
                {
                    MessageBox.Show("No es posible realizar check in sobre la reserva indicada; no está en fecha de realizar check in o ya fue realizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

                }
                else if (estadoValidez == 3)
                {
                    MessageBox.Show("La reserva ingresada no corresponde al hotel al que el usuario tiene permisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (estadoValidez == 4)
                {
                    MessageBox.Show("No se pudo dar de alta la estadia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresar codigo de reserva y username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //CHECK OUT
            int codReserva = 0;
            
            int idEstadia = 0;
            //si se va antes de la fecha de salida tengo que poner bien los dias porque dsp en la factura se hace algo con esto
            DateTime date = Utils.getSystemDatetimeNow();
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioReserva repoReserva = new RepositorioReserva();
            if (textBox1.Text != "")
            {
                codReserva = int.Parse(textBox1.Text);
                //consigo del codigo de reserva el idEstadia
                idEstadia = repoReserva.getIdEstadiaByCodReserva(codReserva);
                if (idEstadia != 0)
                {
                    //veo que este con RCI
                    String estado = "";
                    estado = repoEstadia.getEstado(codReserva);
                    if (estado.Equals("RCI"))
                    {
                        Estadia estadia = new Estadia(idEstadia, this.sesion.getUsuario(), date);
                        repoEstadia.update(estadia);
                        //hago update de EstadoReserva
                        RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();
                        int idEstadoReserva = 0;
                        Reserva reserva = repoReserva.getIdByIdEstadia(estadia.getIdEstadia());
                        String desc = "Reserva Con Egreso";
                        String tipoEstado = "RCE";
                        EstadoReserva estadoReserva = new EstadoReserva(idEstadoReserva, this.sesion.getUsuario(), reserva, tipoEstado, date, desc);
                        repoEstadoReserva.update(estadoReserva);
                        MessageBox.Show("Check out correcto, proceder a facturar Estadia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("La estadia ingresada no esta actualmente en estado 'Reserva con Ingreso'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("La estadia ingresada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Ingrese un numero de reserva válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //llamo a facturar estadia para que sea mas happy path
            /*using (AltaFacturaEstadia form = new AltaFacturaEstadia())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {

                }
            }*/
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
        //ESTO LO PONGO PARA QUE EL NUMERO DE CALLE SOLO PUEDA SER UN NUMERO
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}


