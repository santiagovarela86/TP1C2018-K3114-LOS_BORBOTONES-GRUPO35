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
            //Elementos del Rol a devolver
            String nombre;
            Boolean activo;
            Rol rol;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            //Configuraciones de la consulta
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseLocal"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            //Primera Consulta
            sqlCommand.CommandText = "SELECT * FROM Rol WHERE id = @Id";
                     
            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            activo = reader.GetBoolean(reader.GetOrdinal("Activo"));

            //Segunda Consulta
            sqlCommand.CommandText = @"
                
                SELECT f.idFuncionalidad, Descripcion
                FROM LOS_BORBOTONES.Funcionalidad_X_Rol fr 
                INNER JOIN LOS_BORBOTONES.Funcionalidad f ON f.idFuncionalidad = fr.idFuncionalidad
                WHERE fr.idRol = @Id

            ";

            reader = sqlCommand.ExecuteReader();

            while(reader.Read()){

                int idFuncionalidad = reader.GetInt32(reader.GetOrdinal("idFuncionalidad"));
                String descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                Funcionalidad funcionalidad = new Funcionalidad(idFuncionalidad, descripcion);

                funcionalidades.Add(funcionalidad);

            }

            sqlConnection.Close();

            rol = new Rol(id, nombre, activo, funcionalidades);

            return rol;
        }

        override public List<Rol> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
