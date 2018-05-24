using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Repositorios;

namespace FrbaHotel.AbmRol
{
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<String, Boolean>> opciones = new List<KeyValuePair<String, Boolean>>();
            opciones.Add(new KeyValuePair<String, Boolean>("Habilitado", true));
            opciones.Add(new KeyValuePair<String, Boolean>("Inhabilitado", false));
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Key";
            comboBox1.DataSource = opciones;

            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();
            comboBox2.ValueMember = "idFuncionalidadI";
            comboBox2.DisplayMember = "descripcionI";
            comboBox2.DataSource = repositorioFuncionalidad.getAll();
        }
    }
}
