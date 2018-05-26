using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;

namespace FrbaHotel.AbmRol
{
    public partial class AltaModificacionRol : Form
    {
        public AltaModificacionRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            checkBox1.Checked = false;
            listBox1.ClearSelected();
        }

        private void AltaModificacionRol_Load(object sender, EventArgs e)
        {
            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();
            listBox1.DataSource = repositorioFuncionalidad.getAll();
            listBox1.DisplayMember = "descripcion";
            listBox1.ClearSelected();
        }

        public AltaModificacionRol(Rol rol)
        {
            InitializeComponent();

            //MOSTRAR EN EL NOMBRE EL NOMBRE DEL ROL
            textBox1.Text = rol.getNombre();

            //MOSTRAR SI EL ROL ESTA ACTIVO
            checkBox1.Checked = rol.getActivo();

            /*

            //SI NO PONGO ESTO NO SE LLENA EL CAMPO ITEMS DEL LISTBOX... (???)
            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();
            listBox1.DataSource = repositorioFuncionalidad.getAll();

            /*
            SELECCIONAR EN EL LIST BOX LAS FUNCIONALIDADES QUE TIENE EL ROL
            
             * foreach (Funcionalidad funcionalidad in rol.getFuncionalidades())
            {
                //listBox1.SelectedItem = listBox1.Items.IndexOf(funcionalidad);
                listBox1.SetSelected(listBox1.Items.IndexOf(funcionalidad), true);
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
