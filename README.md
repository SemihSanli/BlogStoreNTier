# 🧩 Blog Projesi - Katmanlı Mimari ve Akıllı Yorum Sistemi 🚀

---

## 🚦 Projede Kullanılan Mimari Katmanlar 🏗️

Bu projede **katmanlı mimari** kullanılmıştır. Katmanlar, kodun düzenli, okunabilir ve sürdürülebilir olması için farklı sorumluluklara ayrılmıştır.

### 1. Presentation (Sunum) Katmanı 🖥️  
- Kullanıcı arayüzü, Controller’lar ve View’ler burada yer alır.  
- 👥 Kullanıcı ile etkileşim ve görsel sunum buradan sağlanır.

### 2. Entity (Varlık) Katmanı 📦  
- Veritabanı tablolarını temsil eden modeller (AppUser, Article, Category, Tag).  
- 🗂️ Sadece veri yapıları içerir, iş mantığı yoktur.

### 3. DataAccess (Veri Erişim) Katmanı 💾  
- Entity Framework kullanılarak veritabanı işlemleri yapılır.  
- 🔍 CRUD ve özel sorgular bu katmanda yazılır.

### 4. Business (İş) Katmanı ⚙️  
- İş mantığı ve kurallar burada uygulanır.  
- 🔧 Servisler, manager sınıfları burada yer alır.  
- 📋 Bağımlılık kayıtları Extension sınıfı ile yönetilir.

---

## 🛠️ Entity Framework ve Özel Metotlar

- 🔄 Entity Framework Core’un hazır metotları yanında, ihtiyaçlara özel metotlar yazıldı.  
- 📌 Örnek: Kullanıcının makalelerini listeleme, kategori bazlı sorgular.

---

## ✨ AJAX ile Yorum İşlemleri

- 📡 Yorumlar sayfa yenilenmeden AJAX ile gönderilir.  
- 🚫 Giriş yapmayan kullanıcılar için yorum alanı gizlenir, giriş yapmaları istenir.

---

## 🔐 URL Güvenliği: Slug Kullanımı

- 🔒 ID yerine okunabilir **slug** kullanılarak URL güvenliği artırıldı.  
- 🌐 Örnek URL: `/articles/guvenli-kodlama-prensipleri`

---

## 👤 Identity ile Kullanıcı Yönetimi

- 🔑 ASP.NET Identity kullanılarak güvenli kullanıcı işlemleri yapıldı.  
- 🛡️ Kayıt, giriş, parola sıfırlama ve yetkilendirme sağlanır.

---

## 📚 Entity’ler ve İlişkiler

| Entity   | Açıklama                                   |
| -------- | ----------------------------------------- |
| 👤 AppUser  | Kullanıcı bilgileri                        |
| 📝 Article  | Makalelerin başlık, içerik, görsel vb.   |
| 📂 Category | Makalelerin ait olduğu kategori            |
| 🏷️ Tag      | Makalelere ait etiketler                   |

- 🔗 İlişkiler:  
  - Her `Article` bir `AppUser` tarafından yazılır.  

---

## 🤖 Akıllı Yorum Sistemi - ToxicBERT

- ⚠️ ToxicBERT ile toksik yorumlar tespit edilir.  
- 🌍 Türkçe yorumlar önce İngilizceye çevrilir (`Helsinki-NLP/opus-mt-tr-en`), sonra analiz edilir.  
- 🚫 Zararlı yorumlar engellenir.

---

## 🗂️ Proje Sayfaları

### 🛠️ Admin Paneli

- 📊 **Dashboard:** Kategori makale dağılımı grafik, son 4 makale ve son 5 yorum.  
- 🗃️ **Makale Listem:** Kullanıcı makaleleri kart görünümünde listelenir.  
- ➕ **Yeni Makale:** Başlık, görsel URL, kategori ve içerik ile makale ekleme.  
- 👤 **Profilim:** Bilgi güncelleme sonrası oturum kapanır.

### 🖥️ UI Paneli

- 🏠 **Ana Sayfa:** Tüm makaleler listelenir, detayda yazar ve yorumlar gösterilir.  
- 📚 **Kategoriler:** Tüm kategoriler ve ilgili makaleler listelenir.  
- 🖋️ **Yazarlar:** Yazarlar ve yazdıkları makaleler.  
- 🔐 **Giriş Yap:** Kullanıcı admin paneline erişir ve yorum yapabilir.

---

## 🔄 BusinessLayer'da Extension Pattern

- 🧩 Bağımlılık kayıtları `Extension` sınıfına taşındı.  
- 🧹 `Program.cs` temiz ve modüler hale geldi.

---

# 🙏 Teşekkürler!  


# Görseller
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/fcf850b7c116b193fbd299b8aee91ba33767cb54/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005529.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/fcf850b7c116b193fbd299b8aee91ba33767cb54/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005540.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/fcf850b7c116b193fbd299b8aee91ba33767cb54/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20112420.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20100750.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/a.jpg)


![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005918.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005924.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005930.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005937.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20005958.png)



![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010119.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010129.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010140.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010200.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010208.png)

![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010241.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010246.png)



![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010719.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/908381df85d9d0909ca534b1bd110664bac51ac2/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20114421.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010726.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010732.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/b6d69db596dffcb0b89d97324eaf2f332c4fda86/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010200.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/908381df85d9d0909ca534b1bd110664bac51ac2/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010739.png)
![ImageAlt](https://github.com/SemihSanli/BlogStoreNTier/blob/908381df85d9d0909ca534b1bd110664bac51ac2/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-28%20010745.png)

