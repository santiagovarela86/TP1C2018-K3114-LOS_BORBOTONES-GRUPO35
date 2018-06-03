using System.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FrbaHotel.Modelo;

namespace FrbaHotel.Repositorios {





    public class RepositorioHotel : Repositorio<Hotel>
    {

        private RepositorioCategoria repositorioCategoria;
        private RepositorioDireccion repositorioDireccion;
        private RepositorioRegimen repositorioRegimen;
        private RepositorioCierreTemporal repositorioCierreTemporal;
        private RepositorioHabitacion repositorioHabitacion;

        public override void create(Hotel hotel)
        {
            //TO DO migrar inserts ajenos de hotel a su respectivo repositorio
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            //SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@Estrellas", hotel.getCategoria().Estrellas);
            sqlCommand.Parameters.AddWithValue("@RecargaEstrellas", hotel.getCategoria().RecargaEstrellas);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO LOS_BORBOTONES.Categoria (Estrellas,RecargaEstrellas)  output INSERTED.ID VALUES (@Estrellas,@RecargaEstrellas)";

            sqlConnection.Open();

            int categoriaInsertadaId = (int)sqlCommand.ExecuteScalar();
            
            sqlConnection.Close();

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Pais", hotel.getDireccion().getPais());
            sqlCommand.Parameters.AddWithValue("@Ciudad", hotel.getDireccion().getCiudad());
            sqlCommand.Parameters.AddWithValue("@Calle", hotel.getDireccion().getCalle());
            sqlCommand.Parameters.AddWithValue("@NumeroCalle", hotel.getDireccion().getNumeroCalle());

            sqlCommand.CommandText = "INSERT INTO LOS_BORBOTONES.Direccion (Pais,Ciudad,Calle,NumeroCalle)  output INSERTED.ID VALUES (@Pais,@Ciudad,@Calle,@NumeroCalle)";

            sqlConnection.Open();

            int direccionInsertadaId = (int)sqlCommand.ExecuteScalar();
            
            sqlConnection.Close();

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@idCategoria", categoriaInsertadaId);
            sqlCommand.Parameters.AddWithValue("@Nombre", hotel.getNombre());
            sqlCommand.Parameters.AddWithValue("@Mail", hotel.getMail());
            sqlCommand.Parameters.AddWithValue("@Telefono", hotel.getTelefono());
            sqlCommand.Parameters.AddWithValue("@FechaIniciaActividades", hotel.getFechaInicioActividades());
            sqlCommand.Parameters.AddWithValue("@idDireccion", direccionInsertadaId);

            sqlCommand.CommandText = "INSERT INTO LOS_BORBOTONES.Hotel (idCategoria,Nombre,Mail,Telefono,FechaIniciaActividades,idDireccion)" +
                " VALUES (@idCategoria,@Nombre,@Mail,@Telefono,@FechaIniciaActividades,@idDireccion)";


            sqlConnection.Open();

            sqlConnection.Close();

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
            throw new System.NotImplementedException();
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
                "SELECT idHotel,Nombre,Mail,Telefono,FechaInicioActividad FROM LOS_BORBOTONES.Hotel AS HOT WHERE HOT.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idHotel= reader.GetInt32(reader.GetOrdinal("idHotel"));
                String nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                String mail = reader.GetString(reader.GetOrdinal("Mail"));
                String telefono = reader.GetString(reader.GetOrdinal("Telefono"));
                DateTime fechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicioActividad"));

                Categoria categoria = repositorioCategoria.getByHotelId(id);
                //Direccion direccion = repositorioDireccion.getByIdHotel(id);
                List<Regimen> regimenes = repositorioRegimen.getByHotelId(id, hotel);
                List<CierreTemporal> cierresTemporales = repositorioCierreTemporal.getByHotelId(id);
                List<Habitacion> habitaciones = repositorioHabitacion.getByHotelId(id);
                List<Reserva> reservas = null;  //TO DO FETCH  RESERVAS USANDO SU RESPECTIVO REPOSITORIO PASANDO EL ID DE HOTEL

                hotel = new Hotel(idHotel, categoria, null, nombre, mail, telefono,
                                fechaInicio, reservas, regimenes, habitaciones, cierresTemporales);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();


            return hotel;
        }

        public override void update(Hotel t)
        {
            throw new System.NotImplementedException();
        }
    }
}

