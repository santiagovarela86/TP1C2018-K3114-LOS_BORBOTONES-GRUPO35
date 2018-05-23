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
        public void Valido_Creacion_Correcta_De_Rol()
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
        public void Valido_ID_OutOfBoundaries()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getById(50);
        }

        [TestMethod]
        public void Valido_Query_GetAll() 
        {
            RepositorioRol repositorioRol = new RepositorioRol();

            Assert.AreEqual(4, repositorioRol.getAll().Count);

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getFuncionalidades().Exists(f => f.getDescripcion().Equals("ABMHotel"))));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getActivo().Equals(false)));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getNombre().Equals("Guest")));
        }

        [TestMethod]
        public void Valido_Existe_EnRepositorio()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rolAdministrador = repositorioRol.getByNombre("Administrador");

            Assert.IsFalse(repositorioRol.exists(new Rol(50, "Dummy", false, null)));

            Assert.IsTrue(repositorioRol.exists(rolAdministrador));

            Assert.IsTrue(repositorioRol.exists(new Rol(0, "Administrador", false, null)));
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteNombreException), "No existe rol con el Nombre asociado")]
        public void Valido_Get_By_Name()
        {
            RepositorioRol repositorioRol = new RepositorioRol();
            Rol rol = repositorioRol.getByNombre("Lanata");
        }
    }
}
