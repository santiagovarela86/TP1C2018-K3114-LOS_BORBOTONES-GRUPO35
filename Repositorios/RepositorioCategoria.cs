using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrbaHotel.Modelo;

namespace FrbaHotel.Repositorios
{
    class RepositorioCategoria : Repositorio<Categoria>
    {
        public override void create(Categoria t)
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

        public override Categoria getById(int id)
        {
            throw new NotImplementedException();
        }

        public override void update(Categoria t)
        {
            throw new NotImplementedException();
        }

        public Categoria getByHotelId(int id) {

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            Categoria categoria=null;

            sqlCommand.Parameters.AddWithValue("@idHotel", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idCategoria,Estrellas,RecargaEstrellas FROM LOS_BORBOTONES.Categoria AS CAT WHERE CAT.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                int estrellas = reader.GetInt32(reader.GetOrdinal("Estrellas"));
                int recargaEstrellas = reader.GetInt32(reader.GetOrdinal("RecargaEstrellas"));
                int idCategoria = reader.GetInt32(reader.GetOrdinal("RecargaEstrellas"));
                categoria = new Categoria(idCategoria, estrellas, recargaEstrellas);
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return categoria;
        }
    }
}
