namespace Projekt_Kontenery;

public abstract class Kontener
{
    public static int MaxNumer { get; set; }
    public double MasaLadunku { get; set; }
    protected double Wysokosc{ get; set; }
    public double WagaKontenera{ get; set; }
    protected double Glebokosc{ get; set; }
    public string NrSeryjny{ get; set; }
    protected double MaxLadownosc{ get; set; }
    public Kontenerowiec Kontenerowiec { get; set; }


    protected Kontener(double masaLadunku, double wysokosc, double wagaKontenera, double glebokosc, double maxLadownosc)
    {
        this.MasaLadunku = masaLadunku;
        this.Wysokosc = wysokosc;
        this.WagaKontenera = wagaKontenera;
        this.Glebokosc = glebokosc;
        MaxNumer++;
        this.MaxLadownosc = maxLadownosc;
    }

    public virtual void OproznienieLadunku()
    {
        MasaLadunku = 0;
        if (this.Kontenerowiec != null)
        {
            Kontenerowiec.WagaZaladunku -= MasaLadunku;
        }
    }

    protected virtual void ZaladowanieKontenera(double masa)
    {
        if (masa > MaxLadownosc - MasaLadunku)
        {
            throw new OverfillException("Zbyt duza masa ladunku.");
        }
        else
        {
            
            if (this.Kontenerowiec != null)
            {
                if (Kontenerowiec.WagaZaladunku + masa <= Kontenerowiec.MaxWagaWszystkichKontenerow)
                {
                    Kontenerowiec.WagaZaladunku += masa;
                    MasaLadunku += masa;
                }
                else
                {
                    Console.WriteLine("Zaladowanie przekroczyloby max zaladowanie kontenerowca.");
                }
            }
            else
            {
                MasaLadunku += masa;
            }
        }
    }

    public virtual void RozladowanieKontenera(double masa)
    {
        if (MasaLadunku - masa < 0)
        {
            Console.WriteLine("Nieodpowiednia masa podana.");
        }
        else
        {
            MasaLadunku -= masa;
        }
    }

    public override string ToString()
    {
        
        return $"{nameof(MasaLadunku)}: {MasaLadunku}, {nameof(Wysokosc)}: {Wysokosc}, {nameof(WagaKontenera)}: {WagaKontenera}, {nameof(Glebokosc)}: {Glebokosc}, {nameof(NrSeryjny)}: {NrSeryjny}, {nameof(MaxLadownosc)}: {MaxLadownosc}";
    }
    
    
}