using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel.Repositorios
{
    public class RepositorioEstadia : Repositorio<Estadia>
    {
        override public Estadia getById(int idEstadia)
        {
            //Elementos de la Estadia a devolver
            Estadia estadia;
            
            Usuario usuarioCheckIn = null;
            Usuario usuarioCheckOut = null;
            DateTime fechaEntrada = new DateTime();
            DateTime fechaSalida = new DateTime();
            Boolean facturada = false;
            RepositorioUsuario repoUsuario = new RepositorioUsuario();
            
            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idEstadia", idEstadia);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Estadia WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                usuarioCheckIn = repoUsuario.getById(reader.GetOrdinal("IdUsuarioIn"));
                usuarioCheckOut = repoUsuario.getById(reader.GetOrdinal("IdUsuarioOut"));
                fechaEntrada = reader.GetDateTime(reader.GetOrdinal("FechaEntrada"));
                fechaSalida = reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                facturada = reader.GetBoolean(reader.GetOrdinal("Facturada"));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (usuarioCheckIn.Equals(null)) throw new NoExisteIDException("No existe estadia con el ID asociado");

            //Armo la estadia completa
            estadia = new Estadia(idEstadia, usuarioCheckIn, usuarioCheckOut, fechaEntrada, fechaSalida, facturada);
            return estadia;
        }

        override public List<Estadia> getAll()
        {
            List<Estadia> estadias = new List<Estadia>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Estadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                estadias.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idEstadia"))));
            }

            sqlConnection.Close();

            return estadias;
        }

        override public int create(Estadia estadia)
        {
            if (this.exists(estadia))
            {
                //Error
            }
            else
            {
                //Creo un nuevo registro
            }

            throw new System.NotImplementedException();
        }

        override public void update(Estadia estadia)
        {
            if (this.exists(estadia))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Estadia estadia)
        {
            if (this.exists(estadia))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }
        override public Boolean exists(Estadia estadia)
        {
            int idEstadia = 0;
            int idUserIn = 0;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idEstadia", estadia.getIdEstadia());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Estadia WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
            }

            sqlConnection.Close();
            Usuario user = null;
            user = estadia.getUsuarioCheckIn();

            //valido por el idUserIn que tiene en la base
            sqlCommand.Parameters.AddWithValue("@idUsuario", user.getIdUsuario());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idUsuarioIn FROM LOS_BORBOTONES.Estadia WHERE idUsuarioIn = @idUsuario";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idUserIn = reader.GetInt32(reader.GetOrdinal("idUsuarioIn"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el IdUserIn coincide
            return idEstadia != 0 || user.getIdUsuario().Equals(idUserIn);
        }
        //luego hacer algun getBy que vea especial y el getByQuery
    }
}

