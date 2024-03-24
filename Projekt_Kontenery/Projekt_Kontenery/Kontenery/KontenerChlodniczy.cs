namespace Projekt_Kontenery;

public class KontenerChlodniczy : Kontener
{
    public static Dictionary<string, double> RodzajeProduktow = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    private string RodzajLadunku { get; set; }
    private double Temperatura { get; set; }
    
    private KontenerChlodniczy(double masaLadunku, double wysokosc, double wagaKontenera,
        double glebokosc, double maxLadownosc, string rodzajLadunku, double temperatura)
        : base(masaLadunku, wysokosc, wagaKontenera, glebokosc, maxLadownosc)
    {
        this.RodzajLadunku = rodzajLadunku;
        this.Temperatura = temperatura;
        this.NrSeryjny = "KON-C-" + Kontener.MaxNumer;
    }

    public static KontenerChlodniczy StworzKontChl(double masaLadunku, double wysokosc, double wagaKontenera,
            double glebokosc, double maxLadownosc, string rodzajLadunku, double temperatura)
    {
        if (!RodzajeProduktow.ContainsKey(rodzajLadunku))
        {
            Console.WriteLine("Zly rodzaj produktu.");
        }
        else if (temperatura < RodzajeProduktow[rodzajLadunku])
        {
            Console.WriteLine("Zbyt niska temperatura.");
        }
        else
        {
            return new KontenerChlodniczy(masaLadunku, wysokosc, wagaKontenera, glebokosc, maxLadownosc,
                rodzajLadunku, temperatura);
        }

        return null;
    }

    public void ZaladowanieKontenera(double masa, string rodzaj)
    {
        if (rodzaj != RodzajLadunku)
        {
            Console.WriteLine("Zly rodzaj ladunku.");
        }
        else
        {
            base.ZaladowanieKontenera(masa);
        }
    }

    public void ZmienRodzajLadunku(string rodzaj)
    {
        if (this.MasaLadunku != 0)
        {
            Console.WriteLine("Kontener nie jest pusty.");
        }
        else if (!RodzajeProduktow.ContainsKey(rodzaj))
        {
            Console.WriteLine("Zly rodzaj.");
                
        }
        else
        {
            this.RodzajLadunku = rodzaj;
        }
    }

    public void ZmienTemperature(double temp)
    {
        this.Temperatura = temp;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(RodzajLadunku)}: {RodzajLadunku}, {nameof(Temperatura)}: {Temperatura}";
    }
}