using System.Collections.Generic;


namespace metar
{
    class Place : IParser
    {
        private static Dictionary<string,string> ICAO = new Dictionary<string, string>
        {
            {"LELL", "Aeroport de Sabadell"},
            {"LEGE", "Aeroport de Girona"},
            {"LERS", "Aeroport de Reus"}
        };
        public string Parse(string code)
        {
            return ICAO[code];
        }
    }
}
