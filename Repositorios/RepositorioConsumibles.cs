using FrbaHotel.Excepciones;
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
    public class RepositorioConsumibles : Repositorio<Consumible>
    {
        override public Consumible getById(int idConsumible)
        {
            //Elementos del Consumible a devolver
            Consumible consumible;
            int codigo = 0;
            String descripcion = "";
            float precio = 0;

            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idConsumible", idConsumible);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Consumible WHERE idConsumible = @idConsumible";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                codigo = (int)reader.GetDecimal(reader.GetOrdinal("Codigo"));
                descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                precio = (float)reader.GetDecimal(reader.GetOrdinal("Precio"));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (codigo==0) throw new NoExisteIDException("No existe consumible con el ID asociado");

            //Armo el consumible completo
            consumible = new Consumible(idConsumible, codigo, descripcion, precio);

            return consumible;
        }

        override public List<Consumible> getAll()
        {
            List<Consumible> consumibles = new List<Consumible>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idConsumible FROM LOS_BORBOTONES.Consumible";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                consumibles.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idConsumible"))));
            }

            sqlConnection.Close();

            return consumibles;
        }
        override public int create(Consumible consumible)
        {
            //dar de alta y antes de darlo validar del lado interfaz si quiere cambiar algo
            int idConsumible = 0;
            if (this.exists(consumible))
            {
                //aca valido que el codigo sea unico y el id distinto a 0
                throw new ElementoYaExisteException("Ya existe el consumible que intenta crear");
            }
            else
            {
                //creo el nuevo consumible
                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

               
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@Code", consumible.getCodigo());
                sqlCommand.Parameters.AddWithValue("@Desc", consumible.getDescripcion());
                sqlCommand.Parameters.AddWithValue("@Price", consumible.getPrecio());


                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO LOS_BORBOTONES.Consumible(Codigo,Descripcion,Precio)
                    OUTPUT INSERTED.idConsumible
                    VALUES(@Code,@Desc,@Price);

                    DECLARE @idConsumible int;
                    SET @idConsumible = SCOPE_IDENTITY();
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
                    idConsumible = reader.GetInt32(reader.GetOrdinal("idConsumible"));
                }

                sqlConnection.Close();
            }

            return idConsumible;
     
        }
         public int registrar(Consumible consumible)
        {
                int consRegistrado=0;

                String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                SqlDataReader reader;

            
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@IdConsumible", consumible.getIdConsumible());
                sqlCommand.Parameters.AddWithValue("@IdEstadia", consumible.getIdEstadia());

                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO LOS_BORBOTONES.Estadia_X_Consumible(idEstadia,idConsumible)
                    OUTPUT INSERTED.idConsumible
                    VALUES(@IdEstadia,@IdConsumible);

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
                    consRegistrado = reader.GetInt32(reader.GetOrdinal("idConsumible"));
                }

                sqlConnection.Close();
                return consRegistrado;
         }

        

        override public void update(Consumible consumible)
        {
            throw new NotImplementedException();
        }

        override public void delete(Consumible consumible)
        {
            throw new NotImplementedException();
        }
        public override Boolean exists(Consumible consumible)
        {

            int idConsumible = 0;
            int codigo = 0;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idConsumible", consumible.getIdConsumible());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idConsumible FROM LOS_BORBOTONES.Consumible WHERE idConsumible = @idConsumible";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idConsumible = reader.GetInt32(reader.GetOrdinal("idConsumible"));
            }

            sqlConnection.Close();

            sqlCommand.Parameters.AddWithValue("@Code", consumible.getCodigo());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT codigo FROM LOS_BORBOTONES.Consumible WHERE codigo = @Code";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                codigo = (int)reader.GetDecimal(reader.GetOrdinal("Codigo"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el username coincide
            return idConsumible != 0 || codigo != 0;
        }
        override public void bajaLogica(Consumible consumible)
        {
            throw new NotImplementedException();
        }



        public List<Consumible> getByQuery(int idEstadia, String nombre, String apellido, String tipoDoc, String dni, String mail)
        {
            List<Consumible> consumibles = new List<Consumible>();
            //hago join con identidad ya que de ahi vendran los filtros como nombre apellido y dni
            String query = "SELECT con.Descripcion,con.idConsumible,con.Codigo,con.Precio FROM LOS_BORBOTONES.Consumible con INNER JOIN LOS_BORBOTONES.Estadia_X_Consumible exc ON con.idConsumible = exc.idConsumible";
            /*
  SELECT con.Descripcion,con.idConsumible,con.Codigo,con.Precio FROM LOS_BORBOTONES.Consumible con 
  INNER JOIN LOS_BORBOTONES.Estadia_X_Consumible exc ON con.idConsumible = exc.idConsumible
  INNER JOIN LOS_BORBOTONES.Reserva r ON r.idEstadia = exc.idEstadia
  INNER JOIN LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente rhc ON rhc.idReserva = r.idReserva
  INNER JOIN LOS_BORBOTONES.Cliente c ON c.idCliente = rhc.idCliente
  INNER JOIN LOS_BORBOTONES.Identidad i ON i.idIdentidad = c.idIdentidad
  where exc.idEstadia=66*/
  
            //Consulta SIN FILTRO
            if (nombre.Equals("") && apellido.Equals("") && tipoDoc.Equals("") && dni.Equals("") && idEstadia == 0 && mail.Equals(""))
            {
                consumibles = this.getAll();
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

                //AGREGO FILTRO NOMBRE
                if (!nombre.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE i.Nombre LIKE @Nombre";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        //aca va WHERE tambien ya que no lo puse en el inner join porque valide en el ON
                        query = query + " WHERE i.Nombre LIKE @Nombre";
                    }
                    sqlCommand.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                }
                //AGREGO FILTRO Apellido
                if (!apellido.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE i.Apellido LIKE @Apellido";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND i.Apellido LIKE @Apellido";
                    }
                    sqlCommand.Parameters.AddWithValue("@Apellido", "%" + apellido + "%");
                }
                //AGREGO FILTRO tipoDoc
                if (!tipoDoc.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE i.Apellido LIKE @TipoDoc";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND i.Apellido LIKE @TipoDoc";
                    }
                    sqlCommand.Parameters.AddWithValue("@TipoDoc", "%" + tipoDoc + "%");
                }
                //AGREGO FILTRO DNI
                if (!dni.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE i.NumeroDocumento LIKE @Dni";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND i.NumeroDocumento LIKE @Dni";
                    }
                    sqlCommand.Parameters.AddWithValue("@Dni", "%" + dni + "%");
                }

                //AGREGO FILTRO MAIL
                if (!mail.Equals(""))
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE i.NumeroDocumento LIKE @Mail";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND i.NumeroDocumento LIKE @Mail";
                    }
                    sqlCommand.Parameters.AddWithValue("@Mail", "%" + mail + "%");
                }

                //AGREGO FILTRO idEstadia
                if (idEstadia!=0)
                {
                    if (primerCriterioWhere)
                    {
                        query = query + " WHERE exc.idEstadia = @idEstadia";
                        primerCriterioWhere = false;
                    }
                    else
                    {
                        query = query + " AND exc.idEstadia = @idEstadia";
                    }
                    sqlCommand.Parameters.AddWithValue("@idEstadia",idEstadia);
                }

                //HAGO LA CONSULTA
                sqlCommand.CommandText = query;
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();

                //ARMAR CLIENTES
                while (reader.Read())
                {
                    consumibles.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idConsumible"))));
                }

                sqlConnection.Close();
            }

            return consumibles;
        }
    }
}

