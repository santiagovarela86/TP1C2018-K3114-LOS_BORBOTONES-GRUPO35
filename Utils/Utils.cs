using FrbaHotel.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Commons
{
    public static class Utils
    {
        public static Object validateFields(Object field, String fieldName)
        {
            if (field == null)
            {
                throw new RequestInvalidoException(fieldName + "no puede ser nulo");
            }
            return field;
        }

        public static String validateStringFields(String field, String fieldName)
        {
            if (field == null || field == "")
            {
                throw new RequestInvalidoException(fieldName + " no puede ser nulo");
            }
            return field;
        }

        public static int validateIntField(String field, String fieldName)
        {
            if (field == null || field == "")
            {
                throw new RequestInvalidoException(fieldName + " no puede ser nulo");
            }
            try
            {
                return Int32.Parse(field);
            }
            catch (Exception e)
            {
                throw new RequestInvalidoException(fieldName + " debe ser numerico");

            }
        }
    }
}
