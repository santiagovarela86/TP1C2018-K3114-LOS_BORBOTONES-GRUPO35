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
    public class RepositorioReserva : Repositorio<Reserva>
    {
        //ESTO TARDABA MUCHO EN TRAER LAS RESERVAS POR HOTEL
        //COMENTE TODO LO QUE ES TRAER LOS OBJETOS CON OTROS REPOSITORIOS
        //EN CASO DE QUE HAGA FALTA TRAER ESOS OBJETOS
        //TENDREMOS QUE OBTENERLOS EN UNA SOLA CONSULTA EN ESTE REPOSITORIO
        //SINO SE VUELVE MUY POCO PERFORMANTE
        //HAY QUE VER BIEN EN QUE CASOS HACE FALTA QUE UNA RESERVA CONOZCA ESTOS OBJETOS
        //POR EJEMPLO, ¿PARA QUE NECESITA OBTENER SU HOTEL DE LA BASE SI LA ESTOY BUSCANDO A PARTIR DEL IDHOTEL?, AL HOTEL YA LO CONOZCO
        public List<Reserva> getByIdHotel(int idHotel)
        {
            RepositorioHotel repoHotel = new RepositorioHotel();
            RepositorioRegimen repoRegimen = new RepositorioRegimen();
            RepositorioCliente repoCliente = new RepositorioCliente();
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();

            List<Reserva> reservas = new List<Reserva>();
            
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            
            sqlCommand.Parameters.AddWithValue("@idHotel", idHotel);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Reserva WHERE idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
                decimal codigoReserva = reader.GetDecimal(reader.GetOrdinal("CodigoReserva"));
                DateTime fechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion"));
                DateTime fechaDesde = reader.GetDateTime(reader.GetOrdinal("FechaDesde"));
                DateTime fechaHasta = reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                decimal diasAlojados = reader.GetDecimal(reader.GetOrdinal("DiasAlojados"));
                //Hotel hotel = repoHotel.getById(reader.GetOrdinal("idHotel"));
                //Estadia estadia = repoEstadia.getById(reader.GetOrdinal("idEstadia"));
                //Regimen regimen = repoRegimen.getById(reader.GetOrdinal("idRegimen"));                
                //Cliente cliente = repoCliente.getById(reader.GetOrdinal("idCliente"));
                //List<EstadoReserva> estados = repoEstadoReserva.getByIdReserva(idReserva);
                //Reserva reserva = new Reserva(idReserva, hotel, estadia, regimen, cliente, codigoReserva, diasAlojados, fechaCreacion, fechaDesde, fechaHasta, estados);
                Reserva reserva = new Reserva(idReserva, null, null, null, null, codigoReserva, diasAlojados, fechaCreacion, fechaDesde, fechaHasta, null);
                reservas.Add(reserva);
            }

            sqlConnection.Close();

            return reservas;

        }

        public Reserva getIdByIdEstadia(int idEstadia)
        {
            Reserva reserva = null;
            RepositorioRegimen repoRegimen = new RepositorioRegimen();
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idEstadia", idEstadia);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT TOP 1 * FROM LOS_BORBOTONES.Reserva WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                int idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
                decimal codigoReserva = reader.GetDecimal(reader.GetOrdinal("CodigoReserva"));
                decimal diasAlojados = reader.GetDecimal(reader.GetOrdinal("DiasAlojados"));
                DateTime fechaDesde = reader.SafeGetDateTime(reader.GetOrdinal("FechaDesde"));
                DateTime fechaHasta = reader.SafeGetDateTime(reader.GetOrdinal("FechaHasta"));
                DateTime fechaCreacion = reader.SafeGetDateTime(reader.GetOrdinal("FechaCreacion"));
                Hotel hotel = null;
                //Regimen regimen = null;
                Regimen regimen = repoRegimen.getById(reader.GetInt32(reader.GetOrdinal("idRegimen")));                
                Estadia estadia = null;
                Cliente cliente = null;
                List<EstadoReserva> estados = new List<EstadoReserva>();
                reserva = new Reserva(idReserva, hotel, estadia, regimen, cliente, codigoReserva, diasAlojados, fechaCreacion, fechaDesde, fechaHasta, estados);
            }
            sqlConnection.Close();

            return reserva;

        }


        public bool existReservaBetweenDate(DateTime fechaDesde, DateTime fechaHasta, int idHotel)
        {

            RepositorioHotel repoHotel = new RepositorioHotel();
            RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();

            List<Reserva> reservas = new List<Reserva>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            sqlCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            sqlCommand.Parameters.AddWithValue("@idHotel", idHotel);
            //  reserva.FechaDesde < cierreTemporal.FechaFin && cierreTemporal.FechaInicio < reserva.FechaHasta;
              
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT 1 FROM LOS_BORBOTONES.Reserva WHERE FechaDesde < @fechaHasta AND @fechaDesde < FechaHasta AND idHotel = @idHotel";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            bool exist = reader.Read();
           
            sqlConnection.Close();

            return exist;

        }
        override public Reserva getById(int idReserva)
        {

            RepositorioHotel repoHotel = new RepositorioHotel();
            RepositorioRegimen repoRegimen = new RepositorioRegimen();
            RepositorioCliente repoCliente = new RepositorioCliente();
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();

            //Elementos de la Reserva a devolver
            Reserva reserva;

            Hotel hotel = null;
            Estadia estadia = null;
            Regimen regimen = null;
            Cliente cliente = null;
            decimal codigoReserva = 0;
            decimal diasAlojados = 0;
            DateTime fechaCreacion = new DateTime();
            DateTime fechaDesde = new DateTime();
            DateTime fechaHasta = new DateTime();
            List<EstadoReserva> estados = new List<EstadoReserva>();
            
            //Configuraciones de la consulta
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            //Primera Consulta
            sqlCommand.Parameters.AddWithValue("@idReserva", idReserva);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM LOS_BORBOTONES.Reserva WHERE idReserva = @idReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                codigoReserva = reader.GetDecimal(reader.GetOrdinal("CodigoReserva"));
                diasAlojados = reader.GetDecimal(reader.GetOrdinal("DiasAlojados"));
                fechaDesde = reader.GetDateTime(reader.GetOrdinal("FechaDesde"));
                fechaHasta = reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                fechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion"));
                hotel = repoHotel.getById(reader.GetOrdinal("IdHotel"));
                regimen = repoRegimen.getById(reader.GetOrdinal("IdRegimen"));
                estadia = repoEstadia.getById(reader.GetOrdinal("IdEstadia"));
                cliente = repoCliente.getById(reader.GetOrdinal("IdCliente"));
                estados.Add(repoEstadoReserva.getById(idReserva));
            }

            //Cierro Primera Consulta
            sqlConnection.Close();

            //Si no encuentro elemento con ese ID tiro una excepción
            if (cliente.Equals(null)) throw new NoExisteIDException("No existe reserva con el ID asociado");

            //Armo la reserva completa
            reserva = new Reserva(idReserva, hotel, estadia, regimen, cliente, codigoReserva, diasAlojados, fechaCreacion, fechaDesde, fechaHasta, estados);

            return reserva;
        }

        override public List<Reserva> getAll()
        {
            throw new NotImplementedException();            
        }

        //ESTO DEBE TARDAR 44 HORAS EN TRAER TODO
        /*
        override public List<Reserva> getAll()
        {
            List<Reserva> reservas = new List<Reserva>();

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT idReserva FROM LOS_BORBOTONES.Reserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                reservas.Add(this.getById(reader.GetInt32(reader.GetOrdinal("idReserva"))));
            }

            sqlConnection.Close();

            return reservas;
        }
        */

        override public int create(Reserva reserva)
        {
            throw new NotImplementedException();

        }

        override public void update(Reserva reserva)
        {
            if (this.exists(reserva))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Reserva reserva)
        {
            if (this.exists(reserva))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public void bajaLogica(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        override public Boolean exists(Reserva reserva)
        {
            int idReserva = 0;
            int idEstadia = 0;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReserva", reserva.getIdReserva());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idReserva FROM LOS_BORBOTONES.Reserva WHERE idReserva = @idReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
            }

            sqlConnection.Close();

            Estadia estadia = null;
            estadia = reserva.getEstadia();

            //valido por el idEstadia que tiene en la base
            sqlCommand.Parameters.AddWithValue("@idEstadia", estadia.getIdEstadia());
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Reserva WHERE idEstadia = @idEstadia";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
            }

            sqlConnection.Close();

            //Devuelve verdadero si el ID coincide o si el IdEstadia coincide
            return idReserva != 0 || estadia.getIdEstadia().Equals(idEstadia);
        }
        //luego hacer algun getBy que vea especial y el getByQuery
        public int getIdEstadiaByCodReserva(int codReserva)
        {
            int idEstadia = 0;
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@CodReserva", codReserva);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT idEstadia FROM LOS_BORBOTONES.Reserva WHERE CodigoReserva = @CodReserva";

            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idEstadia = reader.GetInt32(reader.GetOrdinal("idEstadia"));
            }

            sqlConnection.Close();
            
            return idEstadia;
        }
        public int GetReservaValida(int codReserva,DateTime date,String username)
        {
            int idHotel = 0;
            int idReserva = 0;
            int hotelFound = 0;
            decimal cantidadNoches = 0;
            DateTime fechaOut= new DateTime();
            RepositorioUsuario repouser = new RepositorioUsuario();
            Usuario userIn = null;
            //SACAR ESTO CUANDO INVOQUE DESDE FUNCIONALIDES ADICIONALES, TRAIGO DE UNA LA ID YA VALIDA
            userIn = repouser.getByUsername(username);
            if (userIn == null)
                return 4;

            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;
            
            sqlCommand.Parameters.AddWithValue("@CodReserva", codReserva);
            sqlCommand.Parameters.AddWithValue("@date", date);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT r.idReserva,r.idHotel,r.FechaHasta,r.DiasAlojados FROM LOS_BORBOTONES.Reserva as r,LOS_BORBOTONES.EstadoReserva as er WHERE r.CodigoReserva = @CodReserva and r.FechaDesde = @date and er.idReserva=r.idReserva and er.TipoEstado='RC'";
            
            sqlConnection.Open();

            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                idReserva = reader.GetInt32(reader.GetOrdinal("idReserva"));
                idHotel = reader.GetInt32(reader.GetOrdinal("idHotel"));
                fechaOut = reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                cantidadNoches = reader.GetDecimal(reader.GetOrdinal("DiasAlojados"));
            }

            sqlConnection.Close();
            if (idReserva == 0)
            {
                //llamo a cancelar la reserva en estado reserva
                RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();                
                repoEstadoReserva.rechazarReserva(codReserva,userIn.getIdUsuario(),date);
                return 2;

            }
            
            foreach (Hotel h in userIn.getHoteles())
            {
                //si encuentro el hotel en el que el usuario trabaja entonces valido bien
                if (h.getIdHotel() == idHotel)
                    hotelFound = 1;
            }
        
            if (hotelFound == 0)
                return 3;

            if (idReserva != 0 && hotelFound != 0)
            {
                //llamo a actualizar la estadia
                RepositorioEstadia repoEstadia =new RepositorioEstadia();
                //int idEstadia = getIdEstadiaByCodReserva(codReserva);
                //comento lo de arriba ya que es un insert esto, no un update como pense al principio
                int idEstadia = 0;
                Boolean facturada = false;
                Usuario userOut=userIn;
                Estadia estadia = new Estadia(idEstadia, userIn, userOut,date,fechaOut,facturada,cantidadNoches);
                idEstadia= repoEstadia.create(estadia);
                //repoEstadia.updateIn(estadia);
               
                //hago update de reserva para darle id estadia
                Reserva reserva = getById(idReserva);
                
                this.updateIn(idReserva,idEstadia);

                //hago update de EstadoReserva
                RepositorioEstadoReserva repoEstadoReserva = new RepositorioEstadoReserva();
                
                int idEstadoReserva = 0;
                
                String desc = "Reserva Con Ingreso";
                String tipoEstado = "RCI";
                EstadoReserva estadoReserva = new EstadoReserva(idEstadoReserva, userIn, reserva, tipoEstado, date, desc);
                repoEstadoReserva.update(estadoReserva);

                return 1;
            }
            return 0;
        }


         public bool existsReservasConRegimen(Regimen regimen,Hotel hotel) {

             String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
             SqlConnection sqlConnection = new SqlConnection(connectionString);
             SqlCommand sqlCommand = new SqlCommand();
             SqlDataReader reader;

             sqlCommand.Parameters.AddWithValue("@idRegimen", regimen.getIdRegimen());
             sqlCommand.Parameters.AddWithValue("@idHotel", hotel.getIdHotel());

             sqlCommand.CommandType = CommandType.Text;
             sqlCommand.Connection = sqlConnection;
             sqlCommand.CommandText = 
                 "SELECT idReserva FROM LOS_BORBOTONES.Reserva WHERE idRegimen = @idRegimen "  + 
                 "AND idHotel=@idHotel " +
                 "AND FechaHasta >GETDATE(); ";

             sqlConnection.Open();

             reader = sqlCommand.ExecuteReader();

             bool exist = reader.Read();
             sqlConnection.Close();

             return exist;
         }
    //metodo para traer el monto de una reserva
    public Decimal getMonto(Reserva reserva)
    {
            /*El valor de la habitación se obtiene a través de su precio base (ver abm de régimen)
            multiplicando la cantidad de personas que se alojarán en la habitación (tipo de habitación) y
            luego de ello aplicando un incremento en función de la categoría del Hotel (cantidad de
            estrellas)*/
             Decimal total = 0;
             RepositorioRegimen repoRegimen = new RepositorioRegimen();
             RepositorioHabitacion repoHabitacion = new RepositorioHabitacion();
        
             String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
             SqlConnection sqlConnection = new SqlConnection(connectionString);
             SqlCommand sqlCommand = new SqlCommand();
             SqlDataReader reader;

        //traigo el monto del regimen
             Decimal montoRegimen = repoRegimen.getMonto(reserva.getRegimen().getIdRegimen());
        
             sqlCommand.Parameters.AddWithValue("@idReserva", reserva.getIdReserva());
             sqlCommand.CommandType = CommandType.Text;
             sqlCommand.Connection = sqlConnection;
             sqlCommand.CommandText = "SELECT idHabitacion FROM LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente INNER JOIN LOS_BORBOTONES. WHERE idReserva = @idReserva";

             sqlConnection.Open();

             reader = sqlCommand.ExecuteReader();

             while (reader.Read())
             {

                 Habitacion habitacion = repoHabitacion.getById(reader.GetInt32(reader.GetOrdinal("idHabitacion")));
                 TipoHabitacion tipoHabitacion= habitacion.getTipoHabitacion();

                 total = montoRegimen * tipoHabitacion.getPorcentual();
             }

             sqlConnection.Close();    
             
             //falta la suma por cantidad de estrellas
             Hotel hotel= reserva.getHotel();
             Categoria categoria=hotel.getCategoria();
             Decimal recargaEstrellas = categoria.getRecargaEstrellas();
             
             //Devuelve el monto total de las habitaciones para esa reserva.
             total = total + recargaEstrellas;

             return total;

         }
    public void updateIn(int idReserva,int idEstadia)
    {
        
            String connectionString = ConfigurationManager.AppSettings["BaseLocal"];
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader reader;

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            
            sqlCommand.Parameters.AddWithValue("@idEstadia", idEstadia);
            sqlCommand.Parameters.AddWithValue("@idReserva", idReserva);

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append(@"
                    BEGIN TRY
                    BEGIN TRANSACTION

                    UPDATE LOS_BORBOTONES.Reserva
                    SET idEstadia = @idEstadia
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

