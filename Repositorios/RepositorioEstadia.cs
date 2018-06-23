using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FrbaHotel.Repositorios
{
    public class RepositorioEstadia : Repositorio<Estadia>
    {
        override public Estadia getById(int idEstadia)
        {
            //Elementos de la Estadia a devolver
            Estadia estadia;

            int cantidadNoches = 0;
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
                usuarioCheckIn = repoUsuario.getById(reader.GetInt32(reader.GetOrdinal("idUsuarioIn")));
                usuarioCheckOut = repoUsuario.getById(reader.GetInt32(reader.GetOrdinal("idUsuarioOut")));
                fechaEntrada = reader.GetDateTime(reader.GetOrdinal("FechaEntrada"));
                fechaSalida = reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                facturada = reader.GetBoolean(reader.GetOrdinal("Facturada"));
                cantidadNoches = reader.GetInt32(reader.GetOrdinal("CantidadNoches"));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (usuarioCheckIn.Equals(null)) throw new NoExisteIDException("No existe estadia con el ID asociado");

            //Armo la estadia completa
            estadia = new Estadia(idEstadia, usuarioCheckIn, usuarioCheckOut, fechaEntrada, fechaSalida, facturada,cantidadNoches);
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

        override public void delete(Estadia estadia)
        {
            if (this.exists(estadia))
            {
                //Error
            }
            else
            {
                //elimino registro
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

        override public int create(Estadia estadia)
        {
            int idEstadia = 0;
            if (this.exists(estadia))
            {
                throw new ElementoYaExisteException("Ya existe la estadia que intenta crear");
            }
            else
            {
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;
                

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@FecIn", estadia.getFechaEntrada());
                sqlCommand.Parameters.AddWithValue("@FecOut", estadia.getFechaSalida());
                sqlCommand.Parameters.AddWithValue("@CantNoches", estadia.getCantidadNoches());
                sqlCommand.Parameters.AddWithValue("@Facturada", estadia.getFacturada());
                sqlCommand.Parameters.AddWithValue("@UserIn", estadia.getUsuarioCheckIn().getIdUsuario());
                sqlCommand.Parameters.AddWithValue("@UserOut", estadia.getUsuarioCheckOut().getIdUsuario());

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada,FechaSalida,CantidadNoches,Facturada,idUsuarioIn,idUsuarioOut)
                    OUTPUT INSERTED.idEstadia
                    VALUES(@FecIn, @FecOut, @CantNoches, @Facturada, @UserIn, @UserOut);

                    DECLARE @idEstadia int;
                    SET @idEstadia = SCOPE_IDENTITY();
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
                    idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
                }

                sqlConnection.Close();
            }

            return idEstadia;
        }

        override public void bajaLogica(Estadia estadia)
        {
            throw new NotImplementedException();
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

