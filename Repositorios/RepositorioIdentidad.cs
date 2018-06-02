using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Repositorios
{
    public class RepositorioIdentidad : Repositorio<Identidad>
    {
        override public Identidad getById(int idIdentidad)
        {
            //Elementos de la identidad a devolver
            Identidad identidad = null;
            String tipoIdentidad = "";
            String nombre = "";
            String apellido = "";
            String tipoDocumento = "";
            String numeroDocumento = "";
            String mail = "";
            DateTime fechaNacimiento = new DateTime();
            String nacionalidad = "";
            String telefono = "";
            List<Direccion> direcciones = new List<Direccion>();
            RepositorioDireccion repoDireccion = new RepositorioDireccion();
            

            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idIdentidad", idIdentidad);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Identidad WHERE idIdentidad = @idIdentidad";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                apellido = reader.GetString(reader.GetOrdinal("Apellido"));
                tipoIdentidad = reader.GetString(reader.GetOrdinal("TipoIdentidad"));
                tipoDocumento = reader.GetString(reader.GetOrdinal("TipoDocumento"));
                numeroDocumento = reader.GetString(reader.GetOrdinal("NumeroDocumento"));
                mail = reader.GetString(reader.GetOrdinal("Mail"));
                nacionalidad = reader.GetString(reader.GetOrdinal("Nacionalidad"));
                telefono = reader.GetString(reader.GetOrdinal("Telefono"));
                fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));                
                direcciones.Add(repoDireccion.getByIdIdentidad(idIdentidad));
                
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (identidad.Equals(null)) throw new NoExisteIDException("No existe identidad con el ID asociado");

            //Armo la identidad
            identidad = new Identidad(idIdentidad, tipoIdentidad, nombre, apellido, tipoDocumento, numeroDocumento, mail, fechaNacimiento, nacionalidad, telefono, direcciones);
            return identidad;
        }

        override public void create(Identidad identidad)
        {
            if (this.exists(identidad))
            {
                //Error
            }
            else
            {
                //Creo un nuevo registro
            }
        }

        override public void update(Identidad identidad)
        {
            if (this.exists(identidad))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Identidad identidad)
        {
            if (this.exists(identidad))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public Boolean exists(Identidad identidad)
        {
            throw new NotImplementedException();
        }

        override public List<Identidad> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
