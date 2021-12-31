# METAR

És una aplicació per interpretar els METAR i traduir-los a una descripció més __humana.__ Feta per apendre C# 

## TODO

- [ ] Millorar el parser, crear funcions per tractar cada tipus de token de manera més __atomica__ que la inicial. El tractament del __vent__ és un exemple d'aquesta necessitat.
- [ ] Posar framework tests i començar amb TDD.
- [ ] Fer versió amb API per web.
- [ ] La llista del Aeroports no ha de ser un Diccionari, s'ha de descarregar del CSV actualitzat i buscar alla l'aeroport via codi OACI. Treure el diccionari de la class Airports.cs ... més endavant veure rendiment del CSV versus un SQLite, i fer scripts necessaris per preparar tot això cada vegada que s'actualitza llista.

### Informació de referencia

[Decodificar un METAR](ME030 5.1. informes meteo.pdf)

[Aiport codes](https://github.com/datasets/airport-codes)

[Open Data Airports](https://ourairports.com/data/)



