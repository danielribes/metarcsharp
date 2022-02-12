using System;
using System.Collections.Generic;

namespace metar
{
    class Parser
    {
        public List<string> decode(string metar)
        {
            // Tokenitza
            List<string> finalMetar = new List<string>();
            string[] metarValues = metar.ToUpper().Split(' ');

            // ------------------------------ 
            //  Procesa tokens
            // ------------------------------
            // Aeroport segons OACI
            Place aeroport = new Place();
            finalMetar.Add(aeroport.Parse(metarValues[0]));
            //finalMetar.Add(Airports.nameFromICAO(metarValues[0]));

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

            // Wind, check V : 050V130
            // Wind, check G : 23009G30KT
            //metarValues[4]


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
            string variableWind = "Vent variable de {0}";
            string normalWind = "Vent de direcció {0} a {1}";
            string ratxesWind = "Vent de direcció {0} a {1}KT amb ratxes de {2}";
            string windResult = String.Empty;
            
            windResult = wind switch
            {
                "00000KT" => noWind,
                "/////KT" => noInfo,
                        _ => ""
            };

            if(String.IsNullOrEmpty(windResult))
            {
                // Procesa VRB, exemple: VRB02KT
                if(wind.StartsWith("VRB"))
                {
                    string knots = wind.Substring(3);
                    windResult = string.Format(variableWind, knots);
                } else {
                    // Procesa 21009KT, exemple: Vent de direcció 210 a 09KT
                    string coord = wind.Substring(0, 3);
                    string knots = wind.Substring(3);
                    windResult = string.Format(normalWind, coord, knots);    
                }

                // Procesa Ratxes, exemple: 25015G30KT
                int G = wind.IndexOf('G');
                if(G > 0)
                {
                    int lenghtPreG = G - 3;
                    string coord = wind.Substring(0, 3);
                    string knots1 = wind.Substring(3, lenghtPreG);
                    string knots2 = wind.Substring(G + 1);
                    windResult = string.Format(ratxesWind, coord, knots1, knots2); 

                    //Console.WriteLine("AQUIIIII ! {0}", wind.IndexOf('G'));
                }

                // Procesa 
            }
  
            return windResult;
        }

    }
}