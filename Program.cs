using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmRol;

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
            //Comento la ejecucion del "Formulario Principal"
            //Application.Run(new Form1());
            //Para probar el ABM de Roles
            //Application.Run(new ABMRoles());
            Application.Run(new PantallaPrincipal());
        }
    }
}
