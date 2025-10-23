# UstaPlatform

## Gereksinimler
- .NET 7 SDK (tercih edilen)
- `dotnet build`

## Proje Yapısı
- UstaPlatform.Domain : Domain modelleri
- UstaPlatform.Pricing : IPricingRule arayüzü & PricingContext
- UstaPlatform.Infrastructure : PricingEngine, Repos, Helpers
- UstaPlatform.App : Console demo uygulaması
- plugins/ : runtime plugin DLL'leri buraya kopyalanır

## Çalıştırma
1. Çözümü derle: `dotnet build`
2. `plugins` klasörüne plugin.dll kopyala (örn LoyaltyDiscountRule.dll)
3. `UstaPlatform.App` projesini çalıştır: `dotnet run --project src/UstaPlatform.App/UstaPlatform.App.csproj`
4. Console'da yüklü kurallar ve hesaplanan fiyat gözükecek.

## Nasıl yeni kural eklerim?
- Yeni bir class library oluştur, `UstaPlatform.Pricing` referansı ekle.
- `IPricingRule` implement eden sınıfı yaz ve derle.
- Ortaya çıkan dll'i `plugins` klasörüne koy; uygulama yeniden başlatıldığında kural yüklenecek.

