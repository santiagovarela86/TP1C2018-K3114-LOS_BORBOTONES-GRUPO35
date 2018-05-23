using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System.Collections.Generic;

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
        public void Valido_Query_GetAll() 
        {
            RepositorioRol repositorioRol = new RepositorioRol();

            Assert.AreEqual(4, repositorioRol.getAll().Count);

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getFuncionalidades().Exists(f => f.getDescripcion().Equals("ABMHotel"))));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getActivo().Equals(false)));

            Assert.IsTrue(repositorioRol.getAll().Exists(r => r.getNombre().Equals("Guest")));
        }
    }
}
