# AlzaTest
Pro implementaci jsem zvolil CQRS pattern, který je velmi dobře obslužitelný a rozšiřitelný a v případě potřeby škálovatelný. Metody jsou asynchronní pro lepší responsibilitu.
Jako databáze je využívána MSSQL, pro potřeby testu je zavedena v appsettings "MockData" proměnná, která při update databázi naplní databázi testovacími daty.
Pro ORM vstvu byl použit Entity framework a repository pattern.
Pro obsluhu requestů jsem se rozhodl pro využití MediatR. Jedná se o mediator pattern, který obsluhuje dané query a commandy z CQRS. 
Bohužel jsem se zasekl na unit testech. Jelikož jsou všechny asynchronní, nedaří se mi je správně provolat. Bohužel jsem neměl více času se tomu věnovat. 

Solution je složena z nějakolika projektů - reprezentující doménový model, infrastrukturu, aplikační doménu a pak WepAPI, která je hlavním projektem.
