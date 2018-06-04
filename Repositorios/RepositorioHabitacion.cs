using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel.Repositorios
{
    class RepositorioHabitacion : Repositorio<Habitacion>
    {

        private RepositorioTipoHabitacion repositorioTipoHabitacion;

        public override int create(Habitacion t)
        {
            throw new NotImplementedException();
        }

        public override void delete(Habitacion t)
        {
            throw new NotImplementedException();
        }

        public override bool exists(Habitacion t)
        {
            throw new NotImplementedException();
        }

        public override List<Habitacion> getAll()
        {
            throw new NotImplementedException();
        }

        public override Habitacion getById(int id)
        {
            throw new NotImplementedException();
        }

        public override void update(Habitacion t)
        {

        }


        public List<Habitacion> getByHotelId(int id){

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            List<Habitacion> habitaciones = new List<Habitacion>();

            sqlCommand.Parameters.AddWithValue("@idHotel", id);
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
                TipoHabitacion tipoHabitacion = repositorioTipoHabitacion.getById(idTipoHabitacion);

                habitaciones.Add(new Habitacion(idHabitacion,tipoHabitacion,activa,numero,piso,ubicacion));
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return habitaciones;
        }
    }
}
