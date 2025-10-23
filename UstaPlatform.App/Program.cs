using System;
using UstaPlatform.Domain.Models;
using UstaPlatform.Infrastructure;
using UstaPlatform.Infrastructure.Repositories;
using UstaPlatform.Pricing;
using UstaPlatform.Infrastructure.Helpers;

Console.WriteLine("UstaPlatform - Demo Başlıyor");

// Repos ve engine
var workRepo = new InMemoryWorkOrderRepository();
var pricingEngine = new PricingEngine();

// Plugins klasörünü tara
var pluginsFolder = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "plugins");
Console.WriteLine($"Plugins folder: {Path.GetFullPath(pluginsFolder)}");
pricingEngine.LoadPluginsFrom(pluginsFolder);

// Basit domain örnekleri
var usta1 = new Usta { Ad = "Ahmet Usta", Uzmanlik = "Tesisat", Puan = 4.8 };
var usta2 = new Usta { Ad = "Mehmet Usta", Uzmanlik = "Tesisat", Puan = 4.3, AktifIsSayisi = 2 };

var vat = new Vatandas { AdSoyad = "Ali Veli", Adres = "Atatürk Cd. No:1" };

var talep = new Talep
{
    Sahip = vat,
    Aciklama = "Musluk sızdırıyor",
    IstenenGun = DateOnly.FromDateTime(DateTime.Now),
    IstenenSaat = TimeOnly.FromDateTime(DateTime.Now.AddHours(3))
};

// Basit eşleştirme: en az aktif işi olan usta
Usta choose = usta1;
if (usta2.AktifIsSayisi < choose.AktifIsSayisi) choose = usta2;
Console.WriteLine($"Seçilen usta: {choose.Ad}");

// Fiyat hesaplama: baz ücreti 500 TL
decimal basePrice = 500m;
var pctx = new PricingContext { Talep = talep, Usta = choose };
decimal final = pricingEngine.CalculatePrice(basePrice, pctx);

Console.WriteLine($"Hesaplanan fiyat: {MoneyFormatter.Format(final)}");

// İş Emri oluştur
var wo = new WorkOrder
{
    Talep = talep,
    AtananUsta = choose,
    Fiyat = final,
    Tarih = talep.IstenenGun,
    Saat = talep.IstenenSaat
};

workRepo.Add(wo);

// Schedule örneği
var schedule = new Schedule();
schedule.Add(wo);

Console.WriteLine($"İş emri eklendi: {wo.Id} - {wo.Tarih} {wo.Saat}");
Console.WriteLine("Mevcut schedule (bugün):");
var today = DateOnly.FromDateTime(DateTime.Now);
foreach (var w in schedule[today])
{
    Console.WriteLine($" - {w.Talep.Aciklama} - Usta: {w.AtananUsta.Ad} - Fiyat: {MoneyFormatter.Format(w.Fiyat)}");
}

Console.WriteLine("Yüklenen pricing kuralları:");
foreach (var r in pricingEngine.Rules) Console.WriteLine($" * {r.Name}");

Console.WriteLine("Demo bitti.");
