using System;

//
// Exemple:
// Este informe fue elaborado para 13 de febrero de 2022 01:30, hora local el Aeropuerto de Sabadell.
// 
namespace metar 
{
    class DayTime : AbstractParser
    {

        public override string Parse(string code)
        {
            string[] dayAndTime = new string[3];
            
            dayAndTime[0] = code.Substring(0,2);
            dayAndTime[1] = code.Substring(2,2);
            dayAndTime[2] = code.Substring(4,2);

            return Frase(dayAndTime);
        }

        protected override string Frase(string[] values)
        {
            return string.Format("Pronòstic pel dia {0}, a {1}:{2} UTC", values[0], values[1], values[2]);
        }
    }
}