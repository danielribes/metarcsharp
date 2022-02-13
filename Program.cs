using System;

namespace metar
{
    class Program
    {
        static void Main(string[] args)
        {                      
            // METAR Test
            // 	131430Z 20011KT 140V230 9999 SCT025 14/07 Q1019
            string metartest = "LEGE 282230Z AUTO 25015G30KT CAVOK 15/09 Q1017";

            Parser metar = new Parser();
            var metarValues = metar.decode(metartest);

            // test
            Console.WriteLine("METAR");
            foreach(string value in metarValues)
            {
                Console.WriteLine(value);
            }
        }
    }
}
