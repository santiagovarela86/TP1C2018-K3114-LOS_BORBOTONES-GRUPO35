using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Excepciones;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioUsuario
    {
        [TestMethod]
        public void Test_Repo_Usuario_Creacion_Usuario()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario admin = repositorioUsuario.getByUsername("admin");
            Usuario guest = repositorioUsuario.getByUsername("guest");

            Assert.IsTrue(admin.getActivo());
            Assert.IsTrue(guest.getActivo());

            Assert.AreEqual(0, admin.getIntentosFallidosLogin());
            Assert.AreEqual(0, guest.getIntentosFallidosLogin());

            Assert.IsTrue(admin.getRoles().Exists(rol => rol.getNombre().Equals("Administrador")));
            Assert.IsTrue(guest.getRoles().Exists(rol => rol.getNombre().Equals("Guest")));

            Assert.IsTrue(admin.getIdentidad().getMail().Equals("admin@frba_utn.com"));
            Assert.IsTrue(guest.getIdentidad().getNumeroDocumento().Equals("18217283"));

            //FALTA VALIDAR QUE TRAIGA LOS HOTELES
            //Assert.AreEqual(5, admin.getHoteles().Count);
            //Assert.AreEqual(2, guest.getHoteles().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe usuario con el ID asociado")]
        public void Test_Repo_Usuario_getByIdFalla()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario usuario = repositorioUsuario.getById(50);
        }

        [TestMethod]
        public void Test_Repo_Usuario_getAll()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            List<Usuario> usuarios = repositorioUsuario.getAll();
            Assert.AreEqual(3, usuarios.Count);
        }

        /*
        [TestMethod]
        public void Test_Repo_Usuario_exists()
        {
            //HAY QUE PROGRAMAR EL EXISTS...

            //RepositorioRol repositorioRol = new RepositorioRol();
            //Rol rolAdministrador = repositorioRol.getByNombre("Administrador");

            //Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            //Assert.IsTrue(repositorioRol.exists(rolAdministrador));

            //Assert.IsTrue(repositorioRol.exists(new Rol(0, "Administrador", false, null)));
        }
        */

        [TestMethod]
        [ExpectedException(typeof(NoExisteNombreException), "No existe usuario con el Nombre asociado")]
        public void Test_Repo_Usuario_getByUsernameFalla()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario admin = repositorioUsuario.getByUsername("Lanata");
        }

        /*
        [TestMethod]
        public void Test_Repo_Usuario_getByQuery()
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
