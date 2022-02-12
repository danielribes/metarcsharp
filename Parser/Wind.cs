using System;

namespace metar
{
    class Wind : IParser
    {
        public string Parse(string code)
        {
            string noWind = "No hi ha vent";
            string noInfo = "No es pot determinar la velocitat ni la direcció del vent";
            string variableWind = "Vent variable de {0}";
            string normalWind = "Vent de direcció {0} a {1}";
            string ratxesWind = "Vent de direcció {0} a {1}KT amb ratxes de {2}";
            string windResult = String.Empty;
            
            windResult = code switch
            {
                "00000KT" => noWind,
                "/////KT" => noInfo,
                        _ => ""
            };

            if(String.IsNullOrEmpty(windResult))
            {
                // Procesa VRB, exemple: VRB02KT
                if(code.StartsWith("VRB"))
                {
                    string knots = code.Substring(3);
                    windResult = string.Format(variableWind, knots);
                } else {
                    // Procesa 21009KT, exemple: Vent de direcció 210 a 09KT
                    string coord = code.Substring(0, 3);
                    string knots = code.Substring(3);
                    windResult = string.Format(normalWind, coord, knots);    
                }

                // Procesa Ratxes, exemple: 25015G30KT
                int G = code.IndexOf('G');
                if(G > 0)
                {
                    int lenghtPreG = G - 3;
                    string coord = code.Substring(0, 3);
                    string knots1 = code.Substring(3, lenghtPreG);
                    string knots2 = code.Substring(G + 1);
                    windResult = string.Format(ratxesWind, coord, knots1, knots2); 

                    //Console.WriteLine("AQUIIIII ! {0}", wind.IndexOf('G'));
                }

                // Procesa 
            }
  
            return windResult;
        }
    }
}