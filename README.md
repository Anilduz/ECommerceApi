E-Ticaret API

Bu proje, temel kullanıcı oluşturma, ürün oluşturma, stok güncelleme, sipariş oluşturma ve kullanıcı sorgulama (GET) gibi işlemler gerçekleştiren temel bir ASP.NET Core Web API örneğidir.

Amaç: Bağımlılık Enjeksiyonu (DI), Repository ve Service katmanlarının kullanımı ile DTO (Data Transfer Object) desenini göstermektir.

Endpointler:

(post) /orders
(get)  /orders/user/{userId}

(post) /products
(get)  /products
(put)  /products/{id}/stock
(get)  /products/{id}

(post) /users
(get)  /users/{id}



- Teknolojiler

C# / .NET Core: 8.0
Framework: ASP.NET Core Web API
Veri Depolama: InMemory 


- Kurulum ve Çalıştırma

Projeyi indirip hazır verilere in memory db üzerinden tüm özellikleri kullanabilirsiniz. Herhangi bir konfigürasyona ihtiyaç yoktur.

https://github.com/Anilduz/ECommerceApi.git

echo "# ECommerceApi" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/Anilduz/ECommerceApi.git
git push -u origin main
