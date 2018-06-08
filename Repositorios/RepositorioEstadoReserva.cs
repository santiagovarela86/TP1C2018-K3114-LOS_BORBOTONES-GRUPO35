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
    public class RepositorioEstadoReserva : Repositorio<EstadoReserva>
    {
        override public EstadoReserva getById(int idEstadoReserva)
        {
            //Elementos del EstadoReserva a devolver
            EstadoReserva estadoReserva;
            Usuario usuario = null;
            Reserva reserva = null;
            String tipoEstado = "";
            DateTime fecha = new DateTime();
            String descripcion = "";

            RepositorioUsuario repoUsuario = new RepositorioUsuario();
            RepositorioReserva repoReserva = new RepositorioReserva();
            
            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idEstadoReserva", idEstadoReserva);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.EstadoReserva WHERE idEstado = @idEstadoReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                usuario = repoUsuario.getById(reader.GetOrdinal("IdUsuario"));
                reserva = repoReserva.getById(reader.GetOrdinal("IdReserva"));
                fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"));
                tipoEstado = reader.GetString(reader.GetOrdinal("TipoEstado"));
                descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (reserva.Equals(null)) throw new NoExisteIDException("No existe estadoReserva con el ID asociado");

            //Armo el estadoReserva completo
            estadoReserva = new EstadoReserva(idEstadoReserva, usuario, reserva, tipoEstado, fecha, descripcion);
            return estadoReserva;
        }

        override public List<EstadoReserva> getAll()
        {
            List<EstadoReserva> estadosReservas = new List<EstadoReserva>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idEstado FROM LOS_BORBOTONES.EstadoReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                estadosReservas.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idEstado"))));
            }

            sqlConnection.Close();

            return estadosReservas;
        }

        override public int create(EstadoReserva estadoReserva)
        {
            if (this.exists(estadoReserva))
            {
                //Error
            }
            else
            {
                //Creo un nuevo registro
            }

            throw new System.NotImplementedException();
        }

        override public void update(EstadoReserva estadoReserva)
        {
            if (this.exists(estadoReserva))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(EstadoReserva estadoReserva)
        {
            if (this.exists(estadoReserva))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }
        override public Boolean exists(EstadoReserva estadoReserva)
        {
            int idEstado = 0;
            int idReserva = 0;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idEstado", estadoReserva.getIdEstadoReserva());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idEstado FROM LOS_BORBOTONES.EstadoReserva WHERE idEstado = @idEstado";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idEstado = reader.GetInt32(reader.GetOrdinal("idEstado"));
            }

            sqlConnection.Close();
            Reserva reserva = null;
            reserva = estadoReserva.getReserva();

            //valido por el idReserva que tiene en la base
            sqlCommand.Parameters.AddWithValue("@idReserva", reserva.getIdReserva());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idReserva FROM LOS_BORBOTONES.EstadoReserva WHERE idReserva = @idReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el IdReserva coincide
            return idEstado != 0 || reserva.getIdReserva().Equals(idReserva);
        }
        //luego hacer algun getBy que vea especial y el getByQuery
    }
}

