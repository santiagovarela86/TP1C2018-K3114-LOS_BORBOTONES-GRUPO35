using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Diagnostics;
using System.Collections.Generic;
using FrbaHotel.AbmHotel.request;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioHotel
    {


        RepositorioHotel repositorioHotel = new RepositorioHotel();

        String hotelNombre = "HotelTest";
        String dirCiudad = "BUE";
        String dirPais = "AR";
        int categoriaEstrellas = 5;
        String hotelMail = "test@gmail.com";
        String hotelTelefono = "123123";
        DateTime hotelFechaInicioDeActividad = DateTime.Now;
        decimal categoriaRecargaEstrellas = 10;
        String dirCalle = "Medrano";
        int dirCalleNumero = 979;


        [TestMethod]
        public void Test_Repo_Hotel_Creacion_Hotel()
        {
            Hotel hotel1 = buildHotel();

            int savedHotelId= repositorioHotel.create(hotel1);

            Hotel hotelSearched= repositorioHotel.getById(savedHotelId);
            Assert.AreEqual(hotelNombre, hotelSearched.getNombre());

            Assert.AreEqual(savedHotelId, hotelSearched.getIdHotel());
            Assert.AreEqual(hotelMail, hotelSearched.getMail());
            Assert.AreEqual(hotelTelefono, hotelSearched.getTelefono());
            Debug.Assert(Math.Abs((hotelFechaInicioDeActividad - hotelSearched.getFechaInicioActividades()).TotalSeconds) < 1);
            Assert.AreEqual(categoriaEstrellas, hotelSearched.getCategoria().getEstrellas());
            Assert.AreEqual(categoriaRecargaEstrellas, hotelSearched.getCategoria().getRecargaEstrellas());
            Assert.AreEqual(dirPais, hotelSearched.getDireccion().getPais());
            Assert.AreEqual(dirCiudad, hotelSearched.getDireccion().getCiudad());
            Assert.AreEqual(dirCalle, hotelSearched.getDireccion().getCalle());
            Assert.AreEqual(dirCalleNumero, hotelSearched.getDireccion().getNumeroCalle());
            Assert.AreEqual(0, hotelSearched.getDireccion().getPiso());


            //VALIDAR LISTA DE RESERVAS

            //VALIDAR LISTA DE CIERRES TEMPORALES

            //VALIDAR LISTA DE HABITACIONES

        }

        private Hotel buildHotel()
        {
            Categoria categoria1 = new Categoria(0, categoriaEstrellas, categoriaRecargaEstrellas);
            Direccion direccion1 = new Direccion(0, dirPais, dirCiudad, dirCalle, dirCalleNumero, 0, null);
            return  new Hotel(0, categoria1, direccion1, hotelNombre, hotelMail, hotelTelefono, hotelFechaInicioDeActividad, null, null, null, null);

        }
        [TestMethod]
        public void Test_Repo_Hotel_searchHotel()
        {

            int savedHotelId = repositorioHotel.create(buildHotel());

            //POR NOMBRE
            SearchHotelRequest request = new SearchHotelRequest(hotelNombre, null, null, null);
            List<Hotel> hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach(var hotel in hoteles){ Assert.IsTrue(hotel.Nombre.Equals(hotelNombre));}

            //POR ESTRELLAS
            request = new SearchHotelRequest(null, categoriaEstrellas, null, null);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) { Assert.IsTrue(hotel.getCategoria().Estrellas.Equals(categoriaEstrellas)); }

            //POR CIUDAD
            request = new SearchHotelRequest(null, null, dirCiudad, null);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) { Assert.IsTrue(hotel.getDireccion().Ciudad.Equals(dirCiudad)); }


            //POR PAIS
            request = new SearchHotelRequest(null, null, null, dirPais);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) { Assert.IsTrue(hotel.getDireccion().Pais.Equals(dirPais)); }


            //POR NOMBRE, CIUDAD, PAIS , ESTRELLAS
            request = new SearchHotelRequest(hotelNombre, categoriaEstrellas, dirCiudad, dirPais);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) {
                Assert.IsTrue(hotel.Nombre.Equals(hotelNombre));
                Assert.IsTrue(hotel.getCategoria().Estrellas.Equals(categoriaEstrellas));
                Assert.IsTrue(hotel.getDireccion().Pais.Equals(dirPais));
                Assert.IsTrue(hotel.getDireccion().Pais.Equals(dirPais));
            }


        }

        [TestMethod]
        public void Test_Repo_Hotel_getAll()
        {
            Hotel hotel = buildHotel();

            repositorioHotel.create(hotel);
            repositorioHotel.create(hotel);
            repositorioHotel.create(hotel);
            List<Hotel> hoteles = repositorioHotel.getAll();
            Assert.IsTrue(hoteles.Count > 2);
        }

        [TestMethod]
        public void Test_Repo_Hotel_crear_bajaTemporalError()
        {
            throw new NotImplementedException();
        }


        [TestMethod]
        public void Test_Repo_Hotel_crear_bajaTemporalConReservasEnHotelOk()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Test_Repo_Hotel_crear_bajaTemporalSinReservasEnHotelOk()
        {
            Hotel hotel = buildHotel();
            int idsavedHotel= repositorioHotel.create(hotel);
            hotel = repositorioHotel.getById(idsavedHotel);


            Assert.IsTrue(hotel.getCierresTemporales().Count == 0);

            String descripcion = "CIERRE TEMPORAL DE TEST1";

            DateTime fechaInicio = DateTime.Now.AddDays(-3);
            DateTime fechaFin = DateTime.Now;
            int idHotel = hotel.getIdHotel();
            BajaTemporal request = new BajaTemporal(idHotel, fechaInicio, fechaFin, descripcion);
            repositorioHotel.crearBajaTemporal(request);
            repositorioHotel.crearBajaTemporal(request);
            Hotel hotelBuscadoConCierresTemporales = repositorioHotel.getById(idHotel);

            List<CierreTemporal> cierresTemporales = hotelBuscadoConCierresTemporales.getCierresTemporales();
            Assert.IsTrue(cierresTemporales.Count > 0);
            foreach (var cierre in cierresTemporales)
            {
                Assert.Equals(cierre.Descripcion, descripcion);
                Assert.Equals(cierre.IdHotel, idHotel);
            }
        }



        /*

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe usuario con el ID asociado")]
        public void Test_Repo_Hotel_getById()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario usuario = repositorioUsuario.getById(50);
        }


        [TestMethod]
        public void Test_Repo_Hotel_exists()
        {
            //HAY QUE PROGRAMAR EL EXISTS...

            //RepositorioRol repositorioRol = new RepositorioRol();
            //Rol rolAdministrador = repositorioRol.getByNombre("Administrador");

            //Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            //Assert.IsTrue(repositorioRol.exists(rolAdministrador));

            //Assert.IsTrue(repositorioRol.exists(new Rol(0, "Administrador", false, null)));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteNombreException), "No existe usuario con el Nombre asociado")]
        public void Test_Repo_Hotel_getByUsername()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario admin = repositorioUsuario.getByUsername("Lanata");
        }

        [TestMethod]
        public void Test_Repo_Hotel_getByQuery()
        {
            //RepositorioRol repositorioRol = new RepositorioRol();

            //SIN FILTRO
            //Assert.AreEqual(4, repositorioRol.getByQuery("", new KeyValuePair<String, Boolean>(), null).Count);

            //FILTRO NOMBRE
            //Assert.AreEqual(1, repositorioRol.getByQuery("Administrador", new KeyValuePair<String, Boolean>(), null).Count);

            //FILTRO ESTADO
            //Assert.AreEqual(3, repositorioRol.getByQuery("", new KeyValuePair<String, Boolean>("", true), null).Count);

            //FILTRO NOMBRE Y ESTADO
            //Assert.AreEqual(0, repositorioRol.getByQuery("Administrador", new KeyValuePair<String, Boolean>("", false), null).Count);

            //FALTA FILTRO FUNCIONALIDAD
        }
        */
    }
}
