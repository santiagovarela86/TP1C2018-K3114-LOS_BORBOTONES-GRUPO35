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
using System.Diagnostics;

namespace FrbaHotel.AbmRol
{
    public partial class ModificacionRol : Form
    {
        //ROL A MODIFICAR
        Rol rol = null;

        private void button1_Click(object sender, EventArgs e)
        {
            this.ModificacionRol_Load(sender, e);
        }

        public ModificacionRol(Rol rol)
        {
            InitializeComponent();
            this.rol = rol;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificacionRol_Load(object sender, EventArgs e)
        {
            //BUSCO TODAS LAS FUNCIONALIDADES
            RepositorioFuncionalidad repositorioFuncionalidad = new RepositorioFuncionalidad();
            dataGridView1.DataSource = repositorioFuncionalidad.getAll();

            //MARCO LAS FUNCIONALIDADES QUE PERTENECEN AL ROL
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Funcionalidad funcionalidad = (Funcionalidad)row.DataBoundItem;
                if (rol.getFuncionalidades().Exists(f => f.getDescripcion().Equals(funcionalidad.getDescripcion())))
                {
                    dataGridView1.Rows[row.Index].Selected = true;
                    dataGridView1.Rows[row.Index].Cells[0].Selected = true;
                }
            }

            //MOSTRAR EL NOMBRE DEL ROL
            textBox1.Text = rol.getNombre();

            //MOSTRAR SI EL ROL ESTA ACTIVO
            checkBox1.Checked = rol.getActivo();
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
