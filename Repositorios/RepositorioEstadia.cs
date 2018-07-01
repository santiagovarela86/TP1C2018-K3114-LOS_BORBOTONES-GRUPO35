﻿using FrbaHotel.Excepciones;
using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FrbaHotel.Repositorios
{
    public class RepositorioEstadia : Repositorio<Estadia>
    {
        override public Estadia getById(int idEstadia)
        {
            //Elementos de la Estadia a devolver
            Estadia estadia;

            decimal cantidadNoches = 0;
            Usuario usuarioCheckIn = null;
            Usuario usuarioCheckOut = null;
            DateTime fechaEntrada = new DateTime();
            DateTime fechaSalida = new DateTime();
            Boolean facturada = false;
            RepositorioUsuario repoUsuario = new RepositorioUsuario();
            
            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idEstadia", idEstadia);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Estadia WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                usuarioCheckIn = repoUsuario.getById(reader.GetInt32(reader.GetOrdinal("idUsuarioIn")));
                usuarioCheckOut = repoUsuario.getById(reader.GetInt32(reader.GetOrdinal("idUsuarioOut")));
                fechaEntrada = reader.GetDateTime(reader.GetOrdinal("FechaEntrada"));
                fechaSalida = reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                facturada = reader.GetBoolean(reader.GetOrdinal("Facturada"));
                cantidadNoches = reader.GetDecimal(reader.GetOrdinal("CantidadNoches"));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            //if (usuarioCheckIn.Equals(null)) throw new NoExisteIDException("No existe estadia con el ID asociado");

            //Armo la estadia completa
            estadia = new Estadia(idEstadia, usuarioCheckIn, usuarioCheckOut, fechaEntrada, fechaSalida, facturada,cantidadNoches);
            return estadia;
        }

        override public List<Estadia> getAll()
        {
            List<Estadia> estadias = new List<Estadia>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Estadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                estadias.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idEstadia"))));
            }

            sqlConnection.Close();

            return estadias;
        }
        public List<Consumible> getConsumiblesXIdEstadia(int idEstadia)
        {
            List<Consumible> consumiblesXEstadia = new List<Consumible>();
            RepositorioConsumibles repoConsumibles = new RepositorioConsumibles();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idEstadia", idEstadia);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idConsumible FROM LOS_BORBOTONES.Estadia_X_Consumible where idEstadia=@idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                consumiblesXEstadia.Add(repoConsumibles.getById(reader.GetInt32(reader.GetOrdinal("idConsumible"))));
            }

            sqlConnection.Close();

            return consumiblesXEstadia;
        }

        override public void delete(Estadia estadia)
        {
            if (this.exists(estadia))
            {
                //Error
            }
            else
            {
                //elimino registro
            }

            throw new System.NotImplementedException();
        }

        override public void update(Estadia estadia)
        {
            Estadia estadiaOriginal = this.getById(estadia.getIdEstadia());
            
            if (this.exists(estadia))
            {
                decimal cantNoches =0;
                //hago la cuenta de los dias que estuvo con la fecha de salida

                cantNoches = (decimal)(estadia.getFechaSalida() -estadiaOriginal.getFechaEntrada()).TotalDays;
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@UserOut", estadia.getUsuarioCheckOut().getIdUsuario());
                sqlCommand.Parameters.AddWithValue("@FecOut", estadia.getFechaSalida());
                sqlCommand.Parameters.AddWithValue("@idEstadia", estadia.getIdEstadia());
                sqlCommand.Parameters.AddWithValue("@CantNoches", cantNoches);

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    UPDATE LOS_BORBOTONES.Estadia
                    SET idUsuarioOut = @UserOut, FechaSalida = @FecOut, CantidadNoches=@CantNoches
                    WHERE idEstadia = @idEstadia;
                ");

                
                sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

                sqlCommand.CommandText = sqlBuilder.ToString();
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                sqlConnection.Close();
            }
            else
            {
                throw new NoExisteIDException("No existe la estadia que intenta actualizar");
            }
        }

        override public int create(Estadia estadia)
        {
            int idEstadia = 0;
            if (this.exists(estadia))
            {
                throw new ElementoYaExisteException("Ya existe la estadia que intenta crear");
            }
            else
            {
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;
                

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@FecIn", estadia.getFechaEntrada());
                sqlCommand.Parameters.AddWithValue("@FecOut", estadia.getFechaSalida());
                sqlCommand.Parameters.AddWithValue("@CantNoches", estadia.getCantidadNoches());
                sqlCommand.Parameters.AddWithValue("@Facturada", estadia.getFacturada());
                sqlCommand.Parameters.AddWithValue("@UserIn", estadia.getUsuarioCheckIn().getIdUsuario());
                sqlCommand.Parameters.AddWithValue("@UserOut", estadia.getUsuarioCheckOut().getIdUsuario());

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada,FechaSalida,CantidadNoches,Facturada,idUsuarioIn,idUsuarioOut)
                    OUTPUT INSERTED.idEstadia
                    VALUES(@FecIn, @FecOut, @CantNoches, @Facturada, @UserIn, @UserOut);

                    DECLARE @idEstadia int;
                    SET @idEstadia = SCOPE_IDENTITY();
                ");


                sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

                sqlCommand.CommandText = sqlBuilder.ToString();
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
                }

                sqlConnection.Close();
            }

            return idEstadia;
        }

        override public void bajaLogica(Estadia estadia)
        {
            throw new NotImplementedException();
        }

        override public Boolean exists(Estadia estadia)
        {
            int idEstadia = 0;
            
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idEstadia", estadia.getIdEstadia());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Estadia WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
            }

            sqlConnection.Close();
            
            //Devuelve verdadero si el ID coincide
            return idEstadia != 0;
        }
        //luego hacer algun getBy que vea especial y el getByQuery
        public void updateIn (Estadia estadia)
        {
            if (this.exists(estadia))
            {
                
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@UserIn", estadia.getUsuarioCheckIn().getIdUsuario());
                sqlCommand.Parameters.AddWithValue("@FecIn", estadia.getFechaEntrada());
                sqlCommand.Parameters.AddWithValue("@idEstadia", estadia.getIdEstadia());
                
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    UPDATE LOS_BORBOTONES.Estadia
                    SET idUsuarioIn = @UserIn, FechaEntrada = @FecIn
                    WHERE idEstadia = @idEstadia;
                ");


                sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

                sqlCommand.CommandText = sqlBuilder.ToString();
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                sqlConnection.Close();
            }
            else
            {
                throw new NoExisteIDException("No existe la estadia que intenta actualizar");
            }    
        }
        public void facturado(int idEstadia)
        {
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@idEstadia", idEstadia);
            
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    UPDATE LOS_BORBOTONES.Estadia
                    SET Facturada = 1
                    WHERE idEstadia = @idEstadia;
                ");


                sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

                sqlCommand.CommandText = sqlBuilder.ToString();
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                sqlConnection.Close();
            }

        public void updateEstadoFacturado(int idReserva)
        {
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.AddWithValue("@idReserva", idReserva);

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    UPDATE LOS_BORBOTONES.EstadoReserva
                    SET TipoEstado= 'RF', Descripcion='Reserva Facturada'
                    WHERE idReserva = @idReserva;
                ");


            sqlBuilder.Append(@"
                    COMMIT
                    END TRY

                    BEGIN CATCH
                    ROLLBACK
                    END CATCH
                ");

            sqlCommand.CommandText = sqlBuilder.ToString();
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }
    }
}

