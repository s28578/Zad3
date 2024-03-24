namespace Projekt_Kontenery;

public class KontenerGaz: Kontener
{
    private double Cisnienie { get; set; }
    public KontenerGaz(double masaLadunku, double wysokosc, double wagaKontenera, double glebokosc, double maxLadownosc, double cisnienie)
        : base(masaLadunku, wysokosc, wagaKontenera, glebokosc, maxLadownosc)
    {
        this.Cisnienie = cisnienie;
        this.NrSeryjny = "KON-G-" + Kontener.MaxNumer;
    }

    public override void OproznienieLadunku()
    {
        this.MasaLadunku = 0.05 * this.MasaLadunku;
        if (this.Kontenerowiec != null)
        {
            Kontenerowiec.WagaZaladunku -= 0.95 * this.MasaLadunku;
        }
    }
    
    public void Notyfikacja(string message, string nrSeryjny)
    {
        Console.WriteLine(message + "Nr seryjny: " + nrSeryjny);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(Cisnienie)}: {Cisnienie}";
    }
}