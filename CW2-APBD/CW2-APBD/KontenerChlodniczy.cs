namespace CW2_APBD;

public class KontenerChlodniczy : Kontener
{
    public string RodzajProduktu { get; private set; }
    public int Temperatura { get; private set; }

    public KontenerChlodniczy(int wysokosc, int wagaWlasna, int glebokosc, int maksymalnaPojemnosc, string rodzajProduktu, int temperatura)
        : base('C', wysokosc, wagaWlasna, glebokosc, maksymalnaPojemnosc)
    {
        RodzajProduktu = rodzajProduktu;
        Temperatura = temperatura;
    }

    public override void ZaladujLadunek(int masa)
    {
        int wymaganaTemperatura = PobierzWymaganaTemperature(RodzajProduktu);
        if (Temperatura > wymaganaTemperatura)
        {
            PowiadomONiebezpieczenstwie($"Temperatura kontenera {Temperatura}za wysoka dla produktu {RodzajProduktu}", NumerSeryjny);
            throw new InvalidOperationException($"Temperatura kontenera jest zbyt wysoka dla {RodzajProduktu}");
        }
        
        base.ZaladujLadunek(masa);
    }

    private int PobierzWymaganaTemperature(string rodzajProduktu)
    {
        Dictionary<string, int> temperaturyProduktow = new Dictionary<string, int>
        {
            { "Banany", 13 },
            { "Czekolada", 18 },
            { "Ryby", 2 },
            { "Mięso", 0 },
            { "Lody", -18 }
        };

        if (temperaturyProduktow.ContainsKey(rodzajProduktu))
        {
            return temperaturyProduktow[rodzajProduktu];
        }
        return 20;
    }

    public override string ToString()
    {
        return base.ToString() + $", Typ: Chłodniczy, Produkt: {RodzajProduktu}, Temperatura: {Temperatura}°C";
    }
}