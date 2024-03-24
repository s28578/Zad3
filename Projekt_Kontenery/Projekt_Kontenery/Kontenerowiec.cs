namespace Projekt_Kontenery;

public class Kontenerowiec
{
    private List<Kontener> kontenery;
    private double MaxPredkosc { get; set; }
    private double MaxLiczbaKontenerow { get; set; }
    public double MaxWagaWszystkichKontenerow { get; set; }
    public double WagaZaladunku { get; set; }

    public Kontenerowiec( double maxPredkosc, double maxLiczbaKontenerow, double maxWagaWszystkichKontenerow)
    {
        this.kontenery = new List<Kontener>();
        MaxPredkosc = maxPredkosc;
        MaxLiczbaKontenerow = maxLiczbaKontenerow;
        MaxWagaWszystkichKontenerow = maxWagaWszystkichKontenerow;
    }

    public void ZaladujKontener(Kontener kontener)
    {
        if (kontenery.Count >= MaxLiczbaKontenerow)
        { 
            Console.WriteLine("Zbyt duza ilosc kontenerow.");
            
        }
        else if (kontener.MasaLadunku + kontener.WagaKontenera + WagaZaladunku > MaxWagaWszystkichKontenerow)
        {
            Console.WriteLine("Zbyt duza waga kontenera " + (kontener.MasaLadunku + kontener.WagaKontenera) +
                              ". Max waga zaladunku bylaby przekroczona. Aktualna waga: " + WagaZaladunku + "/" + MaxWagaWszystkichKontenerow + ".");
        }
        else if(kontenery.Contains(kontener))
        {
            Console.WriteLine("Jest juz zaladowany.");
        }
        else
        {
            Console.WriteLine("Kontener zaladowano.");
            kontenery.Add(kontener);
            kontener.Kontenerowiec = this;
            WagaZaladunku += kontener.WagaKontenera + kontener.MasaLadunku;
        }
    }

    public void ZaladujListeKontenerow(List<Kontener> konteneryZaladunek)
    {
        double wagaKontenerow = 0;
        foreach (Kontener kontener in konteneryZaladunek)
        {
            wagaKontenerow += kontener.WagaKontenera + kontener.MasaLadunku;
        }
        
        if (konteneryZaladunek.Count + kontenery.Count >= MaxLiczbaKontenerow)
        { 
            Console.WriteLine("Zbyt duza ilosc kontenerow.");
        }
        else if (wagaKontenerow + WagaZaladunku > MaxWagaWszystkichKontenerow)
        {
            Console.WriteLine("Zbyt duza waga kontenerow. Max waga zaladunku bylaby przekroczona. Aktualna waga: "
                              + WagaZaladunku + "/" + MaxWagaWszystkichKontenerow + ".");
        }
        else
        {
            
            foreach (Kontener kont in konteneryZaladunek)
            {
                ZaladujKontener(kont);
                
            }
        }
    }

    public bool UsunKontener(Kontener kontener)
    {
        if (!kontenery.Contains(kontener))
        {
            Console.WriteLine("Nie ma takiego kontenera na liscie.");
            return false;
        }
        else
        {
            this.WagaZaladunku = this.WagaZaladunku - kontener.WagaKontenera - kontener.MasaLadunku;
            kontenery.Remove(kontener);
            kontener.Kontenerowiec = null;
            Console.WriteLine("Usunieto kontener.");
            return true;
        }
    }

    public void ZastapKontener(string nrSeryjny, Kontener kontener)
    {
        Kontener kontenerUsuwany = null;
        foreach (Kontener kon in kontenery)
        {
            if (kon.NrSeryjny == nrSeryjny)
                kontenerUsuwany = kon;
        }

        if (kontenerUsuwany == null)
        {
            Console.WriteLine("Nie ma kontenera o takim numerze.");
        }
        else
        {
            this.UsunKontener(kontenerUsuwany);
            this.ZaladujKontener(kontener);
        }
    }

    public static void PrzeniesKontener(Kontenerowiec konOd, Kontenerowiec konDo, Kontener kontener)
    {
        if(konOd.UsunKontener(kontener))
            konDo.ZaladujKontener(kontener);
    }

    public override string ToString()
    {
        string temp = "";
        int n = 1;
        foreach (Kontener kontener in kontenery)
        {
            temp += n + ". " + kontener.ToString() + "\n";
            n++;
        }
        return $"Informacje o kontenerowcu:  {nameof(MaxPredkosc)}: {MaxPredkosc}, {nameof(MaxLiczbaKontenerow)}: {MaxLiczbaKontenerow}, {nameof(MaxWagaWszystkichKontenerow)}: {MaxWagaWszystkichKontenerow}, {nameof(WagaZaladunku)}: {WagaZaladunku} \n {temp}";
    }
}