namespace CW2_APBD;

public class KontenerNaGaz : Kontener
{
    public double Cisnienie { get; set; }

    public KontenerNaGaz(int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaPojemnosc, double cisnienie)
        : base('G', wysokosc, wagaWlasna, glebokosc, maksymalnaPojemnosc)
    {
        Cisnienie = cisnienie;
    }

    public override void OproznijLadunek()
    {
        MasaLadunku = (int)(MasaLadunku * 0.05);
        if (MasaLadunku == 0)
        {
            PowiadomONiebezpieczenstwie($"Próba oproznienia ładunku: Za mało ładunku{MasaLadunku}", NumerSeryjny);
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", Typ: Gaz, Ciśnienie: {Cisnienie}";
    }
}