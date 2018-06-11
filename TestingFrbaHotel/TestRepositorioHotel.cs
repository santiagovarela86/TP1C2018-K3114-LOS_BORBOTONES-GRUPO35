using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Diagnostics;
using System.Collections.Generic;
using FrbaHotel.AbmHotel;
using TestingFrbaHotel.ModelBuilder;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioHotel
    {
        RepositorioHotel repositorioHotel = new RepositorioHotel();


        [TestMethod]
        public void Test_Repo_Hotel_Creacion_Hotel()
        {
            Hotel hotel1 = HotelBuilder.buildHotel();

            int savedHotelId= repositorioHotel.create(hotel1);

            Hotel hotelSearched= repositorioHotel.getById(savedHotelId);
            Assert.AreEqual(hotel1.Nombre, hotelSearched.getNombre());

            Assert.AreEqual(savedHotelId, hotelSearched.getIdHotel());
            Assert.AreEqual(hotel1.Mail, hotelSearched.getMail());
            Assert.AreEqual(hotel1.Telefono, hotelSearched.getTelefono());
            Debug.Assert(Math.Abs((hotel1.FechaInicioActividades - hotelSearched.getFechaInicioActividades()).TotalSeconds) < 1);
            Assert.AreEqual(hotel1.Categoria.Estrellas, hotelSearched.getCategoria().getEstrellas());
            Assert.AreEqual(hotel1.Categoria.RecargaEstrellas, hotelSearched.getCategoria().getRecargaEstrellas());
            Assert.AreEqual(hotel1.Direccion.Pais, hotelSearched.getDireccion().getPais());
            Assert.AreEqual(hotel1.Direccion.Ciudad, hotelSearched.getDireccion().getCiudad());
            Assert.AreEqual(hotel1.Direccion.Calle, hotelSearched.getDireccion().getCalle());
            Assert.AreEqual(hotel1.Direccion.NumeroCalle, hotelSearched.getDireccion().getNumeroCalle());
            Assert.AreEqual(0, hotelSearched.getDireccion().getPiso());


            //VALIDAR LISTA DE RESERVAS

            //VALIDAR LISTA DE CIERRES TEMPORALES

            //VALIDAR LISTA DE HABITACIONES

        }

       /*
        [TestMethod]
        public void Test_Repo_Hotel_searchHotel()
        {
            Hotel hotelSaved = HotelBuilder.buildHotel();
            int savedHotelId = repositorioHotel.create(hotelSaved);

            //POR NOMBRE
            String hotNombre = hotelSaved.Nombre;
            SearchHotelRequest request = new SearchHotelRequest(hotNombre, null, null, null);
            List<Hotel> hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach(var hotel in hoteles){ Assert.IsTrue(hotel.Nombre.Equals(hotNombre));}

            //POR ESTRELLAS
            int categoriaEstrellas = hotelSaved.Categoria.Estrellas;
            request = new SearchHotelRequest(null, categoriaEstrellas, null, null);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) { Assert.IsTrue(hotel.getCategoria().Estrellas.Equals(categoriaEstrellas)); }

            //POR CIUDAD
            String dirCiudad = hotelSaved.Direccion.Ciudad;

            request = new SearchHotelRequest(null, null, dirCiudad, null);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) { Assert.IsTrue(hotel.getDireccion().Ciudad.Equals(dirCiudad)); }


            //POR PAIS
            String dirPais = hotelSaved.Direccion.Pais;

            request = new SearchHotelRequest(null, null, null, dirPais);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) { Assert.IsTrue(hotel.getDireccion().Pais.Equals(dirPais)); }


            //POR NOMBRE, CIUDAD, PAIS , ESTRELLAS
            request = new SearchHotelRequest(hotNombre, categoriaEstrellas, dirCiudad, dirPais);
            hoteles = repositorioHotel.searchHotel(request);
            Assert.IsTrue(hoteles.Count > 0);
            foreach (var hotel in hoteles) {
                Assert.IsTrue(hotel.Nombre.Equals(hotNombre));
                Assert.IsTrue(hotel.getCategoria().Estrellas.Equals(categoriaEstrellas));
                Assert.IsTrue(hotel.getDireccion().Pais.Equals(dirPais));
                Assert.IsTrue(hotel.getDireccion().Pais.Equals(dirPais));
            }


        }
        * */

        [TestMethod]
        public void Test_Repo_Hotel_getAll()
        {
            //ESTE TEST DA TIMEOUT
            Hotel hotel = HotelBuilder.buildHotel();

            repositorioHotel.create(hotel);
            repositorioHotel.create(hotel);
            repositorioHotel.create(hotel);
            List<Hotel> hoteles = repositorioHotel.getAll();
            Assert.IsTrue(hoteles.Count > 2);
        }

   

        [TestMethod]
        public void Test_Repo_Hotel_exists_OK()
        {

            Hotel hotelSaved = HotelBuilder.buildHotel();
            int savedidHotel= repositorioHotel.create(hotelSaved);
            hotelSaved.IdHotel = savedidHotel;

            Assert.IsTrue(repositorioHotel.exists(hotelSaved));

        }

        [TestMethod]
        public void Test_Repo_Hotel_not_exists()
        {

            Hotel hotel = HotelBuilder.buildHotel();

            hotel.IdHotel = 99999999;
            Assert.IsFalse(repositorioHotel.exists(hotel));

        }
        /*
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
        public void Test_Repo_Hotel_UpdateCompleto_OKSinReservas()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Test_Repo_Hotel_UpdateCompleto_OKConReservas()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Test_Repo_Hotel_UpdateCompleto_Error_AlQuitarRegimenConReservas()
        {
            throw new NotImplementedException();
        }
      
        [TestMethod]
        public void Test_Repo_Hotel_crear_bajaTemporalSinReservasEnHotelOk()
        {
            Hotel hotel = HotelBuilder.buildHotel();
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
                Assert.AreEqual(cierre.Descripcion, descripcion);
                Assert.AreEqual(cierre.IdHotel, idHotel);
            }
        }
         * */
    }
}
