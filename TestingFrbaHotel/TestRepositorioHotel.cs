using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Diagnostics;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioHotel
    {
        [TestMethod]
        public void Test_Repo_Hotel_Creacion_Hotel()
        {
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            String hotelNombre = "HotelTest";
            String hotelMail = "test@gmail.com";
            String hotelTelefono = "123123";
            DateTime hotelFechaInicioDeActividad = DateTime.Now;
            int categoriaEstrellas = 5;
            decimal categoriaRecargaEstrellas = 10;
            String dirPais = "AR";
            String dirCiudad = "BUE";
            String dirCalle = "Medrano";
            int dirCalleNumero = 979;
            Categoria categoria1 = new Categoria(0, categoriaEstrellas, categoriaRecargaEstrellas);
            Direccion direccion1 = new Direccion(0, dirPais, dirCiudad, dirCalle, dirCalleNumero, 0, null);
            Hotel hotel1 = new Hotel(0, categoria1, direccion1, hotelNombre, hotelMail, hotelTelefono, hotelFechaInicioDeActividad, null, null, null,null);

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
        /*

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe usuario con el ID asociado")]
        public void Test_Repo_Hotel_getById()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario usuario = repositorioUsuario.getById(50);
        }

        [TestMethod]
        public void Test_Repo_Hotel_getAll() 
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            List<Usuario> usuarios = repositorioUsuario.getAll();
            Assert.AreEqual(2, usuarios.Count);
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
