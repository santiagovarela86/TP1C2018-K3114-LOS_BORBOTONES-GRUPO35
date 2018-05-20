using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel.Repositorios
{
    class RepositorioRol : Repositorio<Rol>
    {
        override public Rol getById(int id)
        {
            String nombre;
            Boolean activo;
            Rol rol;
            List<Funcionalidad> funcionalidades;

            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseLocal"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //getRolById.CommandText = "SELECT * FROM Rol WHERE id=@id";
            sqlCommand.CommandText = @"
                
                SELECT f.idFuncionalidad, Descripcion
                FROM Funcionalidad_X_Rol fr 
                INNER JOIN Funcionalidad f ON f.idFuncionalidad = fr.idFuncionalidad
                WHERE fr.idRol = @Id

            ";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();
            // Data is accessible through the DataReader object here.

            nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            activo = reader.GetBoolean(reader.GetOrdinal("Activo"));
            rol = new Rol(id, nombre, activo, null);

            sqlConnection.Close();

            return rol;
        }

        override public List<Rol> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
