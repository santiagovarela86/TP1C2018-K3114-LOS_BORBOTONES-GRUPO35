using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrbaHotel.Repositorios;
using FrbaHotel.Excepciones;

namespace FrbaHotel.Repositorios
{
    public class RepositorioHabitacion : Repositorio<Habitacion>
    {

        //private RepositorioTipoHabitacion repositorioTipoHabitacion;

        public override int create(Habitacion habitacion)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            int idHabitacion = 0;

            if(this.exists(habitacion)){
                throw new RequestInvalidoException("Ya existe una habitacion con el mismo numero en el hotel");
            }

            sqlCommand.Parameters.AddWithValue("@habActiva", habitacion.Activa);
            sqlCommand.Parameters.AddWithValue("@habNumero", habitacion.Numero);
            sqlCommand.Parameters.AddWithValue("@habPiso", habitacion.Piso);
            sqlCommand.Parameters.AddWithValue("@habUbicacion", habitacion.Ubicacion);
            sqlCommand.Parameters.AddWithValue("@habIdHotel", habitacion.getHotel().IdHotel);
            sqlCommand.Parameters.AddWithValue("@habIdTipoHabitacion", habitacion.TipoHabitacion.getIdTipoHabitacion());

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO  LOS_BORBOTONES.Habitacion(Activa,Numero,Piso,Ubicacion,idHotel,idTipoHabitacion) OUTPUT INSERTED.idHabitacion" +
                " VALUES (@habActiva,@habNumero,@habPiso,@habUbicacion,@habIdHotel,@habIdTipoHabitacion);";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                idHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
            }

            sqlConnection.Close();
            return idHabitacion;
        }


        override public void bajaLogica(Habitacion habitacion)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            sqlCommand.Parameters.AddWithValue("@habActiva", habitacion.Activa);
            sqlCommand.Parameters.AddWithValue("@habidHabitacion", habitacion.IdHabitacion);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UPDATE LOS_BORBOTONES.Habitacion SET Activa= @habActiva WHERE idHabitacion=@habidHabitacion";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }
        public override void delete(Habitacion t)
        {
            throw new NotImplementedException();
        }

        public override bool exists(Habitacion habitacion)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@habNumero", habitacion.Numero);
            sqlCommand.Parameters.AddWithValue("@habIdHotel", habitacion.getHotel().IdHotel);

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT 1 FROM LOS_BORBOTONES.Habitacion "+
                " WHERE Numero=@habNumero AND idHotel=@habIdHotel;";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            bool exists=reader.Read();
            sqlConnection.Close();
            return exists;
        }

        public override List<Habitacion> getAll()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            RepositorioTipoHabitacion repositorioTipoHabitacion = new RepositorioTipoHabitacion();
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            Habitacion habitacion = null;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idHabitacion,Activa,Numero,Piso,Ubicacion,idHotel,idTipoHabitacion FROM LOS_BORBOTONES.Habitacion;";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                bool Activa = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int Numero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int Piso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String Ubicacion = reader.SafeGetString(reader.GetOrdinal("Ubicacion"));
                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                int idTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));

                TipoHabitacion tipoHabitacion = repositorioTipoHabitacion.getById(idTipoHabitacion);

                RepositorioHotel repositorioHotel = new RepositorioHotel();
                Hotel hotel = repositorioHotel.getById(idHotel);
                habitacion = new Habitacion(idHabitacion, tipoHabitacion, Activa, Numero, Piso, Ubicacion, hotel);
                habitaciones.Add(habitacion);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitaciones;
        }

        public override Habitacion getById(int id)
        {
            RepositorioTipoHabitacion repositorioTipoHabitacion = new RepositorioTipoHabitacion();
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            Habitacion habitacion = null;
            sqlCommand.Parameters.AddWithValue("@idHabitacion", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText ="SELECT idHabitacion,Activa,Numero,Piso,Ubicacion,idHotel,idTipoHabitacion FROM LOS_BORBOTONES.Habitacion AS HAB WHERE HAB.idHabitacion = @idHabitacion";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                bool Activa = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int Numero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int Piso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String Ubicacion = reader.SafeGetString(reader.GetOrdinal("Ubicacion"));
                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                int idTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));

                TipoHabitacion tipoHabitacion = repositorioTipoHabitacion.getById(idTipoHabitacion);

                RepositorioHotel repositorioHotel = new RepositorioHotel();
                Hotel hotel = repositorioHotel.getById(idHotel);
                habitacion = new Habitacion(idHabitacion, tipoHabitacion, Activa, Numero, Piso, Ubicacion, hotel);
                
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitacion;
        }

        public override void update(Habitacion t)
        {
            throw new NotImplementedException();
        }



        public List<Habitacion> getByQuery(String numero, String piso, Hotel hotel,TipoHabitacion tipoHabitacion,bool activa )
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            RepositorioTipoHabitacion repositorioTipoHabitacion = new RepositorioTipoHabitacion();


            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT DISTINCT(HAB.idHabitacion),HAB.Activa,HAB.Numero,HAB.Piso,HAB.Ubicacion,HAB.idHotel,HAB.idTipoHabitacion FROM LOS_BORBOTONES.Habitacion AS HAB" +
                getCondiciones(numero,piso,hotel,tipoHabitacion,activa,sqlCommand) + ";";
            
            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int qidHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                int qidHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                int qidTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));
                bool qactiva = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int qnumero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int qpiso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String qubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));
                TipoHabitacion qtipoHabitacion = repositorioTipoHabitacion.getById(qidTipoHabitacion);
                Hotel qhotel = repositorioHotel.getById(qidHotel);
                habitaciones.Add(new Habitacion(qidHabitacion, qtipoHabitacion, qactiva, qnumero, qpiso, qubicacion, qhotel));
           
            }

            //Cierro Primera Consulta
            sqlConnection.Close();
            return habitaciones;

        }

        private String getCondiciones(String numero, String piso, Hotel hotel,TipoHabitacion tipoHabitacion,bool activa,  SqlCommand sqlCommand)
        {

            List<String> condiciones = new List<String>();
            if (numero != null)
            {
                condiciones.Add("HAB.Numero = @habNumero ");
                sqlCommand.Parameters.AddWithValue("@habNumero", numero);

            }
            if (piso != null)
            {
                condiciones.Add("HAB.Piso=@habPiso");
                sqlCommand.Parameters.AddWithValue("@habPiso", piso);

            }
            if (hotel !=null && hotel.getIdHotel() != 0)
            {
                condiciones.Add("HAB.idHotel=@habIdHotel");
                sqlCommand.Parameters.AddWithValue("@habIdHotel", hotel.getIdHotel());

            }


            if (tipoHabitacion !=null && tipoHabitacion.getIdTipoHabitacion() != 0)
            {
                condiciones.Add("HAB.idTipoHabitacion=@habidTipoHabitacion");
                sqlCommand.Parameters.AddWithValue("@habidTipoHabitacion", tipoHabitacion.getIdTipoHabitacion());
            }
            
                condiciones.Add("HAB.Activa=@habActiva");
                sqlCommand.Parameters.AddWithValue("@habActiva",activa);
            
            if (condiciones.Count != 0)
            {
                return " WHERE " + string.Join(" AND ", condiciones.ToArray());
            }
            return "";
        }

        public List<Habitacion> getByHotelId(int idHotel,Hotel hotel)
        {

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            List<Habitacion> habitaciones = new List<Habitacion>();

            sqlCommand.Parameters.AddWithValue("@idHotel", idHotel);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idHabitacion,Activa,Numero,Piso,Ubicacion,idTipoHabitacion FROM LOS_BORBOTONES.Habitacion AS HAB WHERE HAB.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();
            RepositorioTipoHabitacion repositorioTipoHabitacion = new RepositorioTipoHabitacion();

            while (reader.Read())
            {
                int idHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                int idTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));
                bool activa = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int numero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int piso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String ubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));
                TipoHabitacion tipoHabitacion = repositorioTipoHabitacion.getById(idTipoHabitacion);

                habitaciones.Add(new Habitacion(idHabitacion, tipoHabitacion, activa, numero, piso, ubicacion, hotel));
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitaciones;
        }
    }
}
