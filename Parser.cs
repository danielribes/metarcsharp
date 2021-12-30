using System;
using System.Collections.Generic;

namespace metar
{
    class Parser
    {
        public List<string> decode(string metar)
        {
            // 
            List<string> finalMetar = new List<string>();
            string[] metarValues = metar.ToUpper().Split(' ');

            // Aeroport segons OACI
            finalMetar.Add(Airports.nameFromICAO(metarValues[0]));

            // Data
            finalMetar.Add(metarValues[1].Substring(0,2));

            // Hora
            string tmpHora = metarValues[1].Substring(2,2);

            // Minuts
            string tmpMinuts = metarValues[1].Substring(4,2);

            // Hora/Minuts finals
            finalMetar.Add(tmpHora + ":" + tmpMinuts + " UTC");

            // COR/AUTO/NIL 
            finalMetar.Add(parseObservation(metarValues[2]));

            // Wind
            finalMetar.Add(parseWind(metarValues[3]));


            return finalMetar;
        }


        // COR/AUTO/NIL 
        // - COR  : Aquesta observació substitueix una anterior
        // - AUTO : L'observació s'ha realitzat automaticament, 
        //          son més limitades que les generades manualment
        // - NIL  : No es tenen dades
        private string parseObservation(string observation)
        {
            return observation;
        }

        // Wind
        private string parseWind(string wind)
        {
            string noWind = "No hi ha vent";
            string noInfo = "No es pot determinar la velocitat ni la direcció del vent";
            string windResult = String.Empty;
            
            windResult = wind switch
            {
                "00000KT" => noWind,
                "/////KT" => noInfo,
                        _ => ""
            };

            if(String.IsNullOrEmpty(windResult))
            {
                // procesa wind
                windResult = wind;
            }
  

            return windResult;
        }

    }
}