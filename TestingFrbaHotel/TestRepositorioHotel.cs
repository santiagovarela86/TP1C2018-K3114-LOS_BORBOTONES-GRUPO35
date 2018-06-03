using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Excepciones;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioHotel
    {
        [TestMethod]
        public void Test_Repo_Hotel_Creacion_Hotel()
        {
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            Hotel hotel1 = repositorioHotel.getById(7);

            Assert.AreEqual("Balcarce2520", hotel1.getNombre());
            Assert.AreEqual(2018, hotel1.getFechaInicioActividades().Year);

            Assert.AreEqual(1, hotel1.getCategoria().getEstrellas());
            Assert.AreEqual("Bs. As. Oeste", hotel1.getDireccion().getCiudad());

            //VALIDAR LISTA DE RESERVAS
            //VALIDAR LISTA DE REGIMENES
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
