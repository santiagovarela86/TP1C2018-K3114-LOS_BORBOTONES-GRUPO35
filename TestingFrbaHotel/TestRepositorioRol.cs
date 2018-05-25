using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Excepciones;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioRol
    {
        [TestMethod]
        public void Test_Repo_Rol_Creacion_Rol()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getByNombre("Administrador");
            Assert.AreEqual(5 , rol.getFuncionalidades().Count);

            rol = repositorioRol.getByNombre("Recepcionista");
            Assert.AreEqual(6, rol.getFuncionalidades().Count);

            rol = repositorioRol.getByNombre("Guest");
            Assert.AreEqual(1, rol.getFuncionalidades().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe rol con el ID asociado")]
        public void Test_Repo_Rol_getById()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getById(50);
        }

        [TestMethod]
        public void Test_Repo_Rol_getAll() 
        {
            RepositorioRol repositorioRol = new RepositorioRol();

            Assert.AreEqual(4, repositorioRol.getAll().Count);

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getFuncionalidades().Exists(f => f.getDescripcion().Equals("ABMHotel"))));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getActivo().Equals(false)));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getNombre().Equals("Guest")));
        }

        [TestMethod]
        public void Test_Repo_Rol_exists()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rolAdministrador = repositorioRol.getByNombre("Administrador");

            Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            Assert.IsTrue(repositorioRol.exists(rolAdministrador));

            Assert.IsTrue(repositorioRol.exists(new Rol(0, "Administrador", false, null)));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteNombreException), "No existe rol con el Nombre asociado")]
        public void Test_Repo_Rol_getByName()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getByNombre("Lanata");
        }

        [TestMethod]
        public void Test_Repo_Rol_getByQuery()
        {
            RepositorioRol repositorioRol = new RepositorioRol();

            //SIN FILTRO
            Assert.AreEqual(4, repositorioRol.getByQuery("", new KeyValuePair<String, Boolean>(), null).Count);

            //FILTRO NOMBRE
            Assert.AreEqual(1, repositorioRol.getByQuery("Administrador", new KeyValuePair<String, Boolean>(), null).Count);

            //FILTRO ESTADO
            Assert.AreEqual(3, repositorioRol.getByQuery("", new KeyValuePair<String, Boolean>("", true), null).Count);

            //FILTRO NOMBRE Y ESTADO
            Assert.AreEqual(0, repositorioRol.getByQuery("Administrador", new KeyValuePair<String, Boolean>("", false), null).Count);

            //FALTA FILTRO FUNCIONALIDAD
        }
    }
}
