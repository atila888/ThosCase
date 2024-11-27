# Scaffold Alma:

```bash
dotnet ef dbcontext scaffold "Server=<SERVERNAME>;Database=<DBNAME>;User Id=<USERID>;Password=<PASSWORD>;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -o Models/Context --context "Context" --project ThosCase.Data.csproj
```

# Açıklama

1. PROPERTY tablosunda KEY kolonunun KEY_ olarak tanımlamak zorunda kaldım.
2. USER tablosunu USER_ tanımlamak zorunda kaldım.
3. Aslında foreign key oluşturmak istemedim. Sebebi ise foreignkey DB de yavaşlığa sebebiyet veriyor. Ama bu tarzlı case lerde görülmesi gerektiği için ekledim.

# Eksikler

1. Kullanıcı Paneli oluşturamadım.(Zaman yetişmedi)
2. Admin panelinde kullanıcı girişi ve Auth işlemi yapamadım.(Zaman yetişmedi).
3. Auth işlemi yapamadığım için DB ye kaydedilen datalar için Creatoruserid bilgisini alamadım.(Zaman yetişmedi).
4. ImagePath işlemi için kendim CDN e yükleyip ordan ImagePath almam gerekirdi.(Zaman yetişmedi).

# Eğer Yapsaydım Nasıl Yapardım?

1. 2. madde için JWT Token mekanızması kurardım. Ve Auth işlemlerini bununla kontrol ederdim.
2. 3. madde için ise gelen Token ı decode edip ThosCase.Data.Entity içerisinde Creatoruserid ye set ederdim.
3. Dashbord da bulunan kur bilgileri için https://www.tcmb.gov.tr/kurlar/today.xml adresindeki xml veriyi jquery-ajax yardımıyla parse edip ekranda gösterebilirdim.
4. Dashboard da bulunan Kategorilere bağlı ürün sayısı için bir endpoint hazırlardım ve jquery-ajax yardımıyla çekerdim. Bunu her 10 saniyede bir çekebilmek için ise jquery üzerinde interval yardımıyla ajax bulanan metodu çalıştırırdım.