using System.Collections.Generic;


namespace metar
{
    class Place : AbstractParser
    {
        private Dictionary<string,string> ICAO = new Dictionary<string, string>
        {
            {"LELL", "Aeroport de Sabadell"},
            {"LEGE", "Aeroport de Girona"},
            {"LERS", "Aeroport de Reus"}
        };
        public override string Parse(string code)
        {
            return Frase(new string[] {ICAO[code]});
        }

        protected override string Frase(string[] values)
        {
            return values[0];
        }
    }
}
