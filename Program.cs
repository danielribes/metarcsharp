using System;

namespace metar
{
    class Program
    {
        static void Main(string[] args)
        {                      
            // METAR Test
            string metartest = "LELL 282230Z AUTO 25015G30KT CAVOK 15/09 Q1017";

            Parser metar = new Parser();
            var metarValues = metar.decode(metartest);

            // test
            Console.WriteLine("METAR");
            foreach(string value in metarValues)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Pronostic a {0} pel dia {1} a les {2}", metarValues[0], metarValues[1], metarValues[2]);
        }
    }
}
