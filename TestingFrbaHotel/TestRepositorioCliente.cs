using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Excepciones;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioCliente
    {
        [TestMethod]
        public void Test_Repo_Cliente_Creacion_Cliente()
        {
            RepositorioCliente repositorioCliente = new RepositorioCliente();
            Cliente dalia = repositorioCliente.getById(20990);

            //TEST BASICO
            Assert.IsTrue(dalia.getIdentidad().getNombre().Equals("DALIA"));
            Assert.IsTrue(dalia.getIdentidad().getApellido().Equals("Saavedra"));
            Assert.IsTrue(dalia.getIdentidad().getFechaNacimiento().Year.Equals(1953));
        }

        /*
        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe Cliente con el ID asociado")]
        public void Test_Repo_Cliente_getByIdFalla()
        {

        }
        */
        
        /*
        [TestMethod]
        public void Test_Repo_Cliente_getAll()
        {
            
            RepositorioCliente repositorioCliente = new RepositorioCliente();
            List<Cliente> Clientes = repositorioCliente.getAll();
            Assert.AreEqual(193888, Clientes.Count);
            
        }
        
        [TestMethod]
        public void Test_Repo_Cliente_exists()
        {
            //HAY QUE PROGRAMAR EL EXISTS...

            //RepositorioRol repositorioRol = new RepositorioRol();
            //Rol rolAdministrador = repositorioRol.getByNombre("Administrador");

            //Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            //Assert.IsTrue(repositorioRol.exists(rolAdministrador));

            //Assert.IsTrue(repositorioRol.exists(new Rol(0, "Administrador", false, null)));
        }
        */

        /*
        [TestMethod]
        [ExpectedException(typeof(NoExisteNombreException), "No existe Cliente con el Nombre asociado")]
        public void Test_Repo_Cliente_getByUsername()
        {
            RepositorioCliente repositorioCliente = new RepositorioCliente();
            //Cliente admin = repositorioCliente.("Lanata");
        }
        */

        /*
        [TestMethod]
        public void Test_Repo_Cliente_getByQuery()
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
