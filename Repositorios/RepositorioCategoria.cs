using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrbaHotel.Modelo;
using FrbaHotel.Excepciones;

namespace FrbaHotel.Repositorios
{
    class RepositorioCategoria : Repositorio<Categoria>
    {
        public override int create(Categoria t)
        {
            throw new NotImplementedException();
        }

        public override void delete(Categoria t)
        {
            throw new NotImplementedException();
        }

        public override bool exists(Categoria t)
        {
            throw new NotImplementedException();
        }

        public override List<Categoria> getAll()
        {
            throw new NotImplementedException();
        }

        public override void update(Categoria categoria)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            
            sqlCommand.Parameters.AddWithValue("@estrellas", categoria.Estrellas);
            sqlCommand.Parameters.AddWithValue("@recargaEstrellas", categoria.RecargaEstrellas);
            sqlCommand.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UPDATE LOS_BORBOTONES.Categoria SET Pais= @estrellas, Ciudad= @recargaEstrellas," +
                "WHERE idCategoria= @idCategoria";

            sqlConnection.Open();

            //Checkear excepcion si no existe u ocurrio algun problema con el update

            //Cierro Primera Consulta
            sqlConnection.Close();
        }

        public override Categoria getById(int idCategoria) {

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            Categoria categoria = null;

            sqlCommand.Parameters.AddWithValue("@idCategoria", idCategoria);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Categoria WHERE idCategoria = @idCategoria";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int estrellas = reader.GetInt32(reader.GetOrdinal("Estrellas"));
                decimal recargaEstrellas = reader.GetDecimal(reader.GetOrdinal("RecargaEstrellas"));
                categoria = new Categoria(idCategoria, estrellas, recargaEstrellas);
            }
            else
            {
                //Si no encuentro elemento con ese ID tiro una excepción
                throw new NoExisteIDException("No existe categoria con el ID asociado");
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            return categoria;
        }
    }
}
