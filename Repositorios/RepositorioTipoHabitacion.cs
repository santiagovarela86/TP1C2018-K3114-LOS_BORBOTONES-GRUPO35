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
    class RepositorioTipoHabitacion : Repositorio<TipoHabitacion>
    {
        public override int create(TipoHabitacion t)
        {
            throw new NotImplementedException();
        }

        public override void delete(TipoHabitacion t)
        {
            throw new NotImplementedException();
        }

        public override bool exists(TipoHabitacion t)
        {
            throw new NotImplementedException();
        }

        public override List<TipoHabitacion> getAll()
        {
            throw new NotImplementedException();
        }

        public override TipoHabitacion getById(int id)
        {

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            TipoHabitacion tipoHabitacion = null;

            sqlCommand.Parameters.AddWithValue("@idTipoHabitacion", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idTipoHabitacion,Codigo,Porcentual,Descripcion FROM LOS_BORBOTONES.TipoHabitacion AS TIPOHAB WHERE TIPOHAB.idTipoHabitacion = @idTipoHabitacion";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idTipoHabitacion = reader.GetInt32(reader.GetOrdinal("idTipoHabitacion"));
                int codigo = reader.GetInt32(reader.GetOrdinal("Codigo"));
                float porcentual = reader.GetFloat(reader.GetOrdinal("Porcentual"));
                String descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));

                tipoHabitacion= new TipoHabitacion(idTipoHabitacion,codigo,porcentual,descripcion);
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return tipoHabitacion;
        }

        public override void update(TipoHabitacion t)
        {
            throw new NotImplementedException();
        }
    }
}
