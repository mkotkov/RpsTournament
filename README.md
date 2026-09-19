# RpsTournament

"Kivi, paber, käärid" turniirimäng. WPF-rakendus .NET platvormil, tumeda kasutajaliidesega.

## Kirjeldus

Mängija mängib arvuti vastu 5 vooru. Iga vooru järel salvestatakse tulemus, uuendatakse skoori ja lisatakse kirje turniiri ajalukku. Pärast 5 vooru selgub turniiri võitja.

## Funktsioonid

- Mängija nime sisestamine
- Käigu valik: Kivi / Käärid / Paber, valitud käik on visuaalselt esile tõstetud
- Skoori jälgimine reaalajas
- Vooru tulemuse staatus (võit, kaotus, viik)
- Turniiri ajaloo tabel: vooru number, mängija käik, arvuti käik, tulemus
- Uue turniiri alustamine, mis lähtestab skoori ja ajaloo

## Projekti struktuur

Lahendus (`RpsTournament.slnx`) koosneb kahest projektist:

- **RpsTournament.Core** — mängu loogika: mudelid (`GameRound`, `Move`, `RoundResult`) ja klass `GameLogic`, mis määrab arvuti käigu ja vooru tulemuse.
- **RpsTournament.WpfApp** — WPF-rakendus (`MainWindow`), mis kasutab kasutajaliideses `RpsTournament.Core` loogikat.

## Tehnoloogiad

.NET, C#, WPF

## Käivitamine

1. Klooni repositoorium:
   ```
   git clone https://github.com/mkotkov/RpsTournament.git
   ```
2. Ava `RpsTournament.slnx` Visual Studios.
3. Määra `RpsTournament.WpfApp` käivitusprojektiks.
4. Käivita klahviga F5.

Või .NET CLI kaudu:

```
dotnet build
dotnet run --project RpsTournament.WpfApp
```

## Mängimine

1. Sisesta oma nimi väljale "Player name".
2. Vali käik: Rock, Paper või Scissors.
3. Vajuta "Play", et mängida voor.
4. Pärast 5 vooru kuulutatakse turniiri võitja.
5. Uue turniiri alustamiseks vajuta "New Tournament".

## Litsents

Litsents pole määratud.
