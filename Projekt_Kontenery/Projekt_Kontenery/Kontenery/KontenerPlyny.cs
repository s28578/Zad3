namespace Projekt_Kontenery;

public class KontenerPlyny: Kontener, IHazardNotifier
{
    public enum RodzajPlyny
    {
        Niebezpieczny,
        Zwykly
    }

    private RodzajPlyny RodzajLadunku { get; set; }
    
    
    
    public void Notyfikacja(string message, string nrSeryjny)
    {
        Console.WriteLine(message + "Nr seryjny: " + nrSeryjny);
    }


    public KontenerPlyny(double masaLadunku, double wysokosc, double wagaKontenera,
                         double glebokosc, double maxLadownosc, RodzajPlyny rodzajLadunku) :
                         base(masaLadunku, wysokosc, wagaKontenera, glebokosc, maxLadownosc)
    {
        this.RodzajLadunku = rodzajLadunku;
        this.NrSeryjny = "KON-L-" + Kontener.MaxNumer;
    }

    protected override void ZaladowanieKontenera(double masa)
    {
        if (RodzajLadunku == RodzajPlyny.Niebezpieczny)
        {
            if (this.MasaLadunku + masa > 0.5 * this.MaxLadownosc)
                this.Notyfikacja("Niebezpieczna operacja. Max mozna wypelnic 50% pojemnosci.", this.NrSeryjny);
        }
        else if (this.RodzajLadunku == RodzajPlyny.Zwykly)
        {
            if (this.MasaLadunku + masa > 0.9 * this.MaxLadownosc)
                this.Notyfikacja("Niebezpieczna operacja. Max mozna wypelnic 90% pojemnosci.", this.NrSeryjny);
        }
        else
        {
            base.ZaladowanieKontenera(masa);
        }

    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(RodzajLadunku)}: {RodzajLadunku}";
    }
}