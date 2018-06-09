using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel.request
{
    public class SearchHotelRequest
    {
        private String nombreHotel;
        private int? estrellas;
        private String ciudad;
        private String pais;


        public SearchHotelRequest(String nombreHotel,int? estrellas,String ciudad, String pais) {
            this.nombreHotel = nombreHotel;
            this.estrellas = estrellas;
            this.ciudad = ciudad;
            this.pais = pais;
        }
        public string Pais { get => pais; set => pais = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string NombreHotel { get => nombreHotel; set => nombreHotel = value; }
        public int? Estrellas { get => estrellas; set => estrellas = value; }

    }


}
