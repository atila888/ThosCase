# Scaffold Alma:

1. Once Solution üzerinde Data olan proje sağa tıklanarak "Set as Startup Project" seçilir.
2. Package Manager Console üzerinde Default Project içinde Data projesi seçilir.
3. `dir` komutu ile hangi klasörde olduğumuzu görebiliriz. `cd` komutu ile Data projesinin içine girilir.
4. Aşağıdaki komut ile scaffold alma işlemi gerçekleştirilir:

```bash
dotnet ef dbcontext scaffold "Server=<SERVERNAME>;Database=<DBNAME>;User Id=<USERID>;Password=<PASSWORD>;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -o Models/Context --context "Context" --project ThosCase.Data.csproj
```

# Açıklama

1. PROPERTY tablosunda KEY kolonunun KEY_ olarak tanımlamak zorunda kaldım.
2. USER tablosunu USER_ tanımlamak zorunda kaldım.
3. ForeignKey i özellikle oluşturmadım. Çünkü ForeignKey ler DB de yavaşlığa sebebiyet veriyor. Foreign Key mantığını Validasyonlar üzerinden kontrol ettim.
4. BE de validasyon işlemleri FluentValidation ile ThosCase.DAL.BusinessObjects.Validators.ValidationExtensions içerisinde kontrol edildi.

# Eksikler

1. Kullanıcı Paneli oluşturamadım.(Zaman yetişmedi)
2. Admin panelinde kullanıcı girişi ve Auth işlemi yapamadım.(Zaman yetişmedi).
3. Auth işlemi yapamadığım için DB ye kaydedilen datalar için Creatoruserid bilgisini alamadım.(Zaman yetişmedi).
4. ImagePath işlemi için kendim CDN e yükleyip ordan ImagePath almam gerekirdi.(Zaman yetişmedi).
5. BE den gelen hatalar ekrana gösterilmesi gerekliydi.Proje içerisinde alert olarak statik mesaj ekledim.(Zaman yetişmedi)

# Eğer Yapsaydım Nasıl Yapardım?

1. Eksiklerde bulunan ikinci madde için JWT Token mekanızması kurardım. Ve Auth işlemlerini bununla kontrol ederdim.
2. Eksiklerde bulunan üçüncü madde için ise gelen Token ı decode edip ThosCase.Data.Entity içerisinde Creatoruserid ye set ederdim.
3. Dashbord da bulunan kur bilgileri için https://www.tcmb.gov.tr/kurlar/today.xml adresindeki xml veriyi jquery-ajax yardımıyla çekerdim,Bu veriyi parse edip ekranda gösterebilirdim.
4. Dashboard da bulunan Kategorilere bağlı ürün sayısı için bir endpoint hazırlardım ve jquery-ajax yardımıyla çekerdim. Bunu her 10 saniyede bir çekebilmek için ise jquery üzerinde interval yardımıyla ajax bulunan metodu çalıştırırdım.