using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Modelo
{
    public static class LectorSql
    {
        //Metodo de extensión del SqlDataReader
        //Si es un campo String y hay null devuelvo String vacío
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        //Metodo de extensión del SqlDataReader
        //Si es un campo DateTime y hay null devuelvo DateTime vacío
        public static DateTime SafeGetDateTime(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return new DateTime();
        }
    }
}
