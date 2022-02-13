using System;

// COR/AUTO/NIL 
// - COR  : Aquesta observació substitueix una anterior
// - AUTO : L'observació s'ha realitzat automaticament, 
//          son més limitades que les generades manualment
// - NIL  : No es tenen dades


namespace metar
{
    class Observation : AbstractParser
    {
        public override string Parse(string code)
        {
            return code;
        }

        protected override string Frase(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}