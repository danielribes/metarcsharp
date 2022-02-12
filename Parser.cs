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
          
            // Data
            DayTime thedate = new DayTime();
            finalMetar.Add(thedate.Parse(metarValues[1]));
            
            // COR/AUTO/NIL
            Observation observationType = new Observation(); 
            finalMetar.Add(observationType.Parse(metarValues[2]));

            // Wind
            Wind wind = new Wind();
            finalMetar.Add(wind.Parse(metarValues[3]));

            return finalMetar;
        }

    }
}