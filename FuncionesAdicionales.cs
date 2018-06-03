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

namespace FrbaHotel
{
    public partial class FuncionesAdicionales : Form
    {
        Usuario usuarioLogueado = null;

        public FuncionesAdicionales(Usuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FuncionesAdicionales_Load(object sender, EventArgs e)
        {
            //CUANDO CARGA ESTE FORMULARIO
            //DEBO VERIFICAR LOS ROLES QUE TENGO Y SEGUN LOS ROLES QUE TENGA
            //HABILITAR Y/O DESHABILITAR BOTONES DE LAS FUNCIONALIDADES
        }
    }
}
