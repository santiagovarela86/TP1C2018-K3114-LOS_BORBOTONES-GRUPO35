using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioDireccion
    {
        [TestMethod]
        public void Test_Repo_Direccion_Creacion_Direccion()
        {
            String ciudad = "BUE";
            String pais= "AR";
            String calle = "MEDRANO";
            int numeroCalle = 123;
            int piso =1;
            String departamento = "A";
            RepositorioDireccion repositorioDireccion = new RepositorioDireccion();
            Direccion direccion = new Direccion(0, pais, ciudad, calle, numeroCalle, piso, departamento);
            int idDireccionInserted = repositorioDireccion.create(direccion);
            Direccion direccionBuscada = repositorioDireccion.getById(idDireccionInserted);

            Assert.AreEqual(ciudad, direccionBuscada.getCiudad());
            Assert.AreEqual(pais, direccionBuscada.getPais());
            Assert.AreEqual(calle, direccionBuscada.getCalle());
            Assert.AreEqual(numeroCalle, direccionBuscada.getNumeroCalle());
            Assert.AreEqual(piso, direccionBuscada.getPiso());
            Assert.AreEqual(departamento, direccionBuscada.getDepartamento());
            Assert.IsTrue(direccionBuscada.getIdDireccion() !=0);


        }
        /*

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe usuario con el ID asociado")]
        public void Test_Repo_Direccion_getById()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario usuario = repositorioUsuario.getById(50);
        }

        [TestMethod]
        public void Test_Repo_Direccion_getAll() 
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            List<Usuario> usuarios = repositorioUsuario.getAll();
            Assert.AreEqual(2, usuarios.Count);
        }

        [TestMethod]
        public void Test_Repo_Direccion_exists()
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
        public void Test_Repo_Direccion_getByUsername()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
            Usuario admin = repositorioUsuario.getByUsername("Lanata");
        }

        [TestMethod]
        public void Test_Repo_Direccion_getByQuery()
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
