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

            //VERIFICO QUE LA BASE ESTE ARRIBA
            if (IsServerConnected(ConfigurationManager.AppSettings["BaseLocal"]))
            {
                Application.Run(new PantallaPrincipal());
            }
            else
            {
                MessageBox.Show("Inicie la instancia SQLSERVER2012 para comenzar", "Error de conexión con la base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        //METODO QUE VERIFICA QUE ESTE LEVANTADA LA BASE DE DATOS AL COMENZAR
        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
