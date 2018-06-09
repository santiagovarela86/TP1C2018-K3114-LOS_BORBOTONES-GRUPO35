using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingFrbaHotel.ModelBuilder;
using FrbaHotel.Modelo;

namespace TestingFrbaHotel
{
    [TestClass]
    class TestRepositorioHabitacion
    {

        [TestMethod]
        public void create_OK()
        {
            RepositorioHabitacion  repositorioHabitacion = new RepositorioHabitacion();
            RepositorioHotel repositorioHotel = new RepositorioHotel();

            Hotel hotel = HotelBuilder.buildHotel();

            int idHotel = repositorioHotel.create(hotel);



        }

    }
}
