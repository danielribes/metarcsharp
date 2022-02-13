using System;

namespace metar
{
    class Wind : AbstractParser
    {
        public override string Parse(string code)
        {
            string[] windResult = new string[4];
            
            windResult[0] = code switch
            {
                "00000KT" => "noWind",
                "/////KT" => "noInfo",
                        _ => ""
            };

            if(String.IsNullOrEmpty(windResult[0]))
            {
                // Procesa VRB, exemple: VRB02KT
                if(code.StartsWith("VRB"))
                {
                    string knots = code.Substring(3);
                    windResult[0] = "variableWind";
                    windResult[1] = knots;
                } else {
                    // Procesa 21009KT, exemple: Vent de direcció 210 a 09KT
                    string coord = code.Substring(0, 3);
                    string knots = code.Substring(3);
                    windResult[0] = "normalWind";
                    windResult[1] = coord; 
                    windResult[2] = knots;
                }

                // Procesa Ratxes, exemple: 25015G30KT
                int G = code.IndexOf('G');
                if(G > 0)
                {
                    int lenghtPreG = G - 3;
                    string coord = code.Substring(0, 3);
                    string knots1 = code.Substring(3, lenghtPreG);
                    string knots2 = code.Substring(G + 1);
                    windResult[0] = "ratxesWind";
                    windResult[1] = coord;
                    windResult[2] = knots1;
                    windResult[3] = knots2;
                }

            }
  
            return Frase(windResult);
        }

        protected override string Frase(string[] values)
        {
            string sortida;

            sortida = values[0] switch
            {
                "noWind" => "No hi ha vent",
                "noInfo" => "No es pot determinar la velocitat ni la direcció del vent",
                "variableWind" => string.Format("Vent variable de {0}", values[1]),
                "normalWind" => string.Format("Vent de direcció {0} a {1}", values[1], values[2]),
                "ratxesWind" => string.Format("Vent de direcció {0} a {1}KT amb ratxes de {2}", values[1], values[2], values[3]),
                        _ => ""
            };

            return sortida;
        }
        
    }
}