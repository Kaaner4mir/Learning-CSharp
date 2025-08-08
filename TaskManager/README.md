# 🗂️ Görev Yönetimi Konsol Uygulaması

Bu proje, **C#** kullanılarak geliştirilmiş basit bir **Görev Yönetimi** (Task Manager) konsol uygulamasıdır.  
Kullanıcılar bu uygulama ile görev ekleyebilir, listeleyebilir, güncelleyebilir ve silebilir.  
Ayrıca uygulama başlangıçta birkaç örnek görev ile çalışmaya başlar.

---

## 🚀 Özellikler
- **Görev Ekleme** → Ad, açıklama, öncelik durumu eklenir
- **Görev Listeleme** → Tüm görevler detaylı olarak listelenir
- **Görev Güncelleme** → Ad, açıklama veya durum bilgisi güncellenir
- **Görev Silme** → ID numarasına göre görev silinir
- **Çıkış İşlemi** → Kullanıcı onayı ile program sonlandırılır
- **Renkli Konsol Mesajları** ve **Yükleme Animasyonu**

---

## 📦 Kullanılan Teknolojiler
- **.NET 6+** veya üzeri
- **C# Console Application**
- **System.Text** (Encoding desteği)
- **List<T>** ile görev saklama
- **Random** ile görev ID üretimi
- **Thread.Sleep** ile animasyon

---

## 📜 Menüler ve İşlevler

| No  | İşlem                     | Açıklama |
|-----|---------------------------|----------|
| 1   | Görev ekleme               | Kullanıcıdan bilgiler alınır, listeye eklenir |
| 2   | Görev listeleme            | Tüm görevler ekranda gösterilir |
| 3   | Görev güncelleme           | ID girilerek seçilen görev düzenlenir |
| 4   | Görev silme                | ID girilerek görev listeden kaldırılır |
| 5   | Çıkış                      | Kullanıcı onayı ile program kapanır |

---

## 📂 Örnek Çalışma

**Menü:**
```
1. Görev ekleme                |➕
2. Görev listeleme             |📋
3. Görev güncelleme            |🔃
4. Görev silme                 |🗑️
5. Çıkış                       |❌
```

**Görev Listeleme:**
```
Görev Numarası     : 1234
Görev Adı          : Rapor Hazırlama
Açıklama           : Aylık satış raporunu hazırlama.
Oluşturulma Tarihi : 08.08.2025 10:32:15
Bitiş Tarihi       : 13.08.2025 10:32:15
Durum              : Yapılacak
----------------------------------------
```

---

## 🛠️ Kurulum ve Çalıştırma

1. Bu projeyi bilgisayarına klonla:
   ```bash
   git clone https://github.com/kullaniciadi/task-manager-console.git
   ```
2. Projeyi **Visual Studio 2022** ile aç.
3. `Program.cs` dosyasını incele veya değiştir.
4. **F5** veya **Ctrl + F5** ile çalıştır.

---

## 📌 Notlar
- Tüm görevler program çalıştığı sürece **RAM üzerinde** tutulur.  
  (Veriler program kapatıldığında kaybolur.)
- İlerleyen sürümlerde veriler **dosya** veya **veritabanı** üzerinde saklanabilir.
- Başlangıçta birkaç **örnek görev** otomatik eklenir.

---

# Proje Hakkında

**Geliştirici:** Kaaner  
**Dil:** C#  
**IDE:** Visual Studio 2022  
