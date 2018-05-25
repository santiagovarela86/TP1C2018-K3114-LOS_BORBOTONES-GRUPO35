using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;

namespace FrbaHotel.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void BotonLoginClick(object sender, EventArgs e)
        {
            
            try
            {

                int intentos = -1;//no existe usuario
                int estado = 0;//no habilitado

                //pasarle la password y usuario al formulario principal seguro para mostrar el nombre ahi en pantalla.
                Principal.password = txtPassword.Text;
                Principal.user=txtUsername.Text;
                
                //encripto la clave
                string Encriptada = EncriptarSHA256(txtPassword.Text);
                string user=txtUsername.Text;


                //Configuraciones de la consulta
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

                //verifico la cantidad de intentos que hizo el user
                sqlCommand.Parameters.AddWithValue("@usuario", user);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Usuario WHERE Username = @usuario";

                sqlConnection.Open();

                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    intentos = reader.GetInt16(reader.GetOrdinal("IntentosFallidosLogin"));
                }

                //verifico usuario y contraseña
                //uso el mismo sqlCommand modificando la query si falla hacer un nuevo command y liberar el otro.
                sqlCommand.Parameters.AddWithValue("@usuario", user);
                sqlCommand.Parameters.AddWithValue("@pass", Encriptada);
                sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Usuario where Username = @usuario and Password= @pass";
                reader = sqlCommand.ExecuteReader();

                // Verifico la cantidad de intentos, si es -1 como fue inicializado es que no existe el usuario
                if (intentos < 3 & intentos > -1)
                {
                    if (reader.Read())
                    {
                        estado = reader.GetInt16(reader.GetOrdinal("Estado"));
                        String userLogin = reader.GetString(reader.GetOrdinal("Username"));
                        // Verifico que el nombre de usuario y la contraseña sean validos y que el usuario este habilitado
                        //ya si me trae el estado 1 significa que valido bien usuario y contraseña
                        if (userLogin.Equals(user) && estado==1)
                        {
                            // El usuario y la contraseña son correctos y el usuario se encuentra habilitado, reseteo el contador de intentos
                            reader.Close();
                            sqlCommand.Parameters.AddWithValue("@usuario", user);
                            sqlCommand.Parameters.AddWithValue("@pass", Encriptada);
                            sqlCommand.CommandText = "Update LOS_BORBOTONES.Usuario SET IntentosFallidosLogin = 0 where Username = @usuario and Password= @pass";
                            sqlCommand.ExecuteNonQuery();
                         
                            //le digo al Principal que ya estamos logueados
                            Principal.logeado = true;

                            // Volvemos al menu principal que ya deberia tener los datos de usuario
                            Close();

                        }
                        else
                        {
                            if (userLogin.Equals(user) && estado == 0)
                            {
                                // El usuario y la contraseña son validos pero el usuario se encuentra deshabilitado
                                MessageBox.Show("El usuario ingresado se encuentra deshabilitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUsername.Text = "";
                                txtPassword.Text = "";
                            }
                            else
                            {
                                // La contraseña es incorrecta 
                                MessageBox.Show("La contraseña es incorrecta. Intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // Incrementamos la cantidad de intentos
                                reader.Close();
                                sqlCommand.Parameters.AddWithValue("@usuario", user);
                                sqlCommand.Parameters.AddWithValue("@pass", Encriptada);
                                sqlCommand.CommandText = "Update LOS_BORBOTONES.Usuario SET IntentosFallidosLogin = IntentosFallidosLogin + 1 where Username = @usuario and Password= @pass";
                                sqlCommand.ExecuteNonQuery(); 
                                txtPassword.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    if (intentos > 2)
                    {
                        // Inhabilitamos al usuario por haber realizado 3 intentos fallidos
                        MessageBox.Show("Ha superado la cantidad maxima de intentos de ingreso, su usuario ha sido deshabilitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Close(); 
                        sqlCommand.Parameters.AddWithValue("@usuario", user);
                        sqlCommand.Parameters.AddWithValue("@pass", Encriptada);
                        sqlCommand.CommandText = "Update LOS_BORBOTONES.Usuario SET Estado = 0 where Username = @usuario and Password= @pass";
                        sqlCommand.ExecuteNonQuery(); 
                    }
                    else
                    {
                        // llegamos a intentos -1 donde no existe el usuario
                        MessageBox.Show("El usuario ingresado no es valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                reader.Close();
            }
            catch (SqlException error)
            {
                DialogResult respuesta = MessageBox.Show(error.Message.ToString(), "Conflicto", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (respuesta == DialogResult.OK)
                    MessageBox.Show("Error realizando el login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public string EncriptarSHA256(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        
    }
}
