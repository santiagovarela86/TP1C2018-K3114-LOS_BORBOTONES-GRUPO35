
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrbaHotel.Modelo;

namespace FrbaHotel.Repositorios
{
    public class RepositorioDireccion : Repositorio<Direccion>
    {
        public override int create(Direccion direccion)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            int idDireccionInserted = 0;

            sqlCommand.Parameters.AddWithValue("@pais", direccion.Pais);
            sqlCommand.Parameters.AddWithValue("@ciudad", direccion.Ciudad);
            sqlCommand.Parameters.AddWithValue("@calle", direccion.Calle);
            sqlCommand.Parameters.AddWithValue("@numeroCalle", direccion.NumeroCalle);
            sqlCommand.Parameters.AddWithValue("@piso", direccion.Piso);
            sqlCommand.Parameters.AddWithValue("@departamento", direccion.Departamento);
            sqlCommand.Parameters.AddWithValue("@idDireccion", direccion.IdDireccion);

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO  LOS_BORBOTONES.Direccion( Pais,Ciudad,Calle,NumeroCalle,Piso,Depto) OUTPUT INSERTED.idDireccion VALUES (@pais,@ciudad,@calle,@numeroCalle,@piso,@departamento);";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read()){
                idDireccionInserted = reader.GetInt32(reader.GetOrdinal("idDireccion"));
            }
            
            sqlConnection.Close();
            return idDireccionInserted;
        }

        public override void delete(Direccion t)
        {
            throw new System.NotImplementedException();
        }

        public override bool exists(Direccion t)
        {
            throw new System.NotImplementedException();
        }

        public override List<Direccion> getAll()
        {
            throw new System.NotImplementedException();
        }

        public override void update(Direccion direccion)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;


            sqlCommand.Parameters.AddWithValue("@pais", direccion.Pais);
            sqlCommand.Parameters.AddWithValue("@ciudad", direccion.Ciudad);
            sqlCommand.Parameters.AddWithValue("@calle", direccion.Calle);
            sqlCommand.Parameters.AddWithValue("@numeroCalle", direccion.NumeroCalle);
            sqlCommand.Parameters.AddWithValue("@piso", direccion.Piso);
            sqlCommand.Parameters.AddWithValue("@departamento", direccion.Departamento);
            sqlCommand.Parameters.AddWithValue("@idDireccion", direccion.IdDireccion);

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UPDATE LOS_BORBOTONES.Direccion SET Pais= @pais, Ciudad= @ciudad ," +
                " Calle=@calle, NumeroCalle= @numeroCalle, Piso=@piso, Departamento=@departamento" +
                "WHERE idDireccion= @idDireccion";

            sqlConnection.Open();

            //Checkear excepcion si no existe u ocurrio algun problema con el update

            //Cierro Primera Consulta
            sqlConnection.Close();
        }

        public override Direccion getById(int idDireccion)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            Direccion direccion = null;

            sqlCommand.Parameters.AddWithValue("@idDireccion", idDireccion);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Direccion direccion WHERE direccion.idDireccion = @idDireccion";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                String pais = reader.GetString(reader.GetOrdinal("Pais"));
                String ciudad = reader.SafeGetString(reader.GetOrdinal("Ciudad"));
                String calle = reader.GetString(reader.GetOrdinal("calle"));
                int numeroCalle = reader.GetInt32(reader.GetOrdinal("NumeroCalle"));
                int piso = reader.SafeGetInt32(reader.GetOrdinal("Piso"));
                String departamento = reader.SafeGetString(reader.GetOrdinal("Depto"));

                direccion = new Direccion(idDireccion, pais, ciudad, calle, numeroCalle, piso, departamento);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return direccion;
        }

        public Direccion getByIdIdentidad(int id)
        {

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            Direccion direccion = null;

            sqlCommand.Parameters.AddWithValue("@idIdentidad", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Direccion AS DIR WHERE DIR.idIdentidad = @idIdentidad";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idDireccion = reader.GetInt32(reader.GetOrdinal("idDireccion"));
                String pais = reader.GetString(reader.GetOrdinal("Pais"));
                String ciudad = reader.SafeGetString(reader.GetOrdinal("Ciudad"));
                String calle = reader.GetString(reader.GetOrdinal("calle"));
                int numeroCalle = reader.GetInt32(reader.GetOrdinal("NumeroCalle"));
                int piso = reader.SafeGetInt32(reader.GetOrdinal("Piso"));
                String departamento = reader.SafeGetString(reader.GetOrdinal("Depto"));
                direccion = new Direccion(idDireccion, pais, ciudad, calle, numeroCalle, piso, departamento);
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return direccion;
        }
 
    }
}
