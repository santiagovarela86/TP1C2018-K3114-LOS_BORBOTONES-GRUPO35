using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel.Repositorios
{
    public class RepositorioRol : Repositorio<Rol>
    {

        override public Rol getById(int idRol)
        {
            //Elementos del Rol a devolver
            String nombre = "";
            Boolean activo = false;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            Rol rol;

            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idRol", idRol);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Rol WHERE idRol = @idRol";
                     
            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                activo = reader.GetBoolean(reader.GetOrdinal("Activo"));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Segunda Consulta
            sqlCommand.CommandText = @"
                
                SELECT f.idFuncionalidad, Descripcion
                FROM LOS_BORBOTONES.Funcionalidad_X_Rol fr 
                INNER JOIN LOS_BORBOTONES.Funcionalidad f ON f.idFuncionalidad = fr.idFuncionalidad
                WHERE fr.idRol = @idRol

            ";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while(reader.Read()){

                int idFuncionalidad = reader.GetInt32(reader.GetOrdinal("idFuncionalidad"));
                String descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                Funcionalidad funcionalidad = new Funcionalidad(idFuncionalidad, descripcion);

                funcionalidades.Add(funcionalidad);

            }

            sqlConnection.Close();

            rol = new Rol(idRol, nombre, activo, funcionalidades);

            return rol;
        }

        override public List<Rol> getAll()
        {
            throw new NotImplementedException();
        }

        public Rol getByNombre(String nombre)
        {
            int idRol = 0;

            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idRol FROM LOS_BORBOTONES.Rol WHERE nombre = @Nombre";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idRol = reader.GetInt32(reader.GetOrdinal("idRol"));
            }        

            sqlConnection.Close();

            return getById(idRol);
        }
    }
}
