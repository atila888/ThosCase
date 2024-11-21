# Scaffold Alma:

```bash
dotnet ef dbcontext scaffold "Server=<SERVERNAME>;Database=<DBNAME>;User Id=<USERID>;Password=<PASSWORD>;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -o Models/Context --context "Context" --project ThosCase.Data.csproj
```

# Açıklama

1. PROPERTY tablosunda KEY kolonunun KEY_ olarak tanımlamak zorunda kaldım.
2. USER tablosunu USER_ tanımlamak zorunda kaldım.
3. Aslında foreign key oluşturmak istemedim. Sebebi ise foreignkey DB de yavaşlığa sebebiyet veriyor. Ama bu tarzlı case lerde görülmesi gerektiği için ekledim.
