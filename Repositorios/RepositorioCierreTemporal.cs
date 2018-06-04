using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel.Repositorios
{
    class RepositorioCierreTemporal : Repositorio<CierreTemporal>
    {
        public override int create(CierreTemporal t)
        {
            throw new NotImplementedException();
        }

        public override void delete(CierreTemporal t)
        {
            throw new NotImplementedException();
        }

        public override bool exists(CierreTemporal t)
        {
            throw new NotImplementedException();
        }

        public override List<CierreTemporal> getAll()
        {
            throw new NotImplementedException();
        }

        public override CierreTemporal getById(int id)
        {
            throw new NotImplementedException();
        }

        public override void update(CierreTemporal t)
        {
            throw new NotImplementedException();
        }

        public List<CierreTemporal> getByHotelId(int id){

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            List<CierreTemporal> cierresTemporales = new List<CierreTemporal>();


            sqlCommand.Parameters.AddWithValue("@idHotel", id);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idCierreTemporal,FechaInicio,FechaFin,Descripcion FROM LOS_BORBOTONES.CierreTemporal AS CIERRE WHERE CIERRE.idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idCierreTemporal = reader.GetInt32(reader.GetOrdinal("idCierreTemporal"));
                DateTime fechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                DateTime fechaFin = reader.GetDateTime(reader.GetOrdinal("FechaFin"));
                String descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));

                cierresTemporales.Add(new CierreTemporal(idCierreTemporal, fechaInicio, fechaFin, descripcion));
            }
            //Cierro Primera Consulta
            sqlConnection.Close();

            return cierresTemporales;

        }
    }
}
