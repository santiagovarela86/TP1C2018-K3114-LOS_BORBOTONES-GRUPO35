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
    public class RepositorioReserva : Repositorio<Reserva>
    {




        public List<Reserva> getByIdHotel(int idHotel)
        {

            RepositorioHotel repoHotel = new RepositorioHotel();
            RepositorioRegimen repoRegimen = new RepositorioRegimen();
            RepositorioCliente repoCliente = new RepositorioCliente();
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();

            List<Reserva> reservas = new List<Reserva>();
            
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            
            sqlCommand.Parameters.AddWithValue("@idHotel", idHotel);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Reserva WHERE idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
                decimal codigoReserva = reader.GetDecimal(reader.GetOrdinal("CodigoReserva"));
                decimal diasAlojados = reader.GetDecimal(reader.GetOrdinal("DiasAlojados"));
                DateTime fechaDesde = reader.SafeGetDateTime(reader.GetOrdinal("FechaDesde"));
                DateTime fechaHasta = reader.SafeGetDateTime(reader.GetOrdinal("FechaHasta"));
                DateTime fechaCreacion = reader.SafeGetDateTime(reader.GetOrdinal("FechaCreacion"));
                Hotel hotel = repoHotel.getById(reader.GetOrdinal("IdHotel"));
                Regimen regimen = repoRegimen.getById(reader.GetOrdinal("IdRegimen"));
                Estadia estadia = repoEstadia.getById(reader.GetOrdinal("IdEstadia"));
                Cliente cliente = repoCliente.getById(reader.GetOrdinal("IdCliente"));
                List<EstadoReserva> estados= repoEstadoReserva.getByIdReserva(idReserva);
                Reserva reserva = new Reserva(idReserva, hotel, estadia, regimen, cliente, codigoReserva, diasAlojados, fechaCreacion, fechaDesde, fechaHasta, estados);
                reservas.Add(reserva);
            }
            sqlConnection.Close();

            return reservas;

        }
        override public Reserva getById(int idReserva)
        {

            RepositorioHotel repoHotel = new RepositorioHotel();
            RepositorioRegimen repoRegimen = new RepositorioRegimen();
            RepositorioCliente repoCliente = new RepositorioCliente();
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();

            //Elementos de la Reserva a devolver
            Reserva reserva;

            Hotel hotel = null;
            Estadia estadia = null;
            Regimen regimen = null;
            Cliente cliente = null;
            decimal codigoReserva = 0;
            decimal diasAlojados = 0;
            DateTime fechaCreacion = new DateTime();
            DateTime fechaDesde = new DateTime();
            DateTime fechaHasta = new DateTime();
            List<EstadoReserva> estados = new List<EstadoReserva>();
            
            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idReserva", idReserva);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Reserva WHERE idReserva = @idReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                codigoReserva = reader.GetDecimal(reader.GetOrdinal("CodigoReserva"));
                diasAlojados = reader.GetDecimal(reader.GetOrdinal("DiasAlojados"));
                fechaDesde = reader.GetDateTime(reader.GetOrdinal("FechaDesde"));
                fechaHasta = reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                fechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion"));
                hotel = repoHotel.getById(reader.GetOrdinal("IdHotel"));
                regimen = repoRegimen.getById(reader.GetOrdinal("IdRegimen"));
                estadia = repoEstadia.getById(reader.GetOrdinal("IdEstadia"));
                cliente = repoCliente.getById(reader.GetOrdinal("IdCliente"));
                estados.Add(repoEstadoReserva.getById(idReserva));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (cliente.Equals(null)) throw new NoExisteIDException("No existe reserva con el ID asociado");

            //Armo la reserva completa
            reserva = new Reserva(idReserva, hotel, estadia, regimen, cliente, codigoReserva, diasAlojados, fechaCreacion, fechaDesde, fechaHasta, estados);

            return reserva;
        }

        override public List<Reserva> getAll()
        {
            List<Reserva> reservas = new List<Reserva>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idReserva FROM LOS_BORBOTONES.Reserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                reservas.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idReserva"))));
            }

            sqlConnection.Close();

            return reservas;
        }

        override public int create(Reserva reserva)
        {
            throw new NotImplementedException();

        }

        override public void update(Reserva reserva)
        {
            if (this.exists(reserva))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Reserva reserva)
        {
            if (this.exists(reserva))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public void bajaLogica(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        override public Boolean exists(Reserva reserva)
        {
            int idReserva = 0;
            int idEstadia = 0;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReserva", reserva.getIdReserva());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idReserva FROM LOS_BORBOTONES.Reserva WHERE idReserva = @idReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
            }

            sqlConnection.Close();

            Estadia estadia = null;
            estadia = reserva.getEstadia();

            //valido por el idEstadia que tiene en la base
            sqlCommand.Parameters.AddWithValue("@idEstadia", estadia.getIdEstadia());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Reserva WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el IdEstadia coincide
            return idReserva != 0 || estadia.getIdEstadia().Equals(idEstadia);
        }
        //luego hacer algun getBy que vea especial y el getByQuery
    }
}

