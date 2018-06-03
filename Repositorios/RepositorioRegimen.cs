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
    class RepositorioRegimen : Repositorio<Regimen>
    {
        //NO SE VA A HACER ABM DEL REGIMEN POR LO QUE SOLO HABRIA QUE HACER METODOS DE LECTURA
        public override void create(Regimen t)
        {
            throw new NotImplementedException();
        }

        public override void delete(Regimen t)
        {
            throw new NotImplementedException();
        }

        public override bool exists(Regimen t)
        {
            throw new NotImplementedException();
        }

        public override List<Regimen> getAll()
        {
            throw new NotImplementedException();
        }

        public override Regimen getById(int id)
        {
            throw new NotImplementedException();
        }

        public override void update(Regimen t)
        {
            throw new NotImplementedException();
        }
        
        public List<Regimen> getByIdHotel(int idHotel){

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            List<Regimen> regimenes = new List<Regimen>() ;

            sqlCommand.Parameters.AddWithValue("@idHotel", idHotel);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idRegimen,Codigo,Descripcion,Precio,Estado FROM LOS_BORBOTONES.Regimen AS REG WHERE REG.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {  
                int idRegimen = reader.GetInt32(reader.GetOrdinal("idRegimen"));
                int codigo = reader.GetInt32(reader.GetOrdinal("Codigo"));
                String descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                float precio = reader.GetFloat(reader.GetOrdinal("Precio"));
                String estado = reader.GetString(reader.GetOrdinal("Estado"));

                regimenes.Add(new Regimen(idRegimen, codigo, descripcion, precio, estado));
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return regimenes;
        }
    }
}

