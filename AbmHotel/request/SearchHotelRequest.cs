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

        public String NombreHotel
        {
            get { return nombreHotel; }
            set { nombreHotel = value; }
        }
        public String Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        public String Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        public int? Estrellas
        {
            get { return estrellas; }
            set { estrellas = value; }
        }
    }


}
