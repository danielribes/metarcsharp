using System.Collections.Generic;

namespace metar
{
    class Parser
    {
        public List<string> decode(string metar)
        {
            // 
            List<string> finalMetar = new List<string>();
            string[] metarValues = metar.Split(' ');

            // Aeroport segons OACI
            finalMetar.Add(Airports.nameFromICAO(metarValues[0]));

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