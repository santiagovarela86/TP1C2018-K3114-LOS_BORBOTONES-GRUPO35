﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FrbaHotel.Excepciones;

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

            //Si no encuentro elemento con ese ID tiro una excepción
            if (nombre.Equals("")) throw new NoExisteIDException("No existe rol con el ID asociado");

            //Segunda Consulta
            sqlCommand.CommandText = @"
                
                SELECT f.idFuncionalidad, Descripcion
                FROM LOS_BORBOTONES.Funcionalidad_X_Rol fr 
                INNER JOIN LOS_BORBOTONES.Funcionalidad f ON f.idFuncionalidad = fr.idFuncionalidad
                WHERE fr.idRol = @idRol

            ";

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            //Colecto las funcionalidades
            while(reader.Read()){

                int idFuncionalidad = reader.GetInt32(reader.GetOrdinal("idFuncionalidad"));
                String descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                Funcionalidad funcionalidad = new Funcionalidad(idFuncionalidad, descripcion);

                funcionalidades.Add(funcionalidad);

            }

            sqlConnection.Close();

            //Armo el rol completo
            rol = new Rol(idRol, nombre, activo, funcionalidades);

            return rol;
        }

        override public List<Rol> getAll()
        {
            List<Rol> roles = new List<Rol>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idRol FROM LOS_BORBOTONES.Rol";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idRol"))));
            }

            sqlConnection.Close();

            return roles;
        }

        override public int create(Rol rol)
        {
            if (this.exists(rol))
            {
                //Error
            } else {
                //Creo un nuevo registro
            }

            throw new NotImplementedException();
        }

        override public void update(Rol rol)
        {
            if (this.exists(rol))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Rol rol)
        {
            if (this.exists(rol))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public Boolean exists(Rol rol)
        {
            int idRol = 0;
            String nombre = "";

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idRol", rol.getIdRol());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idRol FROM LOS_BORBOTONES.Rol WHERE idRol = @idRol";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idRol = reader.GetInt32(reader.GetOrdinal("idRol"));
            }

            sqlConnection.Close();

            sqlCommand.Parameters.AddWithValue("@Nombre", rol.getNombre());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT Nombre FROM LOS_BORBOTONES.Rol WHERE Nombre = @Nombre";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el Nombre coincide
            return idRol != 0 || rol.getNombre().Equals(nombre);
        }

        public Rol getByNombre(String nombre)
        {
            int idRol = 0;

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

            //Si no encuentro elemento con ese Nombre tiro una excepción
            if (idRol.Equals(0)) throw new NoExisteNombreException("No existe rol con el Nombre asociado");

            return getById(idRol);
        }

        public List<Rol> getByQuery(String nombreRol, KeyValuePair<String, Boolean> estado, Funcionalidad funcionalidad)
        {
            List<Rol> roles = new List<Rol>();
            String query = "SELECT r.idRol FROM LOS_BORBOTONES.Rol r";

            //Consulta SIN FILTRO
            if (nombreRol.Equals("") && estado.Key == null && funcionalidad == null)
            {
                roles = this.getAll();
            }
            else
            {
                //Consulta CON FILTROS
                //PREPARO TODO PARA HACER LA CONSULTA
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                //Booleano que uso para armar bien la consulta
                Boolean primerCriterioWhere = true;

                //Consulta por FUNCIONALIDAD
                //Va primero porque el JOIN va antes que el WHERE
                if (funcionalidad != null)
                {
                    sqlCommand.Parameters.AddWithValue("@Funcionalidad", funcionalidad.getDescripcion());
                    query = query + " INNER JOIN LOS_BORBOTONES.Funcionalidad_X_Rol fxr ON r.idRol = fxr.idRol INNER JOIN LOS_BORBOTONES.Funcionalidad f ON f.idFuncionalidad = fxr.idFuncionalidad WHERE f.Descripcion = @Funcionalidad";
                    primerCriterioWhere = false;
                }

                //AGREGO FILTRO NOMBRE
                if (!nombreRol.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE r.Nombre LIKE @Nombre";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND r.Nombre LIKE @Nombre";
                    }
                    sqlCommand.Parameters.AddWithValue("@Nombre", "%" + nombreRol + "%");
                }

                //AGREGO FILTRO ESTADO
                if (estado.Key != null)
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE r.Activo = @Estado";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND r.Activo = @Estado";
                    }
                    sqlCommand.Parameters.AddWithValue("@Estado", Convert.ToInt32(estado.Value));
                }

                //HAGO LA CONSULTA
                sqlCommand.CommandText = query;
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                //ARMAR ROLES
                while (reader.Read())
                {
                    roles.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idRol"))));
                }

                sqlConnection.Close();
            }

            return roles;
        }
    }
}
