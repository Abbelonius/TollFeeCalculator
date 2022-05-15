# TollFeeCalculator

Detta repo är för kodintervju hos Tietoevry med uppgiften att skapa ett klassbibliotek som kan hantera beräkning av trängselskatt för bilar i Göteborg. 
Detta baserat på en bifogad ofullständig lösning med många code smells. 

Då jag haft ont om tid för detta har jag avgränsat problemet ytterligare. 
Detta gäller främst: 
  1. Tester - Jag har inte skrivit några men återkommer gärna med enhetstest om så önskas. 
  2. I verkligheten finns många olika typer av fordon och regler för vem som betalar trängselskatt och jag har valt att bara implementera ett fåtal då lösningen skulle se snarlik ut för de andra. 
     Se t.ex. lösningen för bussar(Bus.cs) för ett hum om hur man skulle kunna göra. Dessa implementationer hade förändrats mycket baserat på resten av domänens behov och huruvida det är ett helt internt projekt eller om man skall publicera ett öppet NuGet-paket. 
     
Vidare har jag antagit att man inte skickar några nullvärden till parametrarna. Om biblioteket enbart skall användas internt hade jag övervägt att aktivera nullbara referenstyper för hela projektet för att få det nullsäkert slippa skydda mot null. 

Övriga tankar kring koden: 
  1. GetDailyTollFee - Jag har inte hunnit testa genomgående så att det inte finns några logiska fel men jag är nöjd med att koden är betydligt mer läsbar nu. 
  2. GetPassageCost - Återigen betydligt mer läsbart men jag är inte helt nöjd med lösningen. En möjlig förbättring jag haft i åtanke är att man skulle kunna läsa in rader från t.ex. en CSV-fil så att man inte hårdkodar tider/kostnader i kod. 
     På det sättet är det även lätt för någon(kanske en IT-tekniker) att modifiera filen vid behov utan att blanda in en utvecklare. 

Jag hoppas att lösningen är fullgod och diskuterar gärna varför jag har gjort som jag gjort och vad som kan förbättras ytterligare här på GitHub, mail eller telefon. 

/A
