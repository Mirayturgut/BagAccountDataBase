
using SepetHesabıDataBase;
using SepetHesabıDataBase.Data;
using var db = new AppDbContext();
//Console.WriteLine($"Veritabanı yolu: {db.Dbpath}"); (Eğer kod ve database çalışırsa ama table'ı göremiyorsan bunu yazdır çıkan şeyi arattır sonra oradan ilerle)
db.Database.EnsureCreated();
var urunler = new List<Urun>();
Console.WriteLine("Kaç ürün gireceksiniz:");
int sayi = int.Parse(Console.ReadLine());

for (int i = 1; i <= sayi; i++)
{
    Console.WriteLine("Ürünün adı:");
    string ad = Console.ReadLine();
    Console.WriteLine("Ürünün fiyatı:");
    int fiyat = int.Parse(Console.ReadLine());
    Console.WriteLine("Ürünün adedi:");
    int adedi = int.Parse(Console.ReadLine());

    var newurun = new Urun
    {
        urunAd = ad,
        urunFıyat = fiyat,
        urunAdet = adedi,
    };
    db.Uruns.Add(newurun);
    db.SaveChanges();
    
    Console.WriteLine("----Ürün Listesi----");
    var uruns = db.Uruns.ToList();
    int geneltoplam = 0;
    foreach (var Urun in uruns)
    {
        int urunToplam = ((Urun.urunAdet) * (Urun.urunFıyat));
        Console.WriteLine($"{Urun.urunAd} - {Urun.urunAdet} adet x {Urun.urunFıyat} TL = {urunToplam} TL");
        geneltoplam += urunToplam;
    }
    Console.WriteLine($"Genel toplam : {geneltoplam} Tl");
}