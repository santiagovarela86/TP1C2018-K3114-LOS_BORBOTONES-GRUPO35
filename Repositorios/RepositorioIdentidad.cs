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
                apellido = reader.SafeGetString(reader.GetOrdinal("Apellido"));
                tipoIdentidad = reader.GetString(reader.GetOrdinal("TipoIdentidad"));
                tipoDocumento = reader.GetString(reader.GetOrdinal("TipoDocumento"));
                numeroDocumento = reader.GetString(reader.GetOrdinal("NumeroDocumento"));
                mail = reader.GetString(reader.GetOrdinal("Mail"));
                nacionalidad = reader.SafeGetString(reader.GetOrdinal("Nacionalidad"));
                telefono = reader.GetString(reader.GetOrdinal("Telefono"));
                fechaNacimiento = reader.SafeGetDateTime(reader.GetOrdinal("FechaNacimiento"));
                direcciones.Add(repoDireccion.getByIdIdentidad(idIdentidad));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (nombre.Equals("")) throw new NoExisteIDException("No existe identidad con el ID asociado");

            //Armo la identidad
            identidad = new Identidad(idIdentidad, tipoIdentidad, nombre, apellido, tipoDocumento, numeroDocumento, mail, fechaNacimiento, nacionalidad, telefono, direcciones);
            return identidad;
        }

        override public int create(Identidad identidad)
        {
            int idIdentidad = 0;
            if (this.exists(identidad))
            {
                //controlo por mail que me sirve para el cliente de paso
                throw new ElementoYaExisteException("Ya existe la identidad que intenta crear");
            }
            else
            {
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;
        
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@TipoIdent", identidad.getTipoIdentidad());
                sqlCommand.Parameters.AddWithValue("@Nombre", identidad.getNombre());
                sqlCommand.Parameters.AddWithValue("@Apellido", identidad.getApellido());
                sqlCommand.Parameters.AddWithValue("@TipoDoc", identidad.getTipoDocumento());
                sqlCommand.Parameters.AddWithValue("@NroDoc", identidad.getNumeroDocumento());
                sqlCommand.Parameters.AddWithValue("@Mail", identidad.getMail());
                sqlCommand.Parameters.AddWithValue("@FecNac", identidad.getFechaNacimiento());
                sqlCommand.Parameters.AddWithValue("@Nacion", identidad.getNacionalidad());
                sqlCommand.Parameters.AddWithValue("@Tel", identidad.getTelefono());

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad,Nombre, Apellido,TipoDocumento,NumeroDocumento,Mail,FechaNacimiento,Nacionalidad,Telefono)
                    OUTPUT INSERTED.idIdentidad
                    VALUES(@TipoIdent,@Nombre,@Apellido,@TipoDoc,@NroDoc,@Mail,@FecNac,@Nacion,@Tel);

                    DECLARE @idIdentidad int;
                    SET @idIdentidad = SCOPE_IDENTITY();
                ");

                sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

                sqlCommand.CommandText = sqlBuilder.ToString();
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                
                if (reader.Read())
                {
                    idIdentidad = reader.GetInt32(reader.GetOrdinal("idIdentidad"));
                }

                sqlConnection.Close();
            }

            return idIdentidad;
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
            int idIdentidad = 0;
            String mail = "";

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idIdentidad", identidad.getIdIdentidad());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE idIdentidad = @idIdentidad";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idIdentidad = reader.GetInt32(reader.GetOrdinal("idIdentidad"));
            }

            sqlConnection.Close();

            sqlCommand.Parameters.AddWithValue("@Mail", identidad.getMail());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT Mail FROM LOS_BORBOTONES.Identidad WHERE Mail = @Mail";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                mail = reader.GetString(reader.GetOrdinal("Mail"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el username coincide
            return idIdentidad != 0 || identidad.getMail().ToUpper().Equals(mail.ToUpper());
        }

        override public List<Identidad> getAll()
        {
            throw new NotImplementedException();
        }

        public override void bajaLogica(Identidad identidad)
        {
            throw new System.NotImplementedException();
        }

        public List<String> getAllTiposDocsClientes()
        {
            List<String> listaTiposDocs = new List<String>();
            
            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT DISTINCT TipoDocumento FROM LOS_BORBOTONES.Identidad WHERE TipoIdentidad = 'Cliente'";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                listaTiposDocs.Add(reader.GetString(reader.GetOrdinal("TipoDocumento")));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return listaTiposDocs;
        }
    }
}
