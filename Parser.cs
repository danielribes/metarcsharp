using System.Collections.Generic;

namespace metar
{
    class Parser
    {
        public Dictionary<string,string> ICAO = new Dictionary<string, string>
        {
            {"LELL", "Aeroport de Sabadell"},
            {"LEGE", "Aeroport de Girona"},
            {"LERS", "Aeroport de Reus"}
        };

        public List<string> decode(string metar)
        {
            // 
            List<string> finalMetar = new List<string>();
            string[] metarValues = metar.Split(' ');

            // Aeroport segons OACI
            finalMetar.Add(ICAO[metarValues[0]]);

            // Data
            finalMetar.Add(metarValues[1].Substring(0,2));

            // Hora
            finalMetar.Add(metarValues[1].Substring(2,2));

            // Minuts
            finalMetar.Add(metarValues[1].Substring(4));


            return finalMetar;
        }
    }
}