

using Projekt_Kontenery;

Console.WriteLine("Hello, World!");

KontenerChlodniczy kch1 = KontenerChlodniczy.StworzKontChl(300, 15, 100, 20,
    1000, "Bananas", 13.3);
Console.WriteLine(kch1.ToString());

Console.WriteLine("===================================");

Kontenerowiec kontenerowiec1 = new Kontenerowiec(100, 2, 1500);
kontenerowiec1.ZaladujKontener(kch1);
Console.WriteLine(kontenerowiec1.ToString());

Console.WriteLine("===================================");

KontenerGaz kg1 = new KontenerGaz(1400, 23, 20, 20, 1500, 100);
kontenerowiec1.ZaladujKontener(kg1);

Console.WriteLine("===================================");
KontenerPlyny kp1 = new KontenerPlyny(100, 20, 20, 13, 200, KontenerPlyny.RodzajPlyny.Zwykly);
KontenerChlodniczy kch2 = KontenerChlodniczy.StworzKontChl(300, 15, 100, 20,
    1000, "Bananas", 13.3);
List<Kontener> lista = new List<Kontener>();
lista.Add(kp1);
lista.Add(kch2);
Kontenerowiec kontenerowiec2 = new Kontenerowiec(100, 15, 190000);

kontenerowiec1.ZaladujListeKontenerow(lista);
kontenerowiec2.ZaladujListeKontenerow(lista);

Console.WriteLine("\n" + kontenerowiec2.ToString());

Console.WriteLine("===================================");

kch2.ZaladowanieKontenera(15, "Bananas");
kch2.ZaladowanieKontenera(2, "Fish");
//kch2.ZaladowanieKontenera(3000, "Bananas");

Console.WriteLine("===================================");

kontenerowiec2.UsunKontener(kch2);
Console.WriteLine("\n" + kontenerowiec2.ToString());

Console.WriteLine("===================================");

kontenerowiec2.ZastapKontener("KON-L-3", kch2);
Console.WriteLine("\n" + kontenerowiec2.ToString());
Kontenerowiec.PrzeniesKontener(kontenerowiec2, kontenerowiec1, kch2);
Console.WriteLine("\n" + kontenerowiec2.ToString());
Console.WriteLine("\n" + kontenerowiec1.ToString());

Console.WriteLine("===================================");

kch2.RozladowanieKontenera(15);
Console.WriteLine(kch2.ToString());
kch2.RozladowanieKontenera(300050);
kch2.OproznienieLadunku();
Console.WriteLine(kch2.ToString());