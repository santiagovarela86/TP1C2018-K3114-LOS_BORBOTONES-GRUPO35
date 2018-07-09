using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using FrbaHotel.Excepciones;

namespace FrbaHotel
{
    public partial class HomeListado : Form
    {
        public static DateTime fecha;
        public static ConectorSQL Base = new ConectorSQL();
        public static Login.FormLogin login;

        public HomeListado()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fecha = dateTimePicker1.Value;
              MessageBox.Show(fecha.ToShortDateString());
            this.Hide();
            login = new Login.FormLogin();
            login.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}