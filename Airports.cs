using System.Collections.Generic;

namespace metar
{
    class Airports
    {
        private static Dictionary<string,string> ICAO = new Dictionary<string, string>
        {
            {"LELL", "Aeroport de Sabadell"},
            {"LEGE", "Aeroport de Girona"},
            {"LERS", "Aeroport de Reus"}
        };

        public static string nameFromICAO(string icaoCode)
        {
            return ICAO[icaoCode];
        }
    }
}