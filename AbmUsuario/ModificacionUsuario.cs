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
using FrbaHotel.Excepciones;

namespace FrbaHotel.AbmUsuario
{
    public partial class ModificacionUsuario : Form
    {
        //USUARIO A MODIFICAR
        Usuario usuario = null;
        String password = "";
        Boolean passwordChanged = false;

        public ModificacionUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.resetearDatos();
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

            dateTime.ResetText();
            passwordChanged = false;

            //seteo la info
            textBox1.Text = usuario.getUsername();
            textBox3.Text = usuario.getIdentidad().getNombre();
            textBox4.Text = usuario.getIdentidad().getApellido();
            textBox5.Text = usuario.getIdentidad().getNumeroDocumento();
            textBox6.Text = usuario.getIdentidad().getMail();
            textBox7.Text = usuario.getIdentidad().getTelefono();
            textBox8.Text = usuario.getIdentidad().getDireccion().getCalle();
            textBox12.Text = usuario.getIdentidad().getDireccion().getNumeroCalle().ToString();
            textBox13.Text = usuario.getIdentidad().getDireccion().getPiso().ToString();
            textBox14.Text = usuario.getIdentidad().getDireccion().getDepartamento();
            textBox15.Text = usuario.getIdentidad().getDireccion().getCiudad();
            textBox16.Text = usuario.getIdentidad().getDireccion().getPais();
            textBox17.Text = usuario.getIdentidad().getNacionalidad();
            dateTime.Value = usuario.getIdentidad().getFechaNacimiento();
            comboBoxTipoDoc.SelectedIndex = comboBoxTipoDoc.FindStringExact(usuario.getIdentidad().getTipoDocumento());
            checkBox1.Checked = usuario.getActivo();

            //cargo todos los roles
            RepositorioRol repositorioRol = new RepositorioRol();
            dataGridView1.DataSource = repositorioRol.getAll();
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            //cargo todos los hoteles
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            dataGridView2.DataSource = repositorioHotel.getAll();
            dataGridView2.CurrentCell = null;
            dataGridView2.ClearSelection();

            //MARCO LOS ROLES QUE TIENE EL USUARIO
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Rol rol = (Rol)row.DataBoundItem;
                if (usuario.getRoles().Exists(r => r.getIdRol().Equals(rol.getIdRol())))
                {
                    dataGridView1.Rows[row.Index].Selected = true;
                    dataGridView1.Rows[row.Index].Cells[0].Selected = true;
                }
            }

            //MARCO LOS HOTELES EN LOS QUE TRABAJA EL USUARIO
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Hotel hotel = (Hotel)row.DataBoundItem;
                //if (rol.getFuncionalidades().Exists(f => f.getDescripcion().Equals(funcionalidad.getDescripcion())))
                if (usuario.getHoteles().Exists(h => h.getIdHotel().Equals(hotel.getIdHotel())))
                {
                    dataGridView2.Rows[row.Index].Selected = true;
                    dataGridView2.Rows[row.Index].Cells[0].Selected = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR EL USUARIO
            RepositorioUsuario repoUser = new RepositorioUsuario();

            //ESTOS VALORES SON LOS QUE CAMBIAN
            //STRINGS
            String username = textBox1.Text;          
            String nombre = textBox3.Text;
            String apellido = textBox4.Text;
            String nroDoc = textBox5.Text;
            String mail = textBox6.Text;
            String telefono = textBox7.Text;
            String calle = textBox8.Text;
            String localidad = textBox15.Text;
            String pais = textBox16.Text;
            String nacionalidad = textBox17.Text;
            String depto = textBox14.Text;            
            
            //NUMEROS
            int nroCalle = 0;
            if (textBox12.Text != "") { nroCalle = int.Parse(textBox12.Text); }
            int nroPiso = 0; 
            if (textBox13.Text != "") { nroPiso = int.Parse(textBox13.Text); }

            //OTROS
            String tipoDoc = "";
            if (comboBoxTipoDoc.SelectedItem != null) { tipoDoc = (String)comboBoxTipoDoc.SelectedItem; }
            Boolean activo = checkBox1.Checked;
            DateTime fechaNacimiento = dateTime.Value;

            //SI SE CAMBIA LA PASSWORD SE VUELVE A GENERAR
            //SINO SE MANTIENE LA MISMA
            if (passwordChanged) { password = repoUser.EncriptarSHA256(this.password); } else { password = usuario.getPassword(); }

            //VALORES QUE NO CAMBIAN
            String tipoIdentidad = "Usuario";
            int idDir = usuario.getIdentidad().getDireccion().getIdDireccion();
            int idIdentidad = usuario.getIdentidad().getIdIdentidad();
            int idUsuario = usuario.getIdUsuario();
            int intentosFallidosLogin = usuario.getIntentosFallidosLogin();            
            
            //traigo los roles elegidos
            List<Rol> roles = new List<Rol>();
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    roles.Add(item.DataBoundItem as Rol);
                }
            //traigo los hoteles elegidos
            List<Hotel> hoteles = new List<Hotel>();
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                hoteles.Add(item.DataBoundItem as Hotel);
            }

            Direccion adress = new Direccion(idDir,pais, localidad, calle, nroCalle, nroPiso, depto);
            Identidad identidad =new Identidad(idIdentidad,tipoIdentidad,nombre, apellido,tipoDoc,nroDoc,mail,fechaNacimiento,nacionalidad,telefono, adress);
            Usuario user = new Usuario(idUsuario, identidad, username,password,intentosFallidosLogin, activo,roles,hoteles);

            if (this.validoInput(this))
            {
                try
                {
                    repoUser.update(user);
                    MessageBox.Show("Usuario actualizado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //ME TRAIGO EL USUARIO ACTUALIZADO
                    this.usuario = repoUser.getById(usuario.getIdUsuario());
                    this.resetearDatos();
                }
                catch (NoExisteIDException exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifique haber ingresado todos los datos necesarios para actualizar el usuario, incluyendo los roles que el usuario desempeña y los hoteles donde el usuario trabaja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean validoInput(ModificacionUsuario form)
        {
            return !form.textBox1.Text.Equals("") &&
                   !this.password.Equals("") && //!form.textBox2.Text.Equals("") &&
                   !form.textBox3.Text.Equals("") &&
                   !form.textBox4.Text.Equals("") &&
                   !form.textBox5.Text.Equals("") &&
                   !form.textBox6.Text.Equals("") &&
                   !form.textBox7.Text.Equals("") &&
                   !form.textBox8.Text.Equals("") &&
                   !form.textBox12.Text.Equals("") &&
                   !form.textBox13.Text.Equals("") &&
                   //!form.textBox14.Text.Equals("") && //DEPTO PUEDE ESTAR VACIO (?)
                   !form.textBox15.Text.Equals("") &&
                   !form.textBox16.Text.Equals("") &&
                   !form.textBox17.Text.Equals("") &&
                   !form.dataGridView1.SelectedRows.Count.Equals(0) &&
                   !form.dataGridView2.SelectedRows.Count.Equals(0) &&
                   form.comboBoxTipoDoc.SelectedValue != null;
        }

        private void ModificacionUsuario_Load(object sender, EventArgs e)
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
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ESTO LO PONGO PARA QUE EL PISO DEL DEPTO SOLO PUEDA SER UN NUMERO
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ESTO LO PONGO PARA QUE EL DOCUMENTO SOLO PUEDA TENER NUMEROS
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ESTO LO PONGO PARA QUE EL TELEFONO SOLO PUEDA TENER NUMEROS
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            passwordChanged = true;
            this.password = textBox2.Text;
        }
    }
}
