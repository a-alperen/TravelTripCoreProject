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
.NET SDK’yı yükleyin
Projeyi çalıştırmak için bilgisayarınızda .NET SDK kurulu olmalıdır. Buradan sisteminize uygun sürümü indirip kurabilirsiniz.

-Projeyi klonlayın veya indirin

git clone https://github.com/a-alperen/TravelTripCoreProject.git
cd TravelTripCoreProject

-Proje bağımlılıklarını indirmek için:
dotnet restore

-Veritabanı bağlantı ayarlarını kontrol edin
appsettings.json dosyasındaki connection string’in kendi veritabanı ortamınıza uygun ve erişilebilir olduğundan emin olun.

-Veritabanını güncelleyin
Migration dosyalarını uygulayarak veritabanını hazırlayın:

dotnet ef database update

-Projeyi çalıştırın
dotnet run
veya Visual Studio ile projeyi açıp çalıştırabilirsiniz.
