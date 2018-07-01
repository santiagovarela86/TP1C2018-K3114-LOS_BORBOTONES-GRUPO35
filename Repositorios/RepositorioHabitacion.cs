using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrbaHotel.Repositorios;
using FrbaHotel.Excepciones;
using FrbaHotel.AbmReserva;

namespace FrbaHotel.Repositorios
{
    public class RepositorioHabitacion : Repositorio<Habitacion>
    {


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
            sqlCommand.Parameters.AddWithValue("@habIdTipoHabitacion", habitacion.getTipoHabitacion().getIdTipoHabitacion());

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

            sqlCommand.Parameters.AddWithValue("@habIdHabitacion", habitacion.IdHabitacion);
            sqlCommand.Parameters.AddWithValue("@habNumero", habitacion.Numero);
            sqlCommand.Parameters.AddWithValue("@habIdHotel", habitacion.getHotel().IdHotel);

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT 1 FROM LOS_BORBOTONES.Habitacion "+
                " WHERE Numero=@habNumero AND idHotel=@habIdHotel AND idHabitacion!=@habIdHabitacion;";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            bool exists=reader.Read();
            sqlConnection.Close();
            return exists;
        }

        public override List<Habitacion> getAll()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
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
                
                habitacion = new Habitacion(idHabitacion, Activa, Numero, Piso, Ubicacion);
                habitaciones.Add(habitacion);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitaciones;
        }

        public override Habitacion getById(int id)
        {
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

                habitacion = new Habitacion(idHabitacion, Activa, Numero, Piso, Ubicacion);
                
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitacion;
        }


        



        public override void update(Habitacion habitacion)
        {
            if (!this.exists(habitacion))
            {
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;
                sqlCommand.Parameters.AddWithValue("@habIdHotel", habitacion.getHotel().getIdHotel());
                sqlCommand.Parameters.AddWithValue("@habUbicacion", habitacion.getUbicacion());
                sqlCommand.Parameters.AddWithValue("@habNumero", habitacion.getNumero());
                sqlCommand.Parameters.AddWithValue("@habPiso", habitacion.getPiso());
                sqlCommand.Parameters.AddWithValue("@habActiva", habitacion.getActiva());
                sqlCommand.Parameters.AddWithValue("@habidHabitacion", habitacion.getIdHabitacion());
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE LOS_BORBOTONES.Habitacion SET Activa= @habActiva,Numero=@habNumero,Piso=@habPiso,Ubicacion=@habUbicacion,idHotel=@habIdHotel WHERE idHabitacion=@habidHabitacion";

                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                sqlConnection.Close();
            }else{
                throw new RequestInvalidoException("El numero de habitacion en el hotel al cual se quiere actualizar ya existe");
            }
        }



        public List<Habitacion> getByQuery(String numero, String piso, Hotel hotel,TipoHabitacion tipoHabitacion,bool activa )
        {
            List<Habitacion> habitaciones = new List<Habitacion>();


            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT  DISTINCT (HAB.idHabitacion) ,HAB.Activa,HAB.Numero,HAB.Piso,HAB.Ubicacion,HAB.idHotel,HAB.idTipoHabitacion FROM LOS_BORBOTONES.Habitacion AS HAB" +
                getCondiciones(numero,piso,hotel,tipoHabitacion,activa,sqlCommand) + ";";
            
            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int qidHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                bool qactiva = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int qnumero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int qpiso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String qubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));
                habitaciones.Add(new Habitacion(qidHabitacion, qactiva, qnumero, qpiso, qubicacion));
           
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

        public List<Habitacion> getByHotelId(int idHotel)
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

            while (reader.Read())
            {
                int idHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                int idTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));
                bool activa = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int numero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int piso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String ubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));

                habitaciones.Add(new Habitacion(idHabitacion, activa, numero, piso, ubicacion));
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitaciones;
        }


        public List<HabitacionDisponibleSearchDTO> getHabitacionesDisponibles(DateTime fechaInicio, DateTime fechaFin,Hotel hotel, TipoHabitacion tipoHabitacion, Regimen regimen) { 

            List<HabitacionDisponibleSearchDTO> habitacionesDisponibles= new List<HabitacionDisponibleSearchDTO>();
            RepositorioRegimen repoRegimen = new RepositorioRegimen();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@fechaInicio",fechaInicio);
            sqlCommand.Parameters.AddWithValue("@fechaFin", fechaFin);

            sqlCommand.Parameters.AddWithValue("@idHotel", hotel.getIdHotel());
            
            String queryTipoHab="";
            if(tipoHabitacion!=null){
                sqlCommand.Parameters.AddWithValue("@idtipoHabitacion", tipoHabitacion.getIdTipoHabitacion());
                queryTipoHab= "AND HAB.idTipoHabitacion=@idtipoHabitacion ";
            }

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT HAB.idHabitacion,HAB.Activa,HAB.Numero,HAB.Piso,HAB.Ubicacion,HAB.idHotel,HAB.idTipoHabitacion,REG.idRegimen FROM LOS_BORBOTONES.Habitacion AS HAB " +
                "JOIN LOS_BORBOTONES.Hotel AS HOT ON HOT.idHotel=HAB.idHotel " +
                "JOIN LOS_BORBOTONES.Regimen_X_Hotel AS RXH ON RXH.idHotel=HOT.idHotel " +
                "JOIN LOS_BORBOTONES.Regimen AS REG ON REG.idRegimen = RXH.idRegimen " +
                "JOIN LOS_BORBOTONES.TipoHabitacion AS TIP ON TIP.idTipoHabitacion=HAB.idTipoHabitacion " +
                "WHERE REG.Activo=1 " +
                "AND HAB.idHotel=@idHotel " +
                "AND HAB.Activa=1 " +
                queryTipoHab +
                "AND NOT EXISTS ( " + 
                "SELECT * FROM LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente AS RXHXC " + 
                "JOIN LOS_BORBOTONES.Reserva AS RES ON RES.idReserva = RXHXC.idReserva  " + 
                "WHERE HAB.idHabitacion= RXHXC.idHabitacion " +
                "AND  (RES.FechaDesde < @fechaFin AND @fechaInicio < RES.FechaHasta  ) " +
                "AND NOT EXISTS( "+
                "SELECT * FROM LOS_BORBOTONES.EstadoReserva AS ESRE " + 
                "WHERE RES.idReserva = ESRE.idReserva " +
                "AND ESRE.TipoEstado  IN ('RCR','RCC','RCNS') " +
                ") " + 
                ") " + 
                
                "AND NOT EXISTS (SELECT * FROM LOS_BORBOTONES.CierreTemporal AS CIE WHERE CIE.idHotel= HOT.idHotel AND CIE.FechaInicio < @fechaFin AND @fechaInicio < CIE.FechaFin) ";

            if (regimen != null)
            {
                sqlCommand.Parameters.AddWithValue("@idRegimen", regimen.getIdRegimen());
                sqlCommand.CommandText+=" AND REG.idRegimen=@idRegimen ";
            }

            sqlCommand.CommandText += " GROUP BY HAB.idHabitacion, REG.idRegimen, HAB.Activa,HAB.Numero,HAB.Piso,HAB.Ubicacion,HAB.idHotel,HAB.idTipoHabitacion " +
                " ORDER BY HAB.idHabitacion;";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int qidHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));
                int qidTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));
                bool qactiva = reader.GetBoolean(reader.GetOrdinal("Activa"));
                int qnumero = reader.GetInt32(reader.GetOrdinal("Numero"));
                int qpiso = reader.GetInt32(reader.GetOrdinal("Piso"));
                int qidRegimen=  reader.GetInt32(reader.GetOrdinal("idRegimen"));
                String qubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));
                Regimen qregimen = repoRegimen.getById(qidRegimen);
                Habitacion qhabitacion =new Habitacion(qidHabitacion, qactiva, qnumero, qpiso, qubicacion);
                habitacionesDisponibles.Add(new HabitacionDisponibleSearchDTO(qhabitacion,qregimen));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();
            return habitacionesDisponibles;
        
        
        }


        public List<Habitacion> getHabitacionesByReservaId(Reserva reserva) {

            List<Habitacion> habitaciones = new List<Habitacion>();
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            sqlCommand.Parameters.AddWithValue("@idReserva", reserva.getIdReserva());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente AS RXH " +
                                     "WHERE RXH.idReserva = @idReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                int idHabitacion = reader.GetInt32(reader.GetOrdinal("idHabitacion"));

                RepositorioHabitacion repoHabitacion = new RepositorioHabitacion();
                Habitacion habitacion = repoHabitacion.getById(idHabitacion);
                habitaciones.Add(habitacion);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitaciones;
        }

        public Hotel getHotelByIdHabitacion(int id)
        {
            Hotel hotel = null;
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            sqlCommand.Parameters.AddWithValue("@idHabitacion", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idHotel FROM LOS_BORBOTONES.Habitacion AS HAB WHERE HAB.idHabitacion = @idHabitacion";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {

                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));

                RepositorioHotel repoHotel = new RepositorioHotel();
                hotel = repoHotel.getById(idHotel);

            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return hotel;
        }

        public TipoHabitacion getTipoHabitacionByIdHabitacion(int id)
        {
            TipoHabitacion tipoHabitacion = null;
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            sqlCommand.Parameters.AddWithValue("@idHabitacion", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idTipoHabitacion FROM LOS_BORBOTONES.Habitacion AS HAB WHERE HAB.idHabitacion = @idHabitacion";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {

                int idTipoHab = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));

                RepositorioTipoHabitacion repositorioTipoHabitacion = new RepositorioTipoHabitacion();
                tipoHabitacion = repositorioTipoHabitacion.getById(idTipoHab);

            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return tipoHabitacion;
        }
    }
}
