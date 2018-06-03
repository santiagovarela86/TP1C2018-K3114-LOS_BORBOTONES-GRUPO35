
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrbaHotel.Modelo;

namespace FrbaHotel.Repositorios
{
    class RepositorioDireccion : Repositorio<Direccion>
    {
        public override void create(Direccion t)
        {
            throw new System.NotImplementedException();
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

        public override Direccion getById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void update(Direccion t)
        {
            throw new System.NotImplementedException();
        }

        public Direccion getByHotelId(int id)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            Direccion direccion = null;

            sqlCommand.Parameters.AddWithValue("@idHotel", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idDireccion,Pais,Ciudad,Calle,NumeroCalle,Piso,Depto FROM LOS_BORBOTONES.Direccion AS DIR WHERE DIR.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idDireccion = reader.GetInt32(reader.GetOrdinal("idDireccion"));
                String pais = reader.GetString(reader.GetOrdinal("Pais"));
                String ciudad = reader.GetString(reader.GetOrdinal("Ciudad"));
                String calle = reader.GetString(reader.GetOrdinal("calle"));
                int numeroCalle = reader.GetInt32(reader.GetOrdinal("NumeroCalle"));
                int  piso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String departamento = reader.GetString(reader.GetOrdinal("Depto"));

                direccion = new Direccion(idDireccion,null,pais,ciudad,calle,numeroCalle,piso,departamento);
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
            sqlCommand.CommandText = "SELECT idDireccion,Pais,Ciudad,Calle,NumeroCalle,Piso,Depto FROM LOS_BORBOTONES.Direccion AS DIR WHERE DIR.idIdentidad = @idIdentidad";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int idDireccion = reader.GetInt32(reader.GetOrdinal("idDireccion"));
                String pais = reader.GetString(reader.GetOrdinal("Pais"));
                String ciudad = reader.SafeGetString(reader.GetOrdinal("Ciudad"));
                String calle = reader.GetString(reader.GetOrdinal("calle"));
                int numeroCalle = reader.GetInt32(reader.GetOrdinal("NumeroCalle"));
                int piso = reader.GetInt32(reader.GetOrdinal("Piso"));
                String departamento = reader.GetString(reader.GetOrdinal("Depto"));
                direccion = new Direccion(idDireccion, null, pais, ciudad, calle, numeroCalle, piso, departamento);
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return direccion;
        }
 
    }
}
