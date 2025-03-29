namespace CW2_APBD;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public bool CzyLadunekNiebezpieczny { get; set; }

    public KontenerNaPlyny(int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaPojemnosc, bool czyLadunekNiebezpieczny)
        : base('L', wysokosc, wagaWlasna, glebokosc, maksymalnaPojemnosc)
    {
        CzyLadunekNiebezpieczny = czyLadunekNiebezpieczny;
    }

    public override void ZaladujLadunek(int masa)
    {
        int maksymalnaDopuszczalnaMasa = CzyLadunekNiebezpieczny ? MaksymalnaPojemnosc / 2 : (int)(MaksymalnaPojemnosc * 0.9);
        
        if (masa > maksymalnaDopuszczalnaMasa)
        {
            PowiadomONiebezpieczenstwie($"Próba załadunku {masa}kg przekracza limit {maksymalnaDopuszczalnaMasa}kg", NumerSeryjny);
            throw new OverfillException($"Nie można załadować {masa}kg. Maksymalny bezpieczny ładunek to {maksymalnaDopuszczalnaMasa}kg");
        }
        
        MasaLadunku = masa;
    }

    public override string ToString()
    {
        return base.ToString() + $", Typ: Płyny, Niebezpieczny: {CzyLadunekNiebezpieczny}";
    }
}