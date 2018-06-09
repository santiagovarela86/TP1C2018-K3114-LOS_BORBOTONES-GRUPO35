using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmRol;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["BaseLocal"]))
                {
                    connection.Open();
                    connection.Close();
                }

                Application.Run(new PantallaPrincipal());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error de conexión con la base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
