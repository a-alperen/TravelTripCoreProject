# TravelTripCoreProject

ASP.NET Core MVC kullanılarak geliştirilmiş, blog ve seyahat temalı bir içerik yönetim sistemidir.

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- Layered Architecture

## 📦 Proje Özellikleri

- Admin panelinden blog ekleme, silme, güncelleme
- Kullanıcılar yorum bırakabilir (Ad, Soyad, Mail ile)
- Katmanlı mimari ile yapılandırılmıştır

## 📸 Ekran Görüntüleri
[![Main Page](TravelTripCoreProject/Images/MainPage.png)](TravelTripCoreProject/Images/MainPage.png)
[![Admin Panel](TravelTripCoreProject/Images/AdminPanel.png)](TravelTripCoreProject/Images/AdminPanel.png)
[![Blogs Page](TravelTripCoreProject/Images/BlogsPage.png)](TravelTripCoreProject/Images/BlogsPage.png)
[![Blog Detail Page](TravelTripCoreProject/Images/BlogDetailPage.png)](TravelTripCoreProject/Images/BlogDetailPage.png)
[![Comments](TravelTripCoreProject/Images/Comments.png)](TravelTripCoreProject/Images/Comments.png)

## ⚙️ Kurulum
-.NET SDK’nın bilgisayarınızda kurulu olduğundan emin olun. https://dotnet.microsoft.com/download adresinden uygun sürümü indirip yükleyebilirsiniz.

-Projeyi klonlayın veya ZIP olarak indirip açın.

-Komut satırında proje dizinine gidin.

-Bağımlılıkları yüklemek için şu komutu çalıştırın:
dotnet restore

-appsettings.json dosyasındaki ConnectionStrings kısmını kendi veritabanı ortamınıza göre düzenleyin.

-Veritabanını güncellemek için:
dotnet ef database update

-Uygulamayı başlatmak için:
dotnet run
veya Visual Studio ile projeyi açıp “Run” tuşuna basabilirsiniz.

-Projeyi çalıştırın
dotnet run
veya Visual Studio ile projeyi açıp çalıştırabilirsiniz.
