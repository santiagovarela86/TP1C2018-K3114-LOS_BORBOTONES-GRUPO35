using System.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FrbaHotel.Modelo;
using FrbaHotel.AbmHotel.request;
using FrbaHotel.Excepciones;

namespace FrbaHotel.Repositorios {

    public class RepositorioHotel : Repositorio<Hotel>
    {
        RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
        RepositorioRegimen repositorioRegimen = new RepositorioRegimen();
        RepositorioCierreTemporal repositorioCierreTemporal = new RepositorioCierreTemporal();
        RepositorioDireccion repositorioDireccion = new RepositorioDireccion();



        public int crearBajaTemporal(BajaTemporal request){
            Hotel hotel = getById(request.IdHotel);
            List<Reserva> reservas = hotel.getReservas();
            foreach(var reserva in reservas){
                bool overlap = reserva.FechaDesde < request.FechaHasta && request.FechaDesde < reserva.FechaHasta;
                if (overlap){
                    throw new RequestInvalidoException("No es posible dar de baja temporal el hotel. Existen reservas para la fecha la cual se quiere dar de baja el hotel");
                }
                           }
            CierreTemporal cierreTemporal = new CierreTemporal(0, request.FechaDesde, request.FechaHasta, request.Descripcion, request.IdHotel);
            return repositorioCierreTemporal.create(cierreTemporal);
        }

        public List<Hotel> searchHotel(SearchHotelRequest request) {

            List<Hotel> hoteles = new List<Hotel>();
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT DISTINCT(HOT.idHotel),HOT.Nombre,HOT.Mail,HOT.Telefono,HOT.FechaInicioActividades,HOT.idCategoria,HOT.idDireccion FROM LOS_BORBOTONES.Hotel AS HOT" +
                " JOIN LOS_BORBOTONES.Categoria AS CAT ON CAT.idCategoria= HOT.idCategoria" +
                " JOIN LOS_BORBOTONES.Direccion AS DIR ON DIR.idDireccion = HOT.idDireccion" + getCondiciones(request,sqlCommand) + ";";
            


            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                String nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                String mail = reader.SafeGetString(reader.GetOrdinal("Mail"));
                String telefono = reader.SafeGetString(reader.GetOrdinal("Telefono"));
                DateTime fechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicioActividades"));
                int idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria"));
                int idDireccion = reader.GetInt32(reader.GetOrdinal("idDireccion"));

                Categoria categoria = repositorioCategoria.getById(idCategoria);

                Direccion direccion = repositorioDireccion.getById(idDireccion);

                List<Regimen> regimenes = repositorioRegimen.getByIdHotel(idHotel);

                List<CierreTemporal> cierresTemporales = repositorioCierreTemporal.getByHotelId(idHotel);

                Hotel hotel = new Hotel(idHotel, categoria, direccion, nombre, mail, telefono,
                                fechaInicio, null, regimenes, null, cierresTemporales);
                hoteles.Add(hotel);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();
            return hoteles;

        }


        private String getCondiciones(SearchHotelRequest request, SqlCommand sqlCommand)
        {

            List<String> condiciones = new List<String>();
            if (request.NombreHotel != null)
            {
                condiciones.Add("HOT.Nombre LIKE @hotNombreHotel + '%'");
                sqlCommand.Parameters.AddWithValue("@hotNombreHotel", request.NombreHotel);

            }
            if (request.Ciudad != null) {
                condiciones.Add("DIR.Ciudad=@dirCiudad");
                sqlCommand.Parameters.AddWithValue("@dirCiudad", request.Ciudad);

            }
            if (request.Pais != null) {
                condiciones.Add("DIR.Pais=@dirPais");
                sqlCommand.Parameters.AddWithValue("@dirPais", request.Pais);
            }
            if (request.Estrellas != null) {
                condiciones.Add("CAT.Estrellas=@catEstrellas");
                sqlCommand.Parameters.AddWithValue("@catEstrellas", request.Estrellas);
            }
            return " WHERE " + string.Join(" AND ", condiciones.ToArray());

        }
        public override int create(Hotel hotel)
        {

            int idHotel = 0;

            String CREATE_STATEMENT = "BEGIN TRANSACTION" +
                                        " BEGIN TRY" +
                                        " DECLARE @idDireccion int; " +
                                        "DECLARE @idCategoria int;" +
                                        "INSERT INTO LOS_BORBOTONES.Categoria(Estrellas, RecargaEstrellas) VALUES(@catEstrellas,@catRecargaEstrellas);" +
                                        "SET @idCategoria = SCOPE_IDENTITY();" +
                                        "INSERT INTO LOS_BORBOTONES.Direccion(Pais, Ciudad, Calle, NumeroCalle) VALUES(@dirPais,@dirCiudad,@dirCalle, @dirNumeroCalle);" +
                                        "SET @idDireccion = SCOPE_IDENTITY();" +
                                        "INSERT INTO LOS_BORBOTONES.Hotel(idCategoria, Nombre, Mail, Telefono, FechaInicioActividades, idDireccion) OUTPUT INSERTED.idHotel " +
                                        "VALUES(@idCategoria,@hotNombre, @hotMail, @hotTelefono, @hotFechaIniciaActividades, @idDireccion); " +
                                        "COMMIT TRANSACTION " +
                                        "END TRY " +
                                        "BEGIN CATCH " +
                                        "RAISERROR('ERROR TRYING TO CREATE HOTEL', 16, 1) " +
                                        "ROLLBACK TRANSACTION " +
                                        "END CATCH";

            //TO DO migrar inserts ajenos de hotel a su respectivo repositorio
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            
      
            //HOTEL
            sqlCommand.Parameters.AddWithValue("@hotNombre", hotel.getNombre());
            sqlCommand.Parameters.AddWithValue("@hotMail", hotel.getMail());
            sqlCommand.Parameters.AddWithValue("@hotTelefono", hotel.getTelefono());
            sqlCommand.Parameters.AddWithValue("@hotFechaIniciaActividades", hotel.getFechaInicioActividades());
            //CATEGORIA
            sqlCommand.Parameters.AddWithValue("@catEstrellas", hotel.getCategoria().Estrellas);
            sqlCommand.Parameters.AddWithValue("@catRecargaEstrellas", hotel.getCategoria().RecargaEstrellas);
            //DIRECCION
            sqlCommand.Parameters.AddWithValue("@dirPais", hotel.getDireccion().getPais());
            sqlCommand.Parameters.AddWithValue("@dirCiudad", hotel.getDireccion().getCiudad());
            sqlCommand.Parameters.AddWithValue("@dirCalle", hotel.getDireccion().getCalle());
            sqlCommand.Parameters.AddWithValue("@dirNumeroCalle", hotel.getDireccion().getNumeroCalle());

            sqlCommand.CommandText = CREATE_STATEMENT;

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();
            if (reader.Read()){
                idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
            }
                sqlConnection.Close();
            return idHotel;
            
        }

    

        public override void delete(Hotel t)
        {
            throw new System.NotImplementedException();
        }

        public override bool exists(Hotel t)
        {
            throw new System.NotImplementedException();
        }

        public override List<Hotel> getAll()
        {
            List<Hotel> hoteles = new List<Hotel>();
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            Hotel hotel = null;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT idHotel,Nombre,Mail,Telefono,FechaInicioActividades,idCategoria,idDireccion FROM LOS_BORBOTONES.Hotel AS HOT;";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                String nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                String mail = reader.SafeGetString(reader.GetOrdinal("Mail"));
                String telefono = reader.SafeGetString(reader.GetOrdinal("Telefono"));
                DateTime fechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicioActividades"));
                int idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria"));
                int idDireccion = reader.GetInt32(reader.GetOrdinal("idDireccion"));

                Categoria categoria = repositorioCategoria.getById(idCategoria);

                Direccion direccion = repositorioDireccion.getById(idDireccion);

                List<Regimen> regimenes = repositorioRegimen.getByIdHotel(idHotel);

                //List<CierreTemporal> cierresTemporales = repositorioCierreTemporal.getByHotelId(id);

                //List<Habitacion> habitaciones = repositorioHabitacion.getByHotelId(id);

                //List<Reserva> reservas = null;  //TO DO FETCH  RESERVAS USANDO SU RESPECTIVO REPOSITORIO PASANDO EL ID DE HOTEL

                hotel = new Hotel(idHotel, categoria, direccion, nombre, mail, telefono,
                                fechaInicio, null, regimenes, null, null);
                hoteles.Add(hotel);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();


            return hoteles;
        }

        public override Hotel getById(int id)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            Hotel hotel=null;
            sqlCommand.Parameters.AddWithValue("@idHotel", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT idHotel,Nombre,Mail,Telefono,FechaInicioActividades,idCategoria,idDireccion FROM LOS_BORBOTONES.Hotel AS HOT WHERE HOT.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                String nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                String mail = reader.SafeGetString(reader.GetOrdinal("Mail"));
                String telefono = reader.SafeGetString(reader.GetOrdinal("Telefono"));
                DateTime fechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicioActividades"));
                int idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria"));
                int idDireccion = reader.GetInt32(reader.GetOrdinal("idDireccion"));

                Categoria categoria = repositorioCategoria.getById(idCategoria);

                Direccion direccion = repositorioDireccion.getById(idDireccion);

                List<Regimen> regimenes = repositorioRegimen.getByIdHotel(id);

                List<CierreTemporal> cierresTemporales = repositorioCierreTemporal.getByHotelId(id);

                //List<Habitacion> habitaciones = repositorioHabitacion.getByHotelId(id);

                //List<Reserva> reservas = null;  //TO DO FETCH  RESERVAS USANDO SU RESPECTIVO REPOSITORIO PASANDO EL ID DE HOTEL

                hotel = new Hotel(idHotel, categoria, direccion, nombre, mail, telefono,
                                fechaInicio, null, regimenes, null, cierresTemporales);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();


            return hotel;
        }

        public override void update(Hotel hotel)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            Direccion direccion = hotel.Direccion;
            Categoria categoria = hotel.Categoria;

            //HOTEL
            sqlCommand.Parameters.AddWithValue("@hotidHotel", hotel.IdHotel);
            sqlCommand.Parameters.AddWithValue("@hotnombre", hotel.Nombre);
            sqlCommand.Parameters.AddWithValue("@hotmail", hotel.Mail);
            sqlCommand.Parameters.AddWithValue("@hottelefono", hotel.Telefono);
            sqlCommand.Parameters.AddWithValue("@hotfechaInicioActividades", hotel.FechaInicioActividades);



            //DIRECCION
            sqlCommand.Parameters.AddWithValue("@dirpais", direccion.Pais);
            sqlCommand.Parameters.AddWithValue("@dirciudad", direccion.Ciudad);
            sqlCommand.Parameters.AddWithValue("@dircalle", direccion.Calle);
            sqlCommand.Parameters.AddWithValue("@dirnumeroCalle", direccion.NumeroCalle);
            sqlCommand.Parameters.AddWithValue("@dirpiso", direccion.Piso);
            sqlCommand.Parameters.AddWithValue("@dirdepartamento", direccion.Departamento);

            //CATEGORIA
            sqlCommand.Parameters.AddWithValue("@catestrellas", categoria.Estrellas);
            sqlCommand.Parameters.AddWithValue("@catrecargaEstrellas", categoria.RecargaEstrellas);

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UPDATE LOS_BORBOTONES.Hotel AS HOT " +
                "JOIN LOS_BORBOTONES.Direccion AS DIR ON DIR.idDireccion = HOT.idDireccion" +
                "JOIN LOS_BORBOTONES.Categoria AS CAT ON CAT.idCategoria = HOT.idCategoria" +
                "SET HOT.Nombre= @hotnombre, HOT.Mail= @hotmail, HOT.Telefono= @hottelefono, HOT.FechaInicioActividades= @hotfechaInicioActividades," +
                "DIR.Pais= @dirpais, DIR.Ciudad= @dirciudad, DIR.Calle=@dircalle, DIR.NumeroCalle= @dirnumeroCalle," +
                "DIR.Piso=@dirpiso, DIR.Departamento=@dirdepartamento," +
                "CAT.Estrellas=@catestrellas, CAT.RecargaEstrellas=@catrecargaEstrellas" +
                "WHERE HOT.idHotel= @hotidHotel";

            sqlConnection.Open();

            //Checkear excepcion si no existe u ocurrio algun problema con el update

            //Cierro Primera Consulta
            sqlConnection.Close();
        }
    }
}

