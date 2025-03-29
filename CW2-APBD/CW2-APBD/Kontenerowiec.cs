namespace CW2_APBD;

public class Kontenerowiec
{
    private List<Kontener> kontenery;
    
    public string Nazwa { get; private set; }
    public int MaksymalnaPredkosc { get; private set; }
    public int MaksymalnaLiczbaKontenerow { get; private set; }
    public int MaksymalnaWaga { get; private set; }

    public Kontenerowiec(string nazwa, int maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, int maksymalnaWaga)
    {
        Nazwa = nazwa;
        MaksymalnaPredkosc = maksymalnaPredkosc;
        MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
        MaksymalnaWaga = maksymalnaWaga;
        kontenery = new List<Kontener>();
    }

    public bool ZaladujKontener(Kontener kontener)
    {
        if (kontenery.Count >= MaksymalnaLiczbaKontenerow)
        {
            Console.WriteLine($"Nie można załadować kontenera {kontener.NumerSeryjny}: Statek {Nazwa} osiągnął maksymalną pojemność kontenerów");
            return false;
        }
        
        int aktualnaWaga = PobierzCalkowitaWage();
        int wagaKonteneraWTonach = (kontener.WagaWlasna + kontener.MasaLadunku) / 1000;
        
        if (aktualnaWaga + wagaKonteneraWTonach > MaksymalnaWaga)
        {
            Console.WriteLine($"Nie można załadować kontenera {kontener.NumerSeryjny}: Przekroczyłoby to maksymalną wagę statku {Nazwa}");
            return false;
        }
        
        kontenery.Add(kontener);
        Console.WriteLine($"Kontener {kontener.NumerSeryjny} załadowany na statek {Nazwa}");
        return true;
    }

    public bool ZaladujKontenery(List<Kontener> konteneryDoZaladunku)
    {
        bool wszystkieZaladowane = true;
        foreach (var kontener in konteneryDoZaladunku)
        {
            if (!ZaladujKontener(kontener))
            {
                wszystkieZaladowane = false;
            }
        }
        return wszystkieZaladowane;
    }

    public bool UsunKontener(string numerSeryjny)
    {
        Kontener kontener = kontenery.FirstOrDefault(c => c.NumerSeryjny == numerSeryjny);
        
        if (kontener == null)
        {
            Console.WriteLine($"Kontener {numerSeryjny} nie znaleziony na statku {Nazwa}");
            return false;
        }
        
        kontenery.Remove(kontener);
        Console.WriteLine($"Kontener {numerSeryjny} usunięty ze statku {Nazwa}");
        return true;
    }

    public bool ZamienKontener(string numerSeryjnyStarego, Kontener nowyKontener)
    {
        if (UsunKontener(numerSeryjnyStarego))
        {
            return ZaladujKontener(nowyKontener);
        }
        return false;
    }

    public bool PrzenieśKontener(string numerSeryjny, Kontenerowiec statekDocelowy)
    {
        Kontener kontener = kontenery.FirstOrDefault(c => c.NumerSeryjny == numerSeryjny);
        
        if (kontener == null)
        {
            Console.WriteLine($"Kontener {numerSeryjny} nie znaleziony na statku {Nazwa}");
            return false;
        }
        
        if (statekDocelowy.ZaladujKontener(kontener))
        {
            kontenery.Remove(kontener);
            Console.WriteLine($"Kontener {numerSeryjny} przeniesiony z {Nazwa} na {statekDocelowy.Nazwa}");
            return true;
        }
        
        return false;
    }

    public int PobierzCalkowitaWage()
    {
        return kontenery.Sum(c => (c.WagaWlasna + c.MasaLadunku)) / 1000;
    }

    public List<Kontener> PobierzKontenery()
    {
        return new List<Kontener>(kontenery);
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Statek: {Nazwa}");
        Console.WriteLine($"Maksymalna prędkość: {MaksymalnaPredkosc} węzłów");
        Console.WriteLine($"Kontenery: {kontenery.Count}/{MaksymalnaLiczbaKontenerow}");
        Console.WriteLine($"Waga: {PobierzCalkowitaWage()}/{MaksymalnaWaga} ton");
        Console.WriteLine("Kontenery na pokładzie:");
        
        if (kontenery.Count == 0)
        {
            Console.WriteLine("  Brak");
        }
        else
        {
            foreach (var kontener in kontenery)
            {
                Console.WriteLine($"  {kontener}");
            }
        }
    }
}