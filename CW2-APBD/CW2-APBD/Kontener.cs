namespace CW2_APBD;

public abstract class Kontener : IHazardNotifier
{
    private static Dictionary<char, int> licznikSeryjny = new Dictionary<char, int>
    {
        { 'L', 0 },
        { 'G', 0 },
        { 'C', 0 }
    };

    public string NumerSeryjny { get; set; }
    public int MasaLadunku { get; set; }
    public int Wysokosc { get; set; }
    public int WagaWlasna { get; set; }
    public int Glebokosc { get; set; }
    public int MaksymalnaPojemnosc { get; set; }

    protected Kontener(char typ, int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaPojemnosc)
    {
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaksymalnaPojemnosc = maksymalnaPojemnosc;
        
        licznikSeryjny[typ]++;
        NumerSeryjny = $"KON-{typ}-{licznikSeryjny[typ]}";
        
        MasaLadunku = 0;
    }

    public virtual void OproznijLadunek()
    {
        MasaLadunku = 0;
    }

    public virtual void ZaladujLadunek(int masa)
    {
        if (masa > MaksymalnaPojemnosc)
        {
            throw new OverfillException($"Nie można załadować {masa}kg do kontenera o pojemności {MaksymalnaPojemnosc}kg");
        }
        
        MasaLadunku = masa;
    }

    public void PowiadomONiebezpieczenstwie(string text, string numerSeryjny)
    {
        Console.WriteLine($"ALERT ZAGROŻENIA dla {numerSeryjny}: {text}");
    }
    public override string ToString()
    {
        return $"Kontener {NumerSeryjny}: {MasaLadunku}kg/{MaksymalnaPojemnosc}kg załadowane, {Wysokosc}cm x {Glebokosc}cm, Waga własna: {WagaWlasna}kg";
    }
}