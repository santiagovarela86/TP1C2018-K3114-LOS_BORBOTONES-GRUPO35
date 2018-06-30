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
using FrbaHotel.Excepciones;

namespace FrbaHotel.AbmCliente
{
    public partial class ModificacionCliente : Form
    {
        Cliente cliente = null;

        public ModificacionCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void resetearDatos()
        {
            List<String> tipoDoc = new List<String>();
            tipoDoc.Add("DNI");
            tipoDoc.Add("CUIT");
            tipoDoc.Add("LE");
            tipoDoc.Add("LC");
            tipoDoc.Add("Pasaporte");

            comboBoxTipoDoc.ValueMember = "Value";
            comboBoxTipoDoc.DisplayMember = "Key";
            comboBoxTipoDoc.DataSource = tipoDoc;
                        
            //obtengo todos los campos a mostrar
            textBoxNacionalidad.Text = cliente.getIdentidad().getNacionalidad();
            textBoxNombre.Text = cliente.getIdentidad().getNombre();
            textBoxApellido.Text = cliente.getIdentidad().getApellido();
            textBoxNroDoc.Text = cliente.getIdentidad().getNumeroDocumento();
            textBoxMail.Text = cliente.getIdentidad().getMail();
            textBoxTelefono.Text = cliente.getIdentidad().getTelefono();
            textBoxCalle.Text = cliente.getIdentidad().getDireccion().getCalle();
            textBoxLocalidad.Text = cliente.getIdentidad().getDireccion().getCiudad();
            textBoxPaisOrigen.Text = cliente.getIdentidad().getDireccion().getPais();
            textBoxNroCalle.Text = cliente.getIdentidad().getDireccion().getNumeroCalle().ToString(); ;
            textBoxPiso.Text = cliente.getIdentidad().getDireccion().getPiso().ToString();
            textBoxDepto.Text = cliente.getIdentidad().getDireccion().getDepartamento();

            comboBoxTipoDoc.SelectedIndex = comboBoxTipoDoc.FindStringExact(cliente.getIdentidad().getTipoDocumento());
            dateTime.Value = cliente.getIdentidad().getFechaNacimiento();
            checkBoxActivo.Checked = cliente.getActivo();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.resetearDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR EL CLIENTE
            RepositorioCliente repoCliente = new RepositorioCliente();

            //ESTOS VALORES SON LOS QUE CAMBIAN
            //STRINGS
            String nombre = textBoxNombre.Text;
            String apellido = textBoxApellido.Text;
            String nroDoc = textBoxNroDoc.Text;
            String mail = textBoxMail.Text;
            String telefono = textBoxTelefono.Text;
            String calle = textBoxCalle.Text;
            String localidad = textBoxLocalidad.Text;
            String pais = textBoxPaisOrigen.Text;
            String nacionalidad = textBoxNacionalidad.Text;
            String depto = textBoxDepto.Text;

            //NUMEROS
            int nroCalle = 0;
            if (textBoxNroCalle.Text != "") { nroCalle = int.Parse(textBoxNroCalle.Text); }
            int nroPiso = 0;
            if (textBoxPiso.Text != "") { nroPiso = int.Parse(textBoxPiso.Text); }

            //OTROS
            String tipoDoc = "";
            if (comboBoxTipoDoc.SelectedItem != null) { tipoDoc = (String)comboBoxTipoDoc.SelectedItem; }
            Boolean activo = checkBoxActivo.Checked;
            DateTime fechaNacimiento = dateTime.Value;

            //VALORES QUE NO CAMBIAN
            String tipoIdentidad = "Cliente";
            int idDir = this.cliente.getIdentidad().getDireccion().getIdDireccion();
            int idIdentidad = this.cliente.getIdentidad().getIdIdentidad();
            int idCliente = this.cliente.getIdCliente();
            List<Reserva> reservas = this.cliente.getReservas();

            Direccion adress = new Direccion(idDir, pais, localidad, calle, nroCalle, nroPiso, depto);
            Identidad identidad = new Identidad(idIdentidad, tipoIdentidad, nombre, apellido, tipoDoc, nroDoc, mail, fechaNacimiento, nacionalidad, telefono, adress);
            Cliente updatedClient = new Cliente(idCliente, identidad, activo, reservas);            

            if (this.validoInput(this))
            {
                try
                {
                    repoCliente.update(updatedClient);
                    MessageBox.Show("Cliente actualizado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //ME TRAIGO EL USUARIO ACTUALIZADO
                    this.cliente = repoCliente.getById(cliente.getIdCliente());
                    this.resetearDatos();
                }
                catch (NoExisteIDException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifique haber ingresado todos los datos necesarios para actualizar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean validoInput(ModificacionCliente form)
        {
            return !form.textBoxNombre.Text.Equals("") &&
                   !form.textBoxApellido.Text.Equals("") &&
                   !form.textBoxNroDoc.Text.Equals("") &&
                   !form.textBoxMail.Text.Equals("") &&
                   !form.textBoxTelefono.Text.Equals("") &&
                   !form.textBoxCalle.Text.Equals("") &&
                   !form.textBoxNroCalle.Text.Equals("") &&
                   !form.textBoxPiso.Text.Equals("") &&
                   //!form.textBoxDepto.Text.Equals("") && //DEPTO PUEDE ESTAR VACIO (?)
                   !form.textBoxLocalidad.Text.Equals("") &&
                   !form.textBoxPaisOrigen.Text.Equals("") &&
                   !form.textBoxNacionalidad.Text.Equals("") &&
                   form.comboBoxTipoDoc.SelectedValue != null;
        }

        private void ModificacionCliente_Load(object sender, EventArgs e)
        {
            this.resetearDatos();
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

        //ESTO LO PONGO PARA QUE EL NUMERO DE CALLE SOLO PUEDA SER UN NUMERO
        private void textBoxNroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ESTO LO PONGO PARA QUE EL PISO DEL DEPTO SOLO PUEDA SER UN NUMERO
        private void textBoxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ESTO LO PONGO PARA QUE EL DOCUMENTO SOLO PUEDA TENER NUMEROS
        private void textBoxNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ESTO LO PONGO PARA QUE EL TELEFONO SOLO PUEDA TENER NUMEROS
        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

