using CW2_APBD;

public class Program
{
    public static void Main(string[] args)
    {
        
        Kontenerowiec statek1 = new Kontenerowiec("statek1", 25, 100, 2000);
        Kontenerowiec statek2 = new Kontenerowiec("statek2", 20, 150, 3000);
        
        
        KontenerNaPlyny mleko = new KontenerNaPlyny(250, 500, 600, 5000, false);
        KontenerNaPlyny paliwo = new KontenerNaPlyny(250, 600, 600, 6000, true);
        KontenerNaGaz hel = new KontenerNaGaz(300, 700, 600, 3000, 2.5);
        KontenerChlodniczy banany = new KontenerChlodniczy(250, 800, 600, 4000, "Banany", 10);
        
        try
        {
            mleko.ZaladujLadunek(4000);
            paliwo.ZaladujLadunek(2500);
            hel.ZaladujLadunek(2000);
            banany.ZaladujLadunek(3000);
            
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Błąd ładowania towaru: {ex.Message}");
        }
        
        statek1.ZaladujKontener(mleko);
        statek1.ZaladujKontener(paliwo);
        
        statek1.WyswietlInformacje();
        
        
        statek2.ZaladujKontener(hel);
        statek2.ZaladujKontener(banany);
        
        
        statek2.WyswietlInformacje();
        
        statek1.PrzenieśKontener(mleko.NumerSeryjny, statek2);
        
        statek1.WyswietlInformacje();
        
        statek2.WyswietlInformacje();
        
        hel.OproznijLadunek();
        Console.WriteLine($"Kontener z helem po opróżnieniu: {hel}");
        
        
        KontenerChlodniczy lody = new KontenerChlodniczy(250, 800, 600, 4000, "Lody", -10);
        try
        {
            lody.ZaladujLadunek(2000);
            Console.WriteLine("Lody załadowane pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd ładowania lodów: {ex.Message}");
        }
    }
}