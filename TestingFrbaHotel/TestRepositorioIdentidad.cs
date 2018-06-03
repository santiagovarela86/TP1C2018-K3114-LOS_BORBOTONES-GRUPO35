using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;
using FrbaHotel.Excepciones;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioIdentidad
    {
        [TestMethod]
        public void Test_Repo_Identidad_Creacion_Identidad()
        {
            RepositorioIdentidad repositorioIdentidad = new RepositorioIdentidad();
            Identidad identidadAdmin = repositorioIdentidad.getById(1);
            Identidad identidadUnCliente = repositorioIdentidad.getById(10);

            Assert.AreEqual("Usuario", identidadAdmin.getTipoIdentidad());
            Assert.AreEqual("Cliente", identidadUnCliente.getTipoIdentidad());

            /*
            Usuario admin = repositorioUsuario.getByUsername("admin");
            Usuario guest = repositorioUsuario.getByUsername("guest");

            Assert.IsTrue(admin.getActivo());
            Assert.IsTrue(guest.getActivo());

            Assert.AreEqual(0, admin.getIntentosFallidosLogin());
            Assert.AreEqual(0, guest.getIntentosFallidosLogin());

            Assert.IsTrue(admin.getRoles().Exists(rol => rol.getNombre().Equals("Administrador")));
            Assert.IsTrue(guest.getRoles().Exists(rol => rol.getNombre().Equals("Guest")));

            //FALTA VALIDAR QUE TRAIGA LOS HOTELES
            Assert.AreEqual(5, admin.getHoteles().Count);
            Assert.AreEqual(2, guest.getHoteles().Count);

            //FALTA VALIDAR QUE TRAIGA LA IDENTIDAD
            Assert.IsTrue(admin.getIdentidad().getMail().Equals("admin@frba_utn.com"));
            Assert.IsTrue(guest.getIdentidad().getNumeroDocumento().Equals("33417682"));
             * */
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteIDException), "No existe identidad con el ID asociado")]
        public void Test_Repo_Identidad_getById()
        {
            RepositorioIdentidad repositorioIdentidad = new RepositorioIdentidad();
            Identidad identidad = repositorioIdentidad.getById(999999999);
        }

        /*
         * NO ESTA IMPLEMENTADO
         * 
        [TestMethod]
        public void Test_Repo_Identidad_getAll() 
        {
            RepositorioIdentidad repositorioIdentidad = new RepositorioIdentidad();
            List<Identidad> identidades = repositorioIdentidad.getAll();
            Assert.AreEqual(1000, identidades.Count);
        }
        */

        [TestMethod]
        public void Test_Repo_Identidad_exists()
        {
            //HAY QUE PROGRAMAR EL EXISTS...

            //RepositorioRol repositorioRol = new RepositorioRol();
            //Rol rolAdministrador = repositorioRol.getByNombre("Administrador");

            //Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            //Assert.IsTrue(repositorioRol.exists(rolAdministrador));

            //Assert.IsTrue(repositorioRol.exists(new Rol(0, "Administrador", false, null)));
        }

        /*
    [TestMethod]
    [ExpectedException(typeof(NoExisteNombreException), "No existe identidad con el Nombre asociado")]
    public void Test_Repo_Identidad_getByUsername()
    {
        //NO ESTA PROGRAMADO

        RepositorioIdentidad repositorioIdentidad = new RepositorioIdentidad();
        Identidad identidadAdmin = repositorioIdentidad.("Lanata");

    }
         *             */

        [TestMethod]
        public void Test_Repo_Identidad_getByQuery()
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
    }
}
