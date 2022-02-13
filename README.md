# METAR

És una aplicació per interpretar els METAR i traduir-los a una descripció més __humana.__ 

L'objectiu principal és utilitzar-la per aprendre C# i l'ecosistema .Net, començant amb una eina CLI i arribant a una web API.


## ENFOC

Ho planteixo com un PARSER que analitza cada grup d'un METAR i construeix una resposta escrita.

### El Parser

El parser l'implemento amb un grup de classes que de manera individual resolen cada grup d'un METAR.

Aquestes classes parteixen d'una class Abstracte que defineix dos metodes, un de public que acull el codi necessari pel Parser del grup i un altre metode protect que resolt la creació del text.

````csharp
abstract class AbstractParser
{
    abstract public string Parse(string code);
    abstract protected string Frase(string[] values);
}
````

D'aquesta manera cada class que fa el parser d'un grup te la mateixa estructura i funcionament i alhora aillo el tractament del text fora del nucli del procés del parser.

````csharp
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
````

És un primer enfoc i evidentment haure de fer un repàs del naming de metodes i variables :D  però ara l'important per mi és anar veient com resoldre-ho amb C# i a mesura que avanci ja anire polint detalls d'aquests.

Aquests son els grups que cal analitzar, cada un d'ells te un class principal que el gestiona:

```
METAR  -> LELL 282230Z AUTO VRB02KT CAVOK 15/09 Q1017
Tokens ->  0      1      2     3      4     5     6
```

* 0 - Lloc
* 1 - Dia i hora
* 2 - Observació
* 3 - Vent
* 4 - Visibilitat
* Temps
* Boires
* 5 - Temperatura
* 6 - Pressió
* Tendencia

El text que ha de generar és en plan:

````
Previsió per Aeroport de Sabadell. Dia 28 a les 22:30 UTC. Observació generada automàticament
Vent variable de 2kt. Visibilitat de més de 10km i cap boira per sota de 5000ft (1500m)
Temperatura de 15º punt de Rocio a 9º
QNH 1017

````

### Informació de referencia

[Decodificar un METAR](ME030 5.1. informes meteo.pdf)

[Aiport codes](https://github.com/datasets/airport-codes)

[Open Data Airports](https://ourairports.com/data/)

[Así es como se lee un METAR](https://metar-taf.com/es/explanation)


